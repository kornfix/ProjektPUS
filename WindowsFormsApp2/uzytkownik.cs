using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class uzytkownik
    {
        private static string imie;
        private static string nazwisko;
        private static string login;
        private static string email;
        private static string nr_lobby = "";
        private static string przeciwnik;
        public static string Imie { get => imie; set => imie = value; }
        public static string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public static string Login { get => login; set => login = value; }
        public static string Email { get => email; set => email = value; }
        public static string Nr_lobby { get => nr_lobby; set => nr_lobby = value; }
        public static string Przeciwnik { get => przeciwnik; set => przeciwnik = value; }
    }
}
