using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

namespace WindowsFormsApp2
{
    public partial class UC_logowanie : UserControl
    {
        private Menu menu = null;
        private List<Task<Error>> zadania = new List<Task<Error>>();

        public UC_logowanie(Form form)
        {
            menu = form as Menu;
            InitializeComponent();
        }

        private async void buttonZaloguj_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            lb_ogolny.Visible = false;
            if (!bg_logowanie.IsBusy)
            {
                bg_logowanie.RunWorkerAsync();
            }
        }
        async void zalogowanieUzytkownika(string odp)
        {
            // prosba nieudana
            if (odp.Equals("bledneDane"))
            {
                menu.tryb_logowanie();
                lb_ogolny.Text = "Nie poprawny login lub hasło!";
                lb_ogolny.Visible = true;
                errorProvider1.SetError(lb_ogolny, "Nie poprawny login lub hasło!");
            }
            else if (odp.Equals("uzytkownik_jest_juz_zalogowany"))
            {
                DialogResult dialogResult = MessageBox.Show("Powyższy użytkownik jest już zalogowany! Czy chcesz wymusić jego wylogowanie?", "Logowanie", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if(!bg_wylogowywanie.IsBusy)
                    {
                        bg_wylogowywanie.RunWorkerAsync();
                    }
                }
                else
                {
                    menu.tryb_logowanie();
                }
            }else
            {
                Uzytkownik.Instance = JsonSerializer.Deserialize<Uzytkownik>(odp);
                menu.tryb_menu();
            }
        }

        private void button_rejestracja_Click(object sender, EventArgs e)
        {
            menu.tryb_rejestracja();
        }

        async Task<Error> WalidacjaLoginu()
        {
            if (textBoxLogin1.Text.Length == 0)
            {
                return new Error(textBoxLogin1, "Nie podano loginu!");
            }
            return null;
        }
        async Task<Error> WalidacjaHasla()
        {
            if (textBoxHaslo1.Text.Length == 0)
            {
                return new Error(textBoxHaslo1,"Nie podano hasła!");
            }
            return null;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            zadania.Clear();
            var walidacjaLoginu = WalidacjaLoginu();
            zadania.Add(walidacjaLoginu);
            var walidacjaHasla = WalidacjaHasla();
            zadania.Add(walidacjaHasla);
            Task.WaitAll(zadania.ToArray());
            Boolean udanaWalidacja = true;
            foreach (Task<Error> task in zadania)
            {
                if (task.Result != null)
                {
                    e.Cancel = true;
                    udanaWalidacja = false;
                    break;
                }
            }
            if (udanaWalidacja)
            {      
                e.Result = AsynchronicznyKlient.zapytaj(Pytanie.komendy.zaloguj, 
                    new object[] {textBoxHaslo1.Text, textBoxLogin1.Text });
            }
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            if (e.Error != null )
            {
                MessageBox.Show(e.Error.ToString());
                return;
            }else if (e.Cancelled)
            {
                foreach (Task<Error> task in zadania)
                {
                    if (task.Result != null)
                    {
                        Error error = task.Result;
                        errorProvider1.SetError(error.Control, error.Tresc);
                    }
                }
                return;
            }         
            if (e.Result != null)
            {
                Odpowiedz odp = (Odpowiedz) e.Result;
                if (odp.czy_wzrocono_error())
                {
                    lb_ogolny.Text = "Nie udane połączenie z serwerem!";
                    lb_ogolny.Visible = true;
                    errorProvider1.SetError(lb_ogolny, "Nie udane połączenie z serwerem!");
                }
                else 
                {
                    zalogowanieUzytkownika(odp.Argumenty[0].ToString());
                }
            }
            
        }

        private void bg_wylogowywanie_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = AsynchronicznyKlient.zapytaj(Pytanie.komendy.wyloguj,
                new object[] { textBoxLogin1.Text});

        }

        private void bg_wylogowywanie_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Walidacja.czy_bledy(e))
            {
                Odpowiedz odp = (Odpowiedz)e.Result;
                if (odp.czy_wzrocono_error())
                {
                    if ((bool)odp.Argumenty[0])
                    {
                        if (!bg_logowanie.IsBusy)
                        {
                            bg_logowanie.RunWorkerAsync();
                        }
                    }
                    else
                    {
                        lb_ogolny.Text = "Nie udane połączenie z serwerem!";
                        lb_ogolny.Visible = true;
                        errorProvider1.SetError(lb_ogolny, "Nie udane połączenie z serwerem!");
                    }
                }
            }
        }
    }
}
