using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public class aplikacja
    {
        private static string sesja;
        private static string imie;
        private static string nazwisko;
        private static string login;
        private static string email;
        private static string nr_lobby = "";
        private static string przeciwnik;
        private static EdycjaUzytkownika edycjaUzytkownika;
        private static Lobby lobby;
        private static Gra ostatniaGra;

        public static string Imie { get => imie; set => imie = value; }
        public static string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public static string Login { get => login; set => login = value; }
        public static string Email { get => email; set => email = value; }
        public static string Nr_lobby { get => nr_lobby; set => nr_lobby = value; }
        public static string Przeciwnik { get => przeciwnik; set => przeciwnik = value; }
        public static string Sesja { get => sesja; set => sesja = value; }
        public static EdycjaUzytkownika EdycjaUzytkownika { get => edycjaUzytkownika; set => edycjaUzytkownika = value; }
        public static Lobby Lobby { get => lobby; set => lobby = value; }
        public static Gra OstatniaGra { get => ostatniaGra; set => ostatniaGra = value; }

        public static void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
        public static void clear()
        {
            imie = "";
            nazwisko = "";
            login = "";
            email = "";
            nr_lobby = "";
            przeciwnik = "";
            sesja = "";
            if (Lobby != null)
            {
                Lobby.Zakoncz();
                Lobby.Close();
            }
            if (ostatniaGra != null)
            {
                ostatniaGra.Close();
            }
            if (EdycjaUzytkownika != null)
            {
                EdycjaUzytkownika.Close();
            }


        }
    }
}
