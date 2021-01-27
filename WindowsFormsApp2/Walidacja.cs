using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApp2
{
    class Walidacja
    {
        static bool czyPrawidlowyEmail(String email)
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
        public async static Task<Boolean> WalidacjaEmail(TextBox textbox, ErrorProvider errorProvider)
        {
            String email = textbox.Text;
            errorProvider.SetError(textbox, "");
            if (email == "")
            {
                errorProvider.SetError(textbox, "Email jest wymagany!");
                return false;
            }
            if (!czyPrawidlowyEmail(email))
            {
                errorProvider.SetError(textbox, "Podany emial jest nieprawidłowy!");
                return false;
            }
            Boolean wynik_sprawdzania = await SprawdzenieCzyMailIstnieje(email);
            if (wynik_sprawdzania) 
            {
                errorProvider.SetError(textbox, "Podany email już istnieje!");
                return false;
            }

            return true;
        }
        async static Task<Boolean> SprawdzenieCzyMailIstnieje(String email)
        {
            String odp = await AsynchronousClient.zapytaj("sprawdz_email: " + email);
            if (odp == "false")
            {
                return false;
            }
            else 
            {
                return true;
            }
        }
        public async static Task<Boolean> WalidacjaHaslo1(TextBox textbox, ErrorProvider errorProvider)
        {
            String haslo1 = textbox.Text;
            errorProvider.SetError(textbox, "");
            if (haslo1.Length == 0)
            {
                errorProvider.SetError(textbox, "Hasło jest wymagane!");
                return false;
            }
            else if (haslo1.Length < 6)
            {
                errorProvider.SetError(textbox, "Hasło musi posiadać przynajmniej 6 znaków");
                return false;
            }
            return true;
        }
        public async static Task<Boolean> WalidacjaHaslo2(String haslo1, TextBox textbox , ErrorProvider errorProvider)
        {
            String haslo2 = textbox.Text;
            errorProvider.SetError(textbox, "");
            if (haslo2.Length == 0)
            {
                errorProvider.SetError(textbox, "Powtórz hasło!");
                return false;
            }
            else if (haslo2 != haslo1)
            {
                errorProvider.SetError(textbox, "Podane hasła muszą być takie same!");
                return false;
            }
            return true;
        }
        public async static Task<Boolean> WalidacjaLoginu(TextBox textbox, ErrorProvider errorProvider)
        {
            String login = textbox.Text;
            errorProvider.SetError(textbox, "");         
            if (login.Length ==0)
            {
                errorProvider.SetError(textbox, "Nazwa użytkownika jest wymagana!");
                return false;
            }
            Boolean wynik_sprawdzenia = await SprawdzenieCzyLoginIstnieje(login);
            if(wynik_sprawdzenia)
            {
                errorProvider.SetError(textbox, "Podany login już istnieje!");
                return false;
            }
            return true;
        }
        async static Task<Boolean> SprawdzenieCzyLoginIstnieje(String login)
        {
            String odp = await AsynchronousClient.zapytaj("sprawdz_login: " + login);
            if (odp == "false")
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public async static Task<Boolean> WalidacjaImienia(TextBox textbox, ErrorProvider errorProvider)
        {
            String imie = textbox.Text;
            errorProvider.SetError(textbox, "");
            if (imie.Length == 0)
            {
                errorProvider.SetError(textbox, "Imię jest wymagane!");
                return false;
            }
            return true;
        }
        public async static Task<Boolean> WalidacjaNazwiska(TextBox textbox, ErrorProvider errorProvider)
        {
            String nazwisko = textbox.Text;
            errorProvider.SetError(textbox, "");
            if (nazwisko.Length == 0)
            {
                errorProvider.SetError(textbox, "Nazwisko jest wymagane!");
                return false;
            }
            return true;
        }
    }
}
