using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Server
{
    class Gra
    {
        // Tablica
        private int rozmiar;
        private Dictionary<int, string> TablicaGry;

        // Ruchy 
        private Dictionary<int, int> ruchy = new Dictionary<int, int>();
        private int licznik_ruchow;
        private string ostatni_ruch;

        // Generacja elementów w talbicy
        private List<string> icons = new List<string>();
        Random rnd = new Random();

        // Gracze
        private bool czy_pierwszy;
        private int[] wyniki_graczy = new int[2];

        public int[] Wyniki_graczy { get => wyniki_graczy; set => wyniki_graczy = value; }

        public Gra()
        {
            licznik_ruchow = 0;
            ostatni_ruch = "";
            wyniki_graczy[0] = 0;
            wyniki_graczy[1] = 0;
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
            List<string> wylosowane = new List<string>();
            while (wylosowane.Count < ile)
            {
                string znak = znaki[rnd.Next(znaki.Length)].ToString();
                if (!wylosowane.Contains(znak))
                {
                    wylosowane.Add(znak);
                    icons.Add(znak);
                    icons.Add(znak);
                }
            }
        }


        public bool ZapiszRuch(int indeks_ruchu)
        {
            if (indeks_ruchu >= 0 && indeks_ruchu < TablicaGry.Count)
            {
                ruchy.Add(++licznik_ruchow, indeks_ruchu);
                if (ruchy.Count % 2 == 0)
                {
                    if (ostatni_ruch.Equals(TablicaGry[indeks_ruchu]))
                    {
                        wyniki_graczy[czy_pierwszy ? 0 : 1] += 10;
                    }
                    else
                    {
                        czy_pierwszy = !czy_pierwszy;
                    }
                }
                ostatni_ruch = TablicaGry[indeks_ruchu];
                return true;
            }
            return false;
        }
        public List<int> WczytajRuchy(int indeks)
        {
            return ruchy.Where(k => k.Key > indeks)
                .Select( m => m.Value).ToList();
        }
        public Dictionary<int, string> wygenerowanie_planszy()
        {
            if (TablicaGry== null)
            {
                TablicaGry = new Dictionary<int, string>();
                int randomNumber;
                int ile = icons.Count;
                for (int i = 0; i < ile; i++)
                {
                    randomNumber = rnd.Next(0, icons.Count);
                    TablicaGry.Add(i, icons[randomNumber]);
                    Console.WriteLine(i + " " + icons[randomNumber]);
                    icons.RemoveAt(randomNumber);
                }
            }
            return TablicaGry;
        }
    }
}
