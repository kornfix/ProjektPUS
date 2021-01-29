using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Server
{
    class Gra
    {
        private string aktualnie_wybierajacy;
        private int rozmiar;
        private Lobby lobby;
        private int i = 0;
        private Dictionary<int, string> ruchy = new Dictionary<int, string>();
        List<string> icons = new List<string>();
        /*
        {
            "!", "!", "N", "N", ",", ",", "k", "k", "b", "b", "v", "v", "w", "w", "z", "z"
        };
        */
        private string gracz1;
        private string gracz2;
        private string WylosowanaTablica = "";
        Random rnd = new Random();
        public Gra(Lobby lobby)
        {
            this.lobby = lobby;
            gracz1 = lobby.Gracz1();
            gracz2 = lobby.Gracz2();
            rozmiar = 4; // zawsze musibyć  rozmiar*rozmiar % 2 == 0
            generujIcony();
        }
        private void generujIcony()
        {
            string znaki = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            int ile = rozmiar * rozmiar / 2;
            while (ile % 2 != 0)
            {
                rozmiar++;
                ile = rozmiar * rozmiar / 2;
            }
            for (int i = 0; i < ile; i++)
            {
                string znak = znaki[rnd.Next(znaki.Length)].ToString();
                Console.WriteLine(znak);
                znaki.Replace(znak, "");
                icons.Add(znak);
                icons.Add(znak);
            }

        }


        public void ZapiszRuch(string ruch)
        {
            ruchy.Add(++i, ruch);
        }
        public string WczytajRuchy(string indeks)
        {
            string odp = "";
            int liczba = Int32.Parse(indeks);
            foreach (var item in ruchy)
            {
                if (item.Key > liczba)
                {
                    odp += item.Value + " ";
                }
            }
            if(!lobby.czy_pelne_lobby())
            {
                odp += "koniec";
            }
            return odp;
        }

        public void negacjaGraczow()
        {
            if (aktualnie_wybierajacy == gracz1)
            {
                aktualnie_wybierajacy = gracz2;
            }
            else if (aktualnie_wybierajacy == gracz2)
            {
                aktualnie_wybierajacy = gracz1;
            }
        }

        public string WylosowaniePlanszy()
        {
            if (WylosowanaTablica == "")
            {
                int randomNumber;
                int ile = icons.Count;
                for (int i = 0; i < ile; i++)
                {
                    randomNumber = rnd.Next(0, icons.Count);
                    if (i == ile - 1)
                    {
                        WylosowanaTablica += icons[randomNumber];
                    }
                    else
                    {
                        WylosowanaTablica += icons[randomNumber] + " ";
                    }
                    icons.RemoveAt(randomNumber);
                }
            }
            aktualnie_wybierajacy = gracz1;
            return rozmiar + " " + gracz1 + " " + WylosowanaTablica;
        }
    }
}
