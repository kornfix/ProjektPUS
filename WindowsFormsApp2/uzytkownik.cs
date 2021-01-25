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
        public static string Imie { get => imie; set => imie = value; }
        public static string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public static string Login { get => login; set => login = value; }
        public static string Email { get => email; set => email = value; }
    }
}
