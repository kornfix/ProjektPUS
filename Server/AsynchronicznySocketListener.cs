using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    public class AsynchronicznySocketListener
    {
        private static int liczba_lobby = 5;
        private static Dictionary<string, Lobby> slownik_lobby;
        private static Dictionary<string, uzytkownicy> gracze = new Dictionary<string, uzytkownicy>();
        private static Dictionary<string, string> aktywne_sesje = new Dictionary<string, string>();
        private static List<string> zapytania = new List<string>();
        private static Dictionary<string, Gra> aktywne_gry = new Dictionary<string, Gra>();
        public static ManualResetEvent wszystkoWykonane = new ManualResetEvent(false);

        public AsynchronicznySocketListener()
        {

        }
        static void wczytaj_lobby()
        {
            slownik_lobby = new Dictionary<string, Lobby>();
            for (int i = 1; i <= liczba_lobby; i++)
            {
                slownik_lobby.Add(i.ToString(), new Lobby(i));
            }
        }
        public static void StartSerwera()
        {
            wczytaj_lobby();
            IPAddress ipAddress = IPAddress.IPv6Any;
            IPEndPoint lokalnyPK = new IPEndPoint(ipAddress, 11000);
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listener.Bind(lokalnyPK);
                listener.Listen(100);
                while (true)
                {
                    wszystkoWykonane.Reset();
                    listener.BeginAccept(
                        new AsyncCallback(Callback),
                        listener);
                    wszystkoWykonane.WaitOne();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public static void Callback(IAsyncResult ar)
        {
            wszystkoWykonane.Set();
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);
            StanObiektu stan = new StanObiektu();
            stan.socket = handler;
            handler.BeginReceive(stan.buffer, 0, StanObiektu.rozmiarBuffera, 0,
                new AsyncCallback(WczytajCallback), stan);
        }
        public static void WczytajCallback(IAsyncResult ar)
        {
            String zawartosc = String.Empty;
            StanObiektu stan = (StanObiektu)ar.AsyncState;
            Socket handler = stan.socket;

            int bajtyPrzeczytane = handler.EndReceive(ar);

            if (bajtyPrzeczytane > 0)
            {
                stan.sb.Append(Encoding.ASCII.GetString(
                    stan.buffer, 0, bajtyPrzeczytane));

                zawartosc = stan.sb.ToString();
                if (zawartosc.IndexOf("<EOF>") > -1)
                {
                    string[] slowa = zawartosc.Split(' ');
                    string odpowiedz = "error";
                    // Kod który wczytuje wysłaną wiadomośc i odpowiada.
                    if (slowa.Length >= 2)
                    {

                        switch (slowa[0])
                        {
                            case "sprawdz_email:":
                                var q_e = from uzytkownik in SingletonBaza.Instance.BazaDC.uzytkownicies
                                          where uzytkownik.email == slowa[1]
                                          select uzytkownik;
                                if (q_e.Any())
                                {
                                    odpowiedz = "true";

                                }
                                else
                                {
                                    odpowiedz = "false";
                                }
                                break;
                            case "sprawdz_login:":
                                var q_l = from uzytkownik in SingletonBaza.Instance.BazaDC.uzytkownicies
                                          where uzytkownik.login == slowa[1]
                                          select uzytkownik;
                                if (q_l.Any())
                                {
                                    odpowiedz = "true";

                                }
                                else
                                {
                                    odpowiedz = "false";
                                }
                                break;
                            case "zarejestruj_uzytkownika:":
                                uzytkownicy u = new uzytkownicy();

                                foreach (string s in slowa)
                                {
                                    string[] parametry = s.Split(':');

                                    if (parametry.Length != 2)
                                    {
                                        continue;
                                    }
                                    //MessageBox.Show(String.Join(" ", parametry),s);
                                    if (parametry[0] == "haslo")
                                    {
                                        u.haslo = hashowanie.GetHashString(parametry[1]);
                                    }
                                    else
                                    {
                                        PropertyInfo prop = u.GetType().GetProperty(parametry[0]);
                                        if (prop != null)
                                        {
                                            prop.SetValue(u, parametry[1], null);
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                }

                                SingletonBaza.Instance.BazaDC.uzytkownicies.InsertOnSubmit(u);
                                SingletonBaza.Instance.BazaDC.SubmitChanges();
                                odpowiedz = "true";
                                break;
                            case "zaloguj:":
                                var q_z = from uzytkownik in SingletonBaza.Instance.BazaDC.uzytkownicies
                                          where uzytkownik.login == slowa[1]
                                          && uzytkownik.haslo ==
                                          hashowanie.GetHashString(slowa[2])
                                          select uzytkownik;
                                if (q_z.Any())
                                {
                                    uzytkownicy zalogowany = q_z.FirstOrDefault();
                                    if (gracze.ContainsKey(zalogowany.login))
                                    {
                                        odpowiedz = "uzytkownik_jest_juz_zalogowany";
                                    }
                                    else
                                    {
                                        gracze.Add(zalogowany.login, zalogowany);
                                        odpowiedz = zalogowany.imie + " " + zalogowany.nazwisko
                                            + " " + zalogowany.login + " " + zalogowany.email;
                                        string sesja = hashowanie.GetSession();
                                        aktywne_sesje.Add(zalogowany.login, sesja);
                                        odpowiedz += " " + sesja;
                                    }
                                }
                                else
                                {
                                    odpowiedz = "bledneDane";
                                }
                                break;
                            case "wyloguj:":
                                foreach (var item in slownik_lobby)
                                {
                                    if (item.Value.czy_jestem_w_lobby(slowa[1]))
                                    {
                                        item.Value.usun(slowa[1]);
                                        item.Value.resetGry();
                                        string nr_lobby = item.Value.getNumer().ToString();
                                        if (aktywne_gry.ContainsKey(nr_lobby))
                                        {
                                            aktywne_gry.Remove(nr_lobby);
                                        }
                                    }
                                }
                                if (aktywne_sesje.ContainsKey(slowa[1]))
                                {
                                    hashowanie.ZwolnijSesje(aktywne_sesje[slowa[1]]);
                                    aktywne_sesje.Remove(slowa[1]);
                                }
                                if (gracze.ContainsKey(slowa[1]))
                                {

                                    gracze.Remove(slowa[1]);
                                    odpowiedz = "True";
                                }
                                else
                                {
                                    odpowiedz = "False";
                                }
                                break;
                            case "wielkosc_lobby:":
                                odpowiedz = "ll:" + liczba_lobby;
                                break;
                            case "dodaj_gracza_do_lobby:":
                                if (!zapytania.Contains(slowa[2]))
                                {
                                    zapytania.Add(slowa[2]);

                                    Boolean wynik_sprawdzania = true;
                                    foreach (Lobby w in slownik_lobby.Values)
                                    {
                                        if (w.czy_jestem_w_lobby(slowa[2]))
                                        {
                                            wynik_sprawdzania = false;
                                            break;
                                        }
                                    }
                                    if (wynik_sprawdzania && slownik_lobby.ContainsKey(slowa[1]))
                                    {
                                        odpowiedz = slownik_lobby[slowa[1]].dodaj(slowa[2]).ToString();
                                    }
                                    else
                                    {
                                        odpowiedz = "false";
                                    }
                                    zapytania.Remove(slowa[2]);
                                }
                                else
                                {
                                    odpowiedz = "False";
                                }
                                break;
                            case "usun_gracz_z_lobby:":
                                if (slownik_lobby.ContainsKey(slowa[1]))
                                {
                                    odpowiedz = slownik_lobby[slowa[1]].usun(slowa[2]).ToString();
                                }
                                else
                                {
                                    odpowiedz = "False";
                                }
                                break;
                            case "gracze_z_lobby:":
                                if (slownik_lobby.ContainsKey(slowa[1]))
                                {
                                    odpowiedz = slownik_lobby[slowa[1]].gracze();
                                }
                                else
                                {
                                    odpowiedz = "g1: g2:";
                                }
                                break;
                            case "czy_pelne_lobby:":
                                // Sprawdzić użycie w kliencie
                                if (slownik_lobby.ContainsKey(slowa[1]))
                                {
                                    odpowiedz = slownik_lobby[slowa[1]].czy_pelne_lobby().ToString();
                                }
                                else
                                {
                                    odpowiedz = "False";
                                }
                                break;
                            case "jestem_gotowy:":
                                if (!zapytania.Contains(slowa[2]))
                                {
                                    zapytania.Add(slowa[2]);
                                    if (slownik_lobby.ContainsKey(slowa[1]))
                                    {
                                        odpowiedz = slownik_lobby[slowa[1]].gotowy(slowa[2]).ToString();
                                    }
                                    else
                                    {
                                        odpowiedz = "False";
                                    }
                                    zapytania.Remove(slowa[2]);
                                }
                                break;
                            case "niejestem_gotowy:":
                                if (slownik_lobby.ContainsKey(slowa[1]))
                                {
                                    odpowiedz = slownik_lobby[slowa[1]].niegotowy(slowa[2]).ToString();
                                }
                                else
                                {
                                    odpowiedz = "False";
                                }
                                break;
                            case "pobierz_plansze:":
                                if (slowa[1] != "")
                                {
                                    if (aktywne_gry.ContainsKey(slowa[1]))
                                    {
                                        odpowiedz = aktywne_gry[slowa[1]].WylosowaniePlanszy();
                                    }
                                    else
                                    {
                                        Gra gra = new Gra(slownik_lobby[slowa[1]]);
                                        aktywne_gry.Add(slowa[1], gra);
                                        odpowiedz = aktywne_gry[slowa[1]].WylosowaniePlanszy();
                                    }
                                }
                                break;
                            case "zapisz_ruch:":
                                //MessageBox.Show(slowa[1] + " " +slowa[2]);
                                if (aktywne_gry.ContainsKey(slowa[1]))
                                {
                                    aktywne_gry[slowa[1]].ZapiszRuch(slowa[2]);
                                }
                                break;
                            case "wczytaj_ruchy:":
                                //MessageBox.Show(slowa[1] + " " + slowa[2]);
                                if (aktywne_gry.ContainsKey(slowa[1]))
                                {
                                    odpowiedz = aktywne_gry[slowa[1]].WczytajRuchy(slowa[2]);
                                }
                                break; ;
                            case "uzyt_wartosc_parametru:":
                                if (gracze.ContainsKey(slowa[1]))
                                {
                                    uzytkownicy edytowany = gracze[slowa[1]];
                                    var odp = edytowany.GetType().GetProperty(slowa[2]).GetValue(edytowany, null);
                                    if (odp != null)
                                    {
                                        odpowiedz = odp.ToString();
                                    }
                                }
                                else
                                {
                                    odpowiedz = "bledneDane";
                                }
                                break;
                            case "uzyt_zm_par:":
                                if (gracze.ContainsKey(slowa[1]))
                                {
                                    uzytkownicy edytowany = gracze[slowa[1]];
                                    if (slowa[2] == "haslo")
                                    {
                                        edytowany.haslo = hashowanie.GetHashString(slowa[3]);
                                        SingletonBaza.Instance.BazaDC.SubmitChanges();
                                        odpowiedz = "True";
                                    }
                                    else
                                    {
                                        PropertyInfo prop = edytowany.GetType().GetProperty(slowa[2]);
                                        if (prop != null)
                                        {
                                            prop.SetValue(edytowany, slowa[3], null);
                                            SingletonBaza.Instance.BazaDC.SubmitChanges();
                                            odpowiedz = "True";
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(slowa[1], slowa[2] + " " + slowa[3]);
                                    odpowiedz = "bledneDane";
                                }
                                break;
                            case "sesja:":
                                if (aktywne_sesje.ContainsKey(slowa[1]))
                                {
                                    odpowiedz = aktywne_sesje[slowa[1]];
                                }
                                break;

                            case "zakonczGre:":
                                if (aktywne_gry.ContainsKey(slowa[1]))
                                {
                                    aktywne_gry.Remove(slowa[1]);
                                    slownik_lobby[slowa[1]].resetGry();
                                    //.resetujGre();

                                }
                                break;
                            case "czyKoniecGry:":
                                if (aktywne_gry.ContainsKey(slowa[1]))
                                {
                                    odpowiedz = "False";
                                }
                                else
                                {
                                    odpowiedz = "True";
                                }
                                // MessageBox.Show(odpowiedz);
                                //Console.WriteLine(odpowiedz);
                                break;
                        }
                    }
                    Wyslij(handler, odpowiedz);
                }
                else
                {

                    // Not all data received. Get more.  
                    handler.BeginReceive(stan.buffer, 0, StanObiektu.rozmiarBuffera, 0,
                    new AsyncCallback(WczytajCallback), stan);
                }
            }
        }

        private static void Wyslij(Socket handler, String data)
        {
            byte[] bajtoweDane = Encoding.ASCII.GetBytes(data);
            handler.BeginSend(bajtoweDane, 0, bajtoweDane.Length, 0,
                new AsyncCallback(WyslijCallback), handler);
        }

        private static void WyslijCallback(IAsyncResult ar)
        {
            try
            {
                Socket handler = (Socket)ar.AsyncState;
                int bajtyWyslane = handler.EndSend(ar);
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
