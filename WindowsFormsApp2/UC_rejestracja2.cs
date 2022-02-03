using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class UC_rejestracja2 : UserControl
    {
        private Menu menu = null;
        private List<Task<Error>> zadania = new List<Task<Error>>();
        public UC_rejestracja2(Form form)
        {
            menu = form as Menu;
            InitializeComponent();
        }

        private void button_anuluj_Click(object sender, EventArgs e)
        {
            menu.reset_rejestacji();
            menu.tryb_logowanie();
        }

        private void button_rejestracja_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            lb_imie.Visible = false;
            lb_nazwisko.Visible = false;
            lb_email.Visible = false;
            lb_login.Visible = false;
            lb_haslo1.Visible = false;
            lb_haslo2.Visible = false;
            lb_ogolny.Visible = false;
            if (backgroundWorker1.IsBusy != true)
            {
                menu.tryb_czekanie();
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Kod walidacyjny
            zadania.Clear();
            var walidacjaEmail = Walidacja.WalidacjaEmail(txt_email.Text, lb_email, lb_ogolny);
            zadania.Add(walidacjaEmail);
            var walidacjaLoginu = Walidacja.WalidacjaLoginu(txt_login.Text, lb_login, lb_ogolny);
            zadania.Add(walidacjaLoginu);
            var walidacjaHaslo1 = Walidacja.WalidacjaHaslo1(txt_haslo1.Text, lb_haslo1);
            zadania.Add(walidacjaHaslo1);
            var walidacjaHaslo2 = Walidacja.WalidacjaHaslo2(txt_haslo1.Text, txt_haslo2.Text, lb_haslo2);
            zadania.Add(walidacjaHaslo2); 
            var walidacjaImienia = Walidacja.WalidacjaImienia(txt_imie.Text, lb_imie);
            zadania.Add(walidacjaImienia);
            var walidacjaNazwiska = Walidacja.WalidacjaNazwiska(txt_nazwisko.Text,lb_nazwisko);
            zadania.Add(walidacjaNazwiska);
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
                string email = " email:" + txt_email.Text;
                string haslo = " haslo:" + txt_haslo1.Text;
                string login = " login:" + txt_login.Text;
                string imie = " imie:" + txt_imie.Text;
                string nazwisko = " nazwisko:" + txt_nazwisko.Text;
                // Kod wyslania prośby do serwera
                // oczekiwanie prośby
                String odp = AsynchronicznyKlient.zapytaj("zarejestruj_uzytkownika: " + email + haslo + login
                    + imie + nazwisko);

                if (odp == "CzasUplynal" || odp == "error")
                {
                    // problem z serwerem udana 
                    MessageBox.Show("Nie udane wyjscie z gry");
                }
                else
                {
                    // prosba udana 
                    e.Result = odp;
                }
                // logowanie do menu
                //menu.tryb_menu();
                // prośba nie udana wyświetlenie inf
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.ToString(), "Problem");
            }
            else if (e.Cancelled)
            {
                foreach (Task<Error> task in zadania)
                {
                    if (task.Result != null)
                    {
                        Error error = task.Result;
                        error.Control.Visible = true;
                        error.Control.Text = error.Tresc;
                        errorProvider1.SetError(error.Control, error.Tresc);
                    }
                }
                menu.tryb_rejestracja();
            }
            else if (e.Result != null)
            {
                if (e.Result.ToString() == "true")
                {
                    Uzytkownik.Imie = txt_imie.Text;
                    Uzytkownik.Nazwisko = txt_nazwisko.Text;
                    Uzytkownik.Login = txt_login.Text;
                    Uzytkownik.Email = txt_email.Text;
                    menu.tryb_menu();
                    menu.reset_rejestacji();
                }
                else
                {
                    MessageBox.Show("Nie udana rejestracja!");
                }
            }
        }
    }
}
