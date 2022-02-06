using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Pytanie
    {
        public enum komendy
        {
            sprawdz_email,
            sprawdz_login,
            zarejestruj_uzytkownika,
            zaloguj,
            wyloguj,
            wielkosc_lobby,
            dodaj_gracza_do_lobby,
            usun_gracz_z_lobby,
            gracze_z_lobby,
            czy_pelne_lobby,
            jestem_gotowy,
            niejestem_gotowy,
            pobierz_plansze,
            zapisz_ruch,
            wczytaj_ruchy,
            uzyt_wartosc_parametru,
            uzyt_zm_par,
            sesja,
            zakoncz_gre,
            czy_koniec_gry
        }
        private string sesja;
        private komendy komenda;
        private object[] argumenty;

        public object[] Argumenty { get => argumenty; set => argumenty = value; }
        public string Sesja { get => sesja; set => sesja = value; }
        public komendy Komenda { get => komenda; set => komenda = value; }
    }
}
