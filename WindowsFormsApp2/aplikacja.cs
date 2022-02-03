using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Aplikacja
    {
        private static EdycjaUzytkownika edycjaUzytkownika;
        private static Lobby lobby;
        private static Gra ostatniaGra;
        public static EdycjaUzytkownika EdycjaUzytkownika { get => edycjaUzytkownika; set => edycjaUzytkownika = value; }
        public static Lobby Lobby { get => lobby; set => lobby = value; }
        public static Gra OstatniaGra { get => ostatniaGra; set => ostatniaGra = value; }

        public static void clear()
        {
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
