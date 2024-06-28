using DocumentFormat.OpenXml.Spreadsheet;
using GerarEtiquetas.Comum;
using GerarEtiquetas.Forms.Comum;
using System.Diagnostics;
using static System.Windows.Forms.AxHost;

namespace GerarEtiquetas
{
    internal static class Program
    {
        public static Ambiente Ambiente = new();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew = true;

            using (Mutex mutex = new Mutex(true, "GerarEtiquetas", out createdNew))
            {
                if (createdNew)
                {
                    ApplicationConfiguration.Initialize();

                    ////Application.SetHighDpiMode(HighDpiMode.SystemAware);
                    //Application.EnableVisualStyles();
                    //Application.SetCompatibleTextRenderingDefault(false);

                    Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
                    AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                    Iniciar();
                }
                else
                {
                    Program.Exit();
                }
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(Iniciar());
        }

        public static void Iniciar()
        {
            try
            {
                Comum.Ambiente.ChecarAssinaturaRepresentante();

                if (!Comum.Ambiente.ChecarAssinatura())
                    Program.Exit();

                if(!Comum.Ambiente.ChecarBanco())
                    Program.Exit();

                Ambiente.Configuracao = Comum.Ambiente.Configurar();

                Application.Run(new GerarEtiquetas.Forms.Telas.GerarEtiqueta());
            }
            catch (Exception ex)
            {
                Mensagem.Erro("Erro ao iniciar o sistema.", ex, true);
                throw;
            }
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            // Log the exception, display it, etc

            Debug.WriteLine("Application_ThreadException");
            Debug.WriteLine(e.Exception.Message);

            //MessageBox.Show(e.Exception.Message);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // Log the exception, display it, etc

            Debug.WriteLine("CurrentDomain_UnhandledException");
            Debug.WriteLine((e.ExceptionObject as Exception)?.Message);

            //MessageBox.Show((e.ExceptionObject as Exception).Message);
        }

        public static void Exit(bool hasError = false)
        {
            System.Windows.Forms.Application.Exit();

            if (hasError)
                System.Environment.Exit(1);
            else
                System.Environment.Exit(0);
        }
    }
}