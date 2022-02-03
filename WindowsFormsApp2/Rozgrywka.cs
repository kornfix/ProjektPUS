using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Rozgrywka
    {
        private static string nr_lobby = "";
        private static string przeciwnik;

        public static string Przeciwnik { get => przeciwnik; set => przeciwnik = value; }
        public static string Nr_lobby { get => nr_lobby; set => nr_lobby = value; }
    }
}
