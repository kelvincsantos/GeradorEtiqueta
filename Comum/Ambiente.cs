using GerarEtiquetas.Forms.Comum;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerarEtiquetas.Comum
{
    public static class Ambiente
    {


        public static bool ChecarAssinatura()
        {
            string assinatura = Program.arquivos.LerAssinatura();

            if (string.IsNullOrEmpty(assinatura))
            {
                Mensagem.Aviso("Não foi encontrado o arquivo de assinatura do sistema.");

                Telas.Prompt prompt = new Telas.Prompt(Nucleo.Base.Enumeradores.Prompt.Dado.Assinatura);

                Leiaute.Tela.ExibirPequeno(prompt);

                assinatura = prompt.controller.DadoRetornado;
            }

            if (string.IsNullOrEmpty(assinatura))
            {
                Mensagem.Alerta("Assinatura não reconhecida, o sistema será fechado.");
                return false;
            }

            try
            {
                RegistryKey? Registro = Registry.LocalMachine.OpenSubKey("NucleoAsign", true);

                if (Registro == null)
                {
                    Registro = Registry.LocalMachine.CreateSubKey("NucleoAsign", true);
                    Registro.SetValue("Asign", assinatura);
                    return true;
                }

                string? ValorCapturado = Registro?.GetValue("Asign")?.ToString();

                if(assinatura != ValorCapturado)
                {
                    Mensagem.Alerta("Assinatura não reconhecida, o sistema será fechado.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Mensagem.Erro("Erro ao registrar chave de assinatura do sistema, o sistema será fechado.", ex);
                return false;
            }

            return true;
        }

        public static bool ChecarBanco()
        {
            return true;
        }
    }
}
