using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Lobby
    {
        int numer;
        // gracz1 i gracz2 to loginy
        Dictionary<string, bool> loginy;
        String status="oczekiwanie na graczy";
        public Lobby(int i)
        {
            this.numer = i;
            loginy = new Dictionary<string, bool>();
        }
        public Boolean czy_jestem_w_lobby(string gracz)
        {
            if(loginy.ContainsKey(gracz))
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
            if(loginy.Count <2)
            {
                loginy.Add(gracz, false);
                return true;
            }
            return false;
        }
       // gracz to login 
        public Boolean usun(string gracz)
        {
            if(loginy.ContainsKey(gracz))
            {
                loginy.Remove(gracz);
            }
            return false;
        }
        public string gracze()
        {
            int i = 0;
            string odp = "";
            foreach(var item in loginy)
            {
                i++;
                odp += "g" + i + ":" + item.Key+" ";
            }
            odp += "status:" + status;
            return odp;
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
            if(!loginy.ContainsValue(false))
            {
                status = "rozpoczynam gre";
            }
        }
    }
}
