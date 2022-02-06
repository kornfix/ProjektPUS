using System;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    class Lobby
    {
        int numer;
        String status;
        Gra gra;
        Dictionary<string, bool> loginy = new Dictionary<string, bool>();
        Dictionary<string, string> sesje = new Dictionary<string, string>();
        public Lobby(int i)
        {
            this.numer = i;
            
            status = "oczekiwanie";
        }
        public int getNumer()
        {
            return numer;
        }
        public Boolean czy_jestem_w_lobby(string login, string sesja)
        {
            if(loginy.ContainsKey(login))
            {
                if (sesja.Contains(sesja)){
                    return true;
                }
                usun(login);
                return false;
            }
            return false;
        }

        public Boolean dodaj(string login, string sesja)
        {
            if (loginy.Count < 2)
            {
                this.loginy.Add(login, false);
                this.sesje.Add(login, sesja);
                return true;
            }
            return false;
        }
        // gracz to login 
        private void usun(string login)
        {
            if (loginy.ContainsKey(login))
            {
                loginy.Remove(login);
                sesje.Remove(login);
                resetGry();
            }
        }
        public Boolean usun(string login, string sesja)
        {
            if (loginy.ContainsKey(login) && sesje.ContainsKey(sesja))
            {
                loginy.Remove(login);
                sesje.Remove(login);
                resetGry();
                return true;
            }
            return false;
        }
        public Dictionary<string,bool> gracze()
        {
            return loginy;
        }
        public string login_gracza1()
        {
            return loginy.ElementAt(0).Key;
        }
        public string login_gracza2()
        {
            return loginy.ElementAt(1).Key;
        }
        public string sesja_gracza1()
        {
            return (sesje.Count == 2) ? sesje.ElementAt(0).Value : null;
        }
        public string sesja_gracza2()
        {
            return (sesje.Count ==2)? sesje.ElementAt(1).Value:null;
        }

        public Boolean czy_pelne_lobby()
        {
            return loginy.Count == 2 && sesje.Count == 2;
        }

        public void resetGry()
        {
            loginy = loginy.ToDictionary(p => p.Key, p => false);
            status = "Oczekiwanie";
            gra = null;
        }

        public Boolean gotowy(string gracz, string sesja)
        {
            if (czy_jestem_w_lobby(gracz, sesja))
            {
                loginy[gracz] = true;
                if (sprawdz_status_gry())
                {
                    rozpocznij_gre();
                }
                return true;
            }
            return false;
        }
        public Boolean niegotowy(string gracz, string sesja)
        {
            if (czy_jestem_w_lobby(gracz, sesja))
            {
                loginy[gracz] = false;
                status = "oczekuje";
                return true;
            }
            return false;
        }
        public bool sprawdz_status_gry()
        {
            if (loginy.Count == 2 && !loginy.ContainsValue(false))
            {
                status = "rozpoczynam";
                return true;
            }
            else
            {
                status = "oczekuje";
                return false;
            }
            
        }
        public void rozpocznij_gre()
        {
            gra = new Gra();
            gra.wygenerowanie_planszy();
        }
        public Dictionary<int,string> get_plansza(string login, string sesja)
        {
            if (gra != null && czy_jestem_w_lobby(login, sesja))
            {
                return gra.wygenerowanie_planszy();
            }
            return null;
        }
        public bool zapisz_ruch(string login, string sesja ,int indeks_ruchu)
        {
            if(gra != null && czy_jestem_w_lobby(login,sesja))
            {
                return gra.ZapiszRuch(indeks_ruchu);
            }
            return false;
        }
        public int[] get_wyniki_graczy(string login, string sesja)
        {
            if (gra != null && czy_jestem_w_lobby(login, sesja))
            {
                return gra.Wyniki_graczy;
            }
            return null;
        }
        public List<int> get_ruchy(string login,string sesja,int indeks)
        {
            if(gra!=null && czy_jestem_w_lobby(login, sesja))
            {
                return gra.WczytajRuchy(indeks);
            }
            return null;
        }
        public void usun_gre()
        {
            gra = null;
        }
        public bool czy_koniec_gry()
        {
            return gra == null;
        }
        /*
        public void resetujGre()
        {
            foreach (var item in loginy)
            {
                loginy[item.Key] = false;
                //item.Value = false;
            }

            status = "Czekam";
        }
        */
    }
}
