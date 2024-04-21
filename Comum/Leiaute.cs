using GerarEtiquetas.Comum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GerarEtiquetas.Forms.Comum
{
    public static class Leiaute
    {
        public static partial class TextBox
        {
            public static void KeyPress(object? sender, System.Windows.Forms.KeyPressEventArgs e)
            {
                if (Conversor.EnterToTab(e.KeyChar))
                    e.Handled = true;
            }

            public static void KeyPress_Decimal(object? sender, System.Windows.Forms.KeyPressEventArgs e)
            {
                if (Conversor.EnterToTab(e.KeyChar))
                    e.Handled = true;
            }

            public static void KeyPress_Data(object? sender, System.Windows.Forms.KeyPressEventArgs e)
            {
                System.Windows.Forms.TextBox? obj = (System.Windows.Forms.TextBox?)sender;

                if (Conversor.EnterToTab(e.KeyChar))
                    e.Handled = true;

                if (e.KeyChar != (char)Keys.Back)
                {
                    if (obj?.Text.Length == 2 || obj?.Text.Length == 5)
                    {
                        obj.Text += "/";
                        obj.SelectionStart = obj.Text.Length + 1;
                    }
                }
            }

            public static void KeyPress_Integer(object? sender, System.Windows.Forms.KeyPressEventArgs e)
            {
                if (Conversor.EnterToTab(e.KeyChar))
                    e.Handled = true;

                if (e.KeyChar != (char)Keys.Back)
                        e.Handled = !double.TryParse(e.KeyChar.ToString(), NumberStyles.Any, new CultureInfo("pt-BR"), out _);
            }

            public static void KeyDown(object? sender, System.Windows.Forms.KeyEventArgs e)
            {
                throw new NotImplementedException();
            }

            public static void LostFocus(object? sender, EventArgs e)
            {
                throw new NotImplementedException();
            }

            public static void LostFocus_Data(object? sender, EventArgs e)
            {
                System.Windows.Forms.TextBox? obj = (System.Windows.Forms.TextBox?)sender;

                if (obj == null)
                    return;

                if (string.IsNullOrWhiteSpace(obj.Text)) return;
                if (obj.Text == "__/__/____") return;

                DateTime date;

                if (DateTime.TryParse(obj.Text.Trim(), new CultureInfo("pt-BR"), DateTimeStyles.None, out date))
                    obj.Text = date.ToString("dd/MM/yyyy");
                else
                {
                    Mensagem.Alerta("Data inválida!");

                    obj.Text = "";
                    obj.Focus();
                }
            }
        }

        public static partial class ComboBox
        {

        }

        public static partial class Tela
        {
            public static void Carregar(System.Windows.Forms.Form e)
            {
                e.ForeColor = System.Drawing.Color.DarkBlue;
                e.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            }

            public static void Tamanho(System.Windows.Forms.Form e, Tamanhos tamanho)
            {
                if (tamanho == Tamanhos.Pequeno)
                {
                    e.Width = 600;
                    e.Height = 400;
                }
                else if (tamanho == Tamanhos.Medio)
                {
                    e.Width = 820;
                    e.Height = 420;
                }
                else if (tamanho == Tamanhos.Grande)
                {
                    e.Width = 1080;
                    e.Height = 720;
                }
            }

            public static void Exibir(System.Windows.Forms.Form e)
            {
                Carregar(e);
                e.ShowDialog();
            }

            public static void ExibirPequeno(System.Windows.Forms.Form e)
            {
                Carregar(e);
                Tamanho(e, Tamanhos.Pequeno);
                e.ShowDialog();
            }

            public static void ExibirMedio(System.Windows.Forms.Form e)
            {
                Carregar(e);
                Tamanho(e, Tamanhos.Medio);
                e.ShowDialog();
            }

            public static void ExibirMedioMaximizado(System.Windows.Forms.Form e)
            {
                e.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                ExibirMedio(e);
            }

            public static void ExibirGrande(System.Windows.Forms.Form e)
            {
                Carregar(e);
                Tamanho(e, Tamanhos.Grande);
                e.ShowDialog();
            }

            public enum Tamanhos
            {
                Pequeno = 1,
                Medio = 2,
                Grande = 3,
            }
        }
    }
}
