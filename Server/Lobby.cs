using System;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    class Lobby
    {
        int numer;
        // gracz1 i gracz2 to loginy
        Dictionary<string, bool> loginy;
        String status = "oczekiwanie";
        public Lobby(int i)
        {
            this.numer = i;
            loginy = new Dictionary<string, bool>();
        }
        public int getNumer()
        {
            return numer;
        }
        public Boolean czy_jestem_w_lobby(string gracz)
        {
            if (loginy.ContainsKey(gracz))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean dodaj(string gracz)
        {
            if (loginy.Count < 2)
            {
                loginy.Add(gracz, false);
                return true;
            }
            return false;
        }
        // gracz to login 
        public Boolean usun(string gracz)
        {
            if (loginy.ContainsKey(gracz))
            {
                loginy.Remove(gracz);
            }
            return false;
        }
        public string gracze()
        {
            int i = 0;
            string odp = "";
            foreach (var item in loginy)
            {
                i++;
                odp += "g" + i + ":" + item.Key + " ";
            }
            sprawdz_status_gry();
            odp += "status:" + status;
            return odp;
        }
        public string Gracz1()
        {
            return loginy.ElementAt(0).Key;
        }
        public string Gracz2()
        {
            return loginy.ElementAt(1).Key;
        }
        public Boolean czy_pelne_lobby()
        {
            if (loginy.Count == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void resetGry()
        {
            loginy = loginy.ToDictionary(p => p.Key, p => false);
            status = "Oczekiwanie";
        }

        public Boolean gotowy(string gracz)
        {
            loginy[gracz] = true;
            return true;
        }
        public Boolean niegotowy(string gracz)
        {
            loginy[gracz] = false;
            return false;
        }
        public void sprawdz_status_gry()
        {
            if (loginy.Count == 2 && !loginy.ContainsValue(false))
            {
                status = "rozpoczynam";
            }else
            {
                status = "oczekuje";
            }
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
