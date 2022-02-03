using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
        async void zalogowanieUzytkownika(string odp)
        {
            String[] slowa = odp.Split(' ');
            // prosba udana 
            if (slowa.Length == 5)
            {
                Uzytkownik.Imie = slowa[0];
                Uzytkownik.Nazwisko = slowa[1];
                Uzytkownik.Login = slowa[2];
                Uzytkownik.Email = slowa[3];
                Uzytkownik.Sesja = slowa[4];
                menu.tryb_menu();
            }
            // prosba nieudana
            else if (slowa.Length == 1 && slowa[0] == "bledneDane")
            {
                menu.tryb_logowanie();
                lb_ogolny.Text = "Nie poprawny login lub hasło!";
                lb_ogolny.Visible = true;
                errorProvider1.SetError(lb_ogolny, "Nie poprawny login lub hasło!");
            }
            else if (slowa.Length == 1 && slowa[0] == "uzytkownik_jest_juz_zalogowany")
            {
                DialogResult dialogResult = MessageBox.Show("Powyższy użytkownik jest już zalogowany! Czy chcesz wymusić jego wylogowanie?", "Logowanie", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    String wyl = AsynchronicznyKlient.zapytaj("wyloguj: " + textBoxLogin1.Text);
                    if (wyl == "True")
                    {
                        String zaloguj = AsynchronicznyKlient.zapytaj("zaloguj: " + textBoxLogin1.Text + " " + textBoxHaslo1.Text);
                        if (zaloguj == "CzasUplynal" || zaloguj == "error")
                        {
                            lb_ogolny.Text = "Nie udane połączenie z serwerem!";
                            lb_ogolny.Visible = true;
                            errorProvider1.SetError(lb_ogolny, "Nie udane połączenie z serwerem!"); ;
                        }
                        else
                        {
                            zalogowanieUzytkownika(zaloguj);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nie udana próba wylogowania");
                        menu.tryb_logowanie();
                    }
                }
                else
                {
                    menu.tryb_logowanie();
                }
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
                //menu.tryb_czekanie();
                // Zapytanie do serwera z tym stringiem
                e.Result = AsynchronicznyKlient.zapytaj("zaloguj: " + textBoxLogin1.Text + " " + textBoxHaslo1.Text);
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
                String odp = e.Result.ToString();
                if (odp =="CzasUplynal" || odp == "error")
                {
                    lb_ogolny.Text = "Nie udane połączenie z serwerem!";
                    lb_ogolny.Visible = true;
                    errorProvider1.SetError(lb_ogolny, "Nie udane połączenie z serwerem!");
                }
                else 
                {
                    zalogowanieUzytkownika(e.Result.ToString());
                }
            }
            
        }
    }
}
