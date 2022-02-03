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
        public static async Task<Error> WalidacjaEmail(TextBox textbox)
        {
            String email = textbox.Text;
            if (email == "")
            {
                return new Error(textbox as Control,"Email jest wymagany!");
            }
            if (!czyPrawidlowyEmail(email))
            {
                return new Error(textbox as Control, "Podany emial jest nieprawidłowy!");
            }
            if (SprawdzenieCzyMailIstnieje(email)) 
            {
                return new Error(textbox as Control, "Podany email już istnieje!");
            }
            return null;
        }
        static Boolean SprawdzenieCzyMailIstnieje(String email)
        {
            String odp = AsynchronicznyKlient.zapytaj("sprawdz_email: " + email);
            // Kontrola czy polaczono z baza danych;
            if (odp == "error" || odp == "CzasUplynal")
            {
                MessageBox.Show("Nie udane polaczenie z baza danych");
            }
            // Do zrobienia
            return odp == "True" ? true : false;
        }
        public static async Task<Error> WalidacjaEmail(String email, Control control, Control ogolna)
        {
            if (email == "")
            {
                return new Error(control, "Email jest wymagany!");
            }
            if (!czyPrawidlowyEmail(email))
            {
                return new Error(control, "Podany emial jest nieprawidłowy!");
            }
            String odp = AsynchronicznyKlient.zapytaj("sprawdz_email: " + email);
            if (odp == "error" || odp == "CzasUplynal")
            {
                return new Error(ogolna, "Nie udane polaczenie z bazą danych!");
            }
            else if (odp == "True")
            {
                return new Error(control, "Podany email już istnieje!");
            }
            return null;
        }

        public static async Task<Error> WalidacjaHaslo1(TextBox textbox)
        {
            String haslo1 = textbox.Text;
            if (haslo1.Length == 0)
            {
                return new Error(textbox as Control, "Hasło jest wymagane!");
            }
            else if (haslo1.Length < 6)
            {
                return new Error(textbox as Control, "Hasło musi posiadać przynajmniej 6 znaków");
            }
            return null;
        }
        public static async Task<Error> WalidacjaHaslo1(String haslo1, Control control)
        {
            if (haslo1.Length == 0)
            {
                return new Error(control, "Hasło jest wymagane!");
            }
            else if (haslo1.Length < 6)
            {
                return new Error(control, "Hasło musi posiadać przynajmniej 6 znaków");
            }
            return null;
        }
        public static async Task<Error> WalidacjaHaslo2(String haslo1, TextBox textbox)
        {
            String haslo2 = textbox.Text;
            if (haslo2.Length == 0)
            {
                return new Error(textbox as Control, "Powtórz hasło!");
            }
            else if (haslo2 != haslo1)
            {
                return new Error(textbox as Control, "Podane hasła muszą być takie same!");
            }
            return null;
        }
        public static async Task<Error> WalidacjaHaslo2(String haslo1, String haslo2, Control control)
        {;
            if (haslo2.Length == 0)
            {
                return new Error(control as Control, "Powtórz hasło!");
            }
            else if (haslo2 != haslo1)
            {
                return new Error(control as Control, "Podane hasła muszą być takie same!");
            }
            return null;
        }
        public static async Task<Error> WalidacjaLoginu(TextBox textbox)
        {
            String login = textbox.Text;   
            if (login.Length ==0)
            {
                return new Error(textbox as Control, "Nazwa użytkownika jest wymagana!");
            }
            if(SprawdzenieCzyLoginIstnieje(login))
            {
                return new Error(textbox as Control, "Podany login już istnieje!");
            }
            return null;
        }
        static Boolean SprawdzenieCzyLoginIstnieje(String login)
        {
            String odp = AsynchronicznyKlient.zapytaj("sprawdz_login: " + login);
            // Kontrola czy polaczono z baza danych;
            if (odp == "error" || odp == "CzasUplynal")
            {
                MessageBox.Show("Nie udane polaczenie z bazą danych!");
            }
            return odp == "True" ? true : false;
        }
        public static async Task<Error> WalidacjaLoginu(String login, Control control, Control ogolna)
        {
            if (login.Length == 0)
            {
                return new Error(control, "Nazwa użytkownika jest wymagana!");
            }
            String odp = AsynchronicznyKlient.zapytaj("sprawdz_login: " + login);
            if (odp == "error" || odp == "CzasUplynal")
            {
                return new Error(ogolna, "Nie udane polaczenie z bazą danych!");
            }
            else if (odp == "True")
            {
                return new Error(control, "Podany login już istnieje!");
            }
            return null;
        }

        public static async Task<Error> WalidacjaImienia(TextBox textbox)
        {
            String imie = textbox.Text;
            if (imie.Length == 0)
            {
                return new Error(textbox as Control, "Imię jest wymagane!");
            }
            return null;
        }
        public static async Task<Error> WalidacjaImienia(String imie, Control control)
        {
            if (imie.Length == 0)
            {
                return new Error(control, "Imię jest wymagane!");
            }
            return null;
        }
        public static async Task<Error> WalidacjaNazwiska(TextBox textbox)
        {
            String nazwisko = textbox.Text;
            if (nazwisko.Length == 0)
            {
                return new Error(textbox as Control, "Nazwisko jest wymagane!");
            }
            return null;
        }
        public static async Task<Error> WalidacjaNazwiska(String nazwisko, Control control)
        {
            if (nazwisko.Length == 0)
            {
                return new Error(control, "Nazwisko jest wymagane!");
            }
            return null;
        }
    }
}
