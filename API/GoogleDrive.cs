using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using Google.Apis.Upload;
using Google.Apis.Drive.v3.Data;

namespace GerarEtiquetas.API
{
    public class GoogleDrive
    {

        public static string EnviarArquivo(string arquivo)
        {
            string linkArquivo = string.Empty;

            UserCredential credential;
            string credentialFilePath = Path.Combine("JSON", "client_secret.json");
            string[] scopes = { DriveService.Scope.Drive };

            using (var stream = new FileStream(credentialFilePath, FileMode.Open, FileAccess.Read))
            {
                string credPath = Path.Combine("JSON", "chave2.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    scopes,
                    "laudos@meu-projeto-427622.iam.gserviceaccount.com",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Cria uma instância do cliente do Google Drive
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Laudos",
            });

            // Envia um arquivo para o Google Drive
            Google.Apis.Drive.v3.Data.File fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = arquivo,
                MimeType = "application/pdf"
            };
            using (var stream = new FileStream(arquivo, FileMode.Open))
            {
                var request = service.Files.Create(fileMetadata, stream, "application/pdf");
                var file = request.Upload();
                file.ThrowOnFailure();
                Console.WriteLine("File ID: " + request.ResponseBody.Id);

                linkArquivo = CreateSharingLink(service, request.ResponseBody.Id);
            }

            return linkArquivo;
        }

        public static string? LinkExterno(string CaminhoExeDrive, string fileId)
        {
            // Execute the Google Drive CLI to get the sharing link
            string args = $"--get-sharing-link {fileId}";
            string output = Nucleo.Base.Comum.Processos.Executar(CaminhoExeDrive, args);

            // Parse the output to extract the sharing link
            string? linkCompartilhamento = output.Split('\n').FirstOrDefault(line => line.StartsWith("https://"));

            return linkCompartilhamento;
        }

        public static string CreateSharingLink(DriveService service, string fileId)
        {
            Permission permission = new Permission();
            permission.Type = "anyone";
            permission.Role = "reader";

            var request = service.Permissions.Create(permission, fileId);
            request.Execute();

            var fileRequest = service.Files.Get(fileId);
            fileRequest.Fields = "webViewLink";
            var file = fileRequest.Execute();

            return file.WebViewLink;
        }
    }
}
