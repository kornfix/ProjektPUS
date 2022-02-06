using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.Json;
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
        public static ManualResetEvent wszystkoWykonane = new ManualResetEvent(false);

        public AsynchronicznySocketListener()
        {

        }
        static void wczytaj_lobby()
        {
            Console.WriteLine("Wczytywanie lobby");
            slownik_lobby = new Dictionary<string, Lobby>();
            for (int i = 1; i <= liczba_lobby; i++)
            {
                Console.WriteLine($"Wczytano lobby nr {i}");
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
                Console.WriteLine("Nasłuchiwanie serwera");
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
                Console.WriteLine(e.ToString());
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
                Console.WriteLine($"Tresc zapytania: {zawartosc}");
                if (zawartosc.IndexOf("<EOF>") > -1)
                {
                    zawartosc = zawartosc.Replace("<EOF>", "");
                    Pytanie pytanie = JsonSerializer.Deserialize<Pytanie>(zawartosc);
                    Odpowiedz odpowiedz =new Odpowiedz();
                    // Kod który wczytuje wysłaną wiadomośc i odpowiada.
                    if (pytanie != null)
                    {
                        //TODO
                        // Sprawdzenie sesji 
                        if (pytanie.Sesja == null)
                        {
                            // Komendy dla nie zalogowanych
                            switch (pytanie.Komenda)
                            {
                                case Pytanie.komendy.sprawdz_email:
                                    odpowiedz.Argumenty[0] = (from uzytkownik in SingletonBaza.Instance.BazaDC.uzytkownicy
                                                 where uzytkownik.email.Equals(pytanie.Argumenty[0].ToString())
                                                 select uzytkownik).Any();
                                    break;
                                case Pytanie.komendy.sprawdz_login:
                                    odpowiedz.Argumenty[0] = (from uzytkownik in SingletonBaza.Instance.BazaDC.uzytkownicy
                                                 where uzytkownik.login.Equals(pytanie.Argumenty[0].ToString())
                                                 select uzytkownik).Any();
                                    break;
                                case Pytanie.komendy.zarejestruj_uzytkownika:
                                    string zu_uzytkownik = pytanie.Argumenty[0].ToString();
                                    uzytkownicy u = JsonSerializer.Deserialize<uzytkownicy>(zu_uzytkownik);
                                    u.haslo = hashowanie.GetHashString(u.haslo);
                                    SingletonBaza.Instance.BazaDC.uzytkownicy.InsertOnSubmit(u);
                                    SingletonBaza.Instance.BazaDC.SubmitChanges();
                                    odpowiedz.Argumenty[0] = true;
                                    break;
                                case Pytanie.komendy.zaloguj:
                                    string z_login = pytanie.Argumenty[0].ToString();
                                    string z_haslo = pytanie.Argumenty[1].ToString();
                                    var q_z = from uzytkownik in SingletonBaza.Instance.BazaDC.uzytkownicy
                                              where uzytkownik.login.Equals(z_login)
                                              && uzytkownik.haslo.Equals(hashowanie.GetHashString(z_haslo))
                                              select uzytkownik;
                                    if (q_z.Any())
                                    {
                                        uzytkownicy zalogowany = q_z.FirstOrDefault();
                                        if (gracze.ContainsKey(zalogowany.login))
                                        {
                                            odpowiedz.Argumenty[0] = "uzytkownik_jest_juz_zalogowany";
                                        }
                                        else
                                        {
                                            gracze.Add(zalogowany.login, zalogowany);
                                            string sesja = hashowanie.GetSession();
                                            odpowiedz = new Odpowiedz(new object[] { new Uzytkownik(zalogowany, sesja) });
                                            aktywne_sesje.Add(zalogowany.login, sesja);
                                            Console.WriteLine($"Zalogowano użytkownika: {zalogowany.login}, Nadano numer sesji: {sesja}");
                                        }
                                    }
                                    else
                                    {
                                        odpowiedz.Argumenty[0] = "bledneDane";
                                    }
                                    break;
                            }
                        }else if(aktywne_sesje.ContainsValue(pytanie.Sesja))
                        {
                            // Komendy dla zalogowanych 
                            switch (pytanie.Komenda)
                            {

                                case Pytanie.komendy.wyloguj:
                                    string w_login = pytanie.Argumenty[0].ToString();
                                    string w_sesja = pytanie.Argumenty[1].ToString();
                                    foreach (var item in slownik_lobby)
                                    {
                                        if (item.Value.czy_jestem_w_lobby(w_login,w_sesja))
                                        {
                                            odpowiedz.Argumenty[0] = item.Value.usun(w_login, w_sesja);
                                        }
                                    }
                                    if (aktywne_sesje.ContainsKey(w_login))
                                    {
                                        hashowanie.ZwolnijSesje(aktywne_sesje[w_login]);
                                        aktywne_sesje.Remove(w_login);
                                    }
                                    odpowiedz.Argumenty[0] = gracze.ContainsKey(w_login);
                                    if (gracze.ContainsKey(w_login))
                                    {
                                        gracze.Remove(w_login);
                                    }
                                    odpowiedz.Argumenty[0] = true;
                                    break;
                                case Pytanie.komendy.wielkosc_lobby:
                                    odpowiedz.Argumenty[0] = "ll:" + liczba_lobby;
                                    break;
                                case Pytanie.komendy.dodaj_gracza_do_lobby:
                                    string dgdl_numer_lobby = pytanie.Argumenty[0].ToString();
                                    string dgdl_login = pytanie.Argumenty[1].ToString();
                                    string dgdl_sesja = pytanie.Argumenty[2].ToString();
                                    if (!zapytania.Contains(dgdl_login))
                                    {
                                        zapytania.Add(dgdl_login);
                                        Boolean wynik_sprawdzania = !slownik_lobby.Any(n => n.Value.czy_jestem_w_lobby(dgdl_login, dgdl_sesja));
                                        //MessageBox.Show($"Sprawdzanie {wynik_sprawdzania}");
                                        if (wynik_sprawdzania && slownik_lobby.ContainsKey(dgdl_numer_lobby))
                                        {

                                            odpowiedz.Argumenty[0] = slownik_lobby[dgdl_numer_lobby].dodaj(dgdl_login, dgdl_sesja);
                                        }
                                        else
                                        {
                                            odpowiedz.Argumenty[0] = false;
                                        }
                                        zapytania.Remove(dgdl_login);
                                    }
                                    else
                                    {
                                        odpowiedz.Argumenty[0] = false;
                                    }
                                    break;
                                case Pytanie.komendy.usun_gracz_z_lobby:
                                    string ugzl_nr_lobby = pytanie.Argumenty[0].ToString();
                                    string ugzl_login =  pytanie.Argumenty[1].ToString();
                                    string ugzl_sesja = pytanie.Argumenty[2].ToString();
                                    if (slownik_lobby.ContainsKey(ugzl_nr_lobby))
                                    {
                                        odpowiedz.Argumenty[0] = slownik_lobby[ugzl_nr_lobby].usun(ugzl_login, ugzl_sesja);
                                    }
                                    break;
                                case Pytanie.komendy.gracze_z_lobby:
                                    string gzl_nr_lobby = pytanie.Argumenty[0].ToString();
                                    if (slownik_lobby.ContainsKey(gzl_nr_lobby))
                                    {
                                        odpowiedz.Argumenty[0] = slownik_lobby[gzl_nr_lobby].gracze();
                                    }
                                    break;
                                case Pytanie.komendy.czy_pelne_lobby:
                                    // Sprawdzić użycie w kliencie
                                    string cpl_nr_lobby = pytanie.Argumenty[0].ToString();
                                    if (slownik_lobby.ContainsKey(cpl_nr_lobby))
                                    {
                                        odpowiedz.Argumenty[0] = slownik_lobby[cpl_nr_lobby].czy_pelne_lobby();
                                    }
                                    break;
                                case Pytanie.komendy.jestem_gotowy:
                                    string jg_nr_pokoju = pytanie.Argumenty[0].ToString();
                                    string jg_login_gracza = pytanie.Argumenty[1].ToString();
                                    string jg_sesja = pytanie.Argumenty[2].ToString();
                                    if (!zapytania.Contains(jg_login_gracza))
                                    {
                                        zapytania.Add(jg_login_gracza);
                                        if (slownik_lobby.ContainsKey(jg_nr_pokoju))
                                        {
                                            odpowiedz.Argumenty[0] = slownik_lobby[jg_nr_pokoju].gotowy(jg_login_gracza, jg_sesja);
                                        }
                                        zapytania.Remove(jg_login_gracza);
                                    }
                                    break;
                                case Pytanie.komendy.niejestem_gotowy:
                                    string ng_nr_pokoju = pytanie.Argumenty[0].ToString();
                                    string ng_login = pytanie.Argumenty[1].ToString();
                                    string ng_sesja = pytanie.Argumenty[2].ToString();
                                    if (slownik_lobby.ContainsKey(ng_nr_pokoju))
                                    {
                                        odpowiedz.Argumenty[0] = slownik_lobby[ng_nr_pokoju].niegotowy(ng_login, ng_sesja);
                                    }
                                    break;
                                case Pytanie.komendy.pobierz_plansze:
                                    
                                    if (pytanie.Argumenty[0] != null)
                                    {
                                        string pp_nr_lobby = pytanie.Argumenty[0].ToString();
                                        string pp_login = pytanie.Argumenty[1].ToString();
                                        string pp_sesja = pytanie.Argumenty[2].ToString();
                                        if (slownik_lobby.ContainsKey(pp_nr_lobby))
                                        {
                                            odpowiedz.Argumenty[0] = slownik_lobby[pp_nr_lobby]
                                                .get_plansza(pp_login,pp_sesja);
                                        }
                                    }
                                    break;
                                case Pytanie.komendy.zapisz_ruch:
                                    string zp_nr_lobby = pytanie.Argumenty[0].ToString();
                                    string zp_login = pytanie.Argumenty[1].ToString();
                                    string zp_sesja = pytanie.Argumenty[2].ToString();
                                    int zp_indeks = ((JsonElement)pytanie.Argumenty[3]).GetInt32();
                                    if (slownik_lobby.ContainsKey(zp_nr_lobby))
                                    {
                                        odpowiedz.Argumenty[0] = slownik_lobby[zp_nr_lobby]
                                            .zapisz_ruch(zp_login, zp_sesja, zp_indeks);
                                    }
                                    break;
                                case Pytanie.komendy.wczytaj_ruchy:
                                    string wr_nr_lobby = pytanie.Argumenty[0].ToString();
                                    string wr_login = pytanie.Argumenty[1].ToString();
                                    string wr_sesja = pytanie.Argumenty[2].ToString();
                                    int wr_liczba_ruchow = ((JsonElement)pytanie.Argumenty[0]).GetInt32(); ;
                                    if (slownik_lobby.ContainsKey(wr_nr_lobby))
                                    {
                                        odpowiedz.Argumenty[0] = slownik_lobby[wr_nr_lobby]
                                            .get_ruchy(wr_login, wr_sesja, wr_liczba_ruchow);
                                    }
                                    break;
                                case Pytanie.komendy.uzyt_wartosc_parametru:
                                    string uwp_login_gracza = pytanie.Argumenty[0].ToString();
                                    string uwp_nazwa_parametru = pytanie.Argumenty[1].ToString();
                                    if (gracze.ContainsKey(uwp_login_gracza))
                                    {
                                        uzytkownicy edytowany = gracze[uwp_login_gracza];
                                        var odp = edytowany.GetType().GetProperty(uwp_nazwa_parametru).GetValue(edytowany, null);
                                        if (odp != null)
                                        {
                                            odpowiedz.Argumenty[0] = odp.ToString();
                                        }
                                    }
                                    else
                                    {
                                        odpowiedz.Argumenty[0] = "bledneDane";
                                    }
                                    break;
                                case Pytanie.komendy.uzyt_zm_par:
                                    string uzp_login_gracza = pytanie.Argumenty[0].ToString();
                                    string uzp_nazwa_parametru = pytanie.Argumenty[1].ToString();
                                    string uzp_nowa_wartosc =pytanie.Argumenty[2].ToString();
                                    if (gracze.ContainsKey(uzp_login_gracza))
                                    {
                                        uzytkownicy edytowany = gracze[uzp_login_gracza];
                                        if (uzp_nazwa_parametru.Equals("haslo"))
                                        {
                                            edytowany.haslo = hashowanie.GetHashString(uzp_nowa_wartosc);
                                            SingletonBaza.Instance.BazaDC.SubmitChanges();
                                            odpowiedz.Argumenty[0] = true;
                                        }
                                        else
                                        {
                                            PropertyInfo prop = edytowany.GetType().GetProperty(uzp_nazwa_parametru);
                                            if (prop != null)
                                            {
                                                prop.SetValue(edytowany, uzp_nowa_wartosc, null);
                                                SingletonBaza.Instance.BazaDC.SubmitChanges();
                                                odpowiedz.Argumenty[0] = true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //MessageBox.Show(slowa[1], slowa[2] + " " + slowa[3]);
                                        odpowiedz.Argumenty[0] = "bledneDane";
                                    }
                                    break;
                                case Pytanie.komendy.sesja:
                                    string sesja_login = pytanie.Argumenty[0].ToString();
                                    string sesja_kod = pytanie.Argumenty[1].ToString();
                                    if (aktywne_sesje.ContainsKey(sesja_login))
                                    {
                                        odpowiedz.Argumenty[0] = aktywne_sesje[sesja_login].Equals(sesja_kod);
                                    }else
                                    {
                                        odpowiedz.Argumenty[0] = false;
                                    }
                                    break;
                                case Pytanie.komendy.zakoncz_gre:
                                    string zg_nr_lobby = pytanie.Argumenty[0].ToString();
                                    if (slownik_lobby.ContainsKey(zg_nr_lobby))
                                    {
                                        slownik_lobby[zg_nr_lobby].resetGry();
                                    }
                                    odpowiedz.Argumenty[0] = true;
                                    break;
                                case Pytanie.komendy.czy_koniec_gry:
                                    string ckg_nr_lobby = pytanie.Argumenty[0].ToString();
                                    odpowiedz.Argumenty[0] = slownik_lobby[ckg_nr_lobby]
                                        .czy_koniec_gry();
                                    break;
                            }
                        }
                    }
                    string odwp = JsonSerializer.Serialize<Odpowiedz>(odpowiedz);
                    Console.WriteLine($"Tresc odpowiedzi: {odwp}");
                    Wyslij(handler, JsonSerializer.Serialize<Odpowiedz>(odpowiedz));
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
