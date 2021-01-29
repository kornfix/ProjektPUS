using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace WindowsFormsApp2
{
    public partial class UC_rejestracja : UserControl
    {
        private Menu menu = null;
        public UC_rejestracja(Form form)
        {
            menu = form as Menu;
            InitializeComponent();
        }
        private async void button_anuluj_Click(object sender, EventArgs e)
        {
            menu.tryb_logowanie();
        }
        async Task rejestracja()
        {
            
            // Kod walidacyjny
            var walidacjaEmail = Walidacja.WalidacjaEmail(txt_email, errorProvider1);
            var walidacjaHaslo1 = Walidacja.WalidacjaHaslo1(txt_haslo1,errorProvider1);
            var walidacjaHaslo2 = Walidacja.WalidacjaHaslo2(txt_haslo1.Text, txt_haslo2, errorProvider1);
            var walidacjaLoginu = Walidacja.WalidacjaLoginu(txt_login,errorProvider1);
            var walidacjaImienia = Walidacja.WalidacjaImienia(txt_imie , errorProvider1);
            var walidacjaNazwiska = Walidacja.WalidacjaNazwiska(txt_nazwisko , errorProvider1);
            Task[] zadania = new Task[] { walidacjaEmail, walidacjaHaslo1, walidacjaHaslo2, walidacjaLoginu, walidacjaImienia, walidacjaNazwiska };
            menu.tryb_czekanie();
            await Task.WhenAll(zadania);
            aplikacja.wait(1000);
            if (!walidacjaEmail.Result || !walidacjaHaslo1.Result || !walidacjaHaslo2.Result ||
                !walidacjaLoginu.Result || !walidacjaImienia.Result || !walidacjaNazwiska.Result)
            {
                menu.tryb_rejestracja();
                return;
            }
            string email = " email:" + txt_email.Text;
            string haslo = " haslo:" + txt_haslo1.Text;
            string login = " login:" + txt_login.Text;
            string imie = " imie:" + txt_imie.Text;
            string nazwisko = " nazwisko:" + txt_nazwisko.Text;
            // Kod wyslania prośby do serwera
            // oczekiwanie prośby
            String odp = await AsynchronicznyKlient.zapytaj("zarejestruj_uzytkownika: " + email + haslo + login
                + imie + nazwisko);
            // prosba udana 
            if (odp == "true")
            {
                aplikacja.Imie = txt_imie.Text;
                aplikacja.Nazwisko = txt_nazwisko.Text;
                aplikacja.Login = txt_login.Text;
                aplikacja.Email = txt_email.Text;
                menu.tryb_menu();
                menu.reset_rejestacji();
            }
            // logowanie do menu
            //menu.tryb_menu();
            // prośba nie udana wyświetlenie inf
        }

        private async void button_rejestracja_Click(object sender, EventArgs e)
        {
            var r = rejestracja(); 
        }      
        bool czyPrawidlowyEmail(String email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        async Task<Boolean> WalidacjaEmail()
        {
            // Await sprawdza czy na serio te funkcje sie wykonuja jednoczenie gdyz delay powoduje ze ta funckja czeka 5 sec
            //await Task.Delay(5000);
            String email = txt_email.Text;
            errorProvider1.SetError(txt_email, "");
            if (email == "")
            {
                errorProvider1.SetError(txt_email, "Email jest wymagany!");
                return false;
            }
            if (!czyPrawidlowyEmail(email))
            {
                errorProvider1.SetError(txt_email, "Podany emial jest nieprawidłowy!");
                return false;
            }
            Boolean wynik_sprawdzania = await SprawdzenieCzyMailIstnieje(email);
            if (wynik_sprawdzania) 
            {
                errorProvider1.SetError(txt_email, "Podany email już istnieje!");
                return false;
            }

            return true;
        }
        async Task<Boolean> SprawdzenieCzyMailIstnieje(String email)
        {
            String odp = await AsynchronicznyKlient.zapytaj("sprawdz_email: " + email);
            if (odp == "false")
            {
                return false;
            }
            else 
            {
                return true;
            }
        }
        async Task<Boolean> WalidacjaHaslo1()
        {
            String haslo1 = txt_haslo1.Text;
            errorProvider1.SetError(txt_haslo1, "");
            if (haslo1.Length == 0)
            {
                errorProvider1.SetError(txt_haslo1,"Hasło jest wymagane!");
                return false;
            }
            else if (haslo1.Length < 6)
            {
                errorProvider1.SetError(txt_haslo1, "Hasło musi posiadać przynajmniej 6 znaków");
                return false;
            }
            return true;
        }
        async Task<Boolean> WalidacjaHaslo2()
        {
            String haslo1 = txt_haslo1.Text;
            String haslo2 = txt_haslo2.Text;
            errorProvider1.SetError(txt_haslo2, "");
            if (haslo2.Length == 0)
            {
                errorProvider1.SetError(txt_haslo2, "Powtórz hasło!");
                return false;
            }
            else if (haslo2 != haslo1)
            {
                errorProvider1.SetError(txt_haslo2, "Podane hasła muszą być takie same!");
                return false;
            }
            return true;
        }
        async Task<Boolean> WalidacjaLoginu()
        {
            String login = txt_login.Text;
            errorProvider1.SetError(txt_login, "");         
            if (login.Length ==0)
            {
                errorProvider1.SetError(txt_login,"Nazwa użytkownika jest wymagana!");
                return false;
            }
            Boolean wynik_sprawdzenia = await SprawdzenieCzyLoginIstnieje(login);
            if(wynik_sprawdzenia)
            {
                errorProvider1.SetError(txt_login, "Podany login już istnieje!");
                return false;
            }
            return true;
        }
        async Task<Boolean> SprawdzenieCzyLoginIstnieje(String login)
        {
            String odp = await AsynchronicznyKlient.zapytaj("sprawdz_login: " + login);
            if (odp == "false")
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        async Task<Boolean> WalidacjaImienia()
        {
            String imie = txt_imie.Text;
            errorProvider1.SetError(txt_imie, "");
            if (imie.Length == 0)
            {
                errorProvider1.SetError(txt_imie, "Imię jest wymagane!");
                return false;
            }
            return true;
        }
        async Task<Boolean> WalidacjaNazwiska()
        {
            String nazwisko = txt_nazwisko.Text;
            errorProvider1.SetError(txt_nazwisko, "");
            if (nazwisko.Length == 0)
            {
                errorProvider1.SetError(txt_nazwisko, "Nazwisko jest wymagane!");
                return false;
            }
            return true;
        }
    }
}
