using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class UC_Lobby : UserControl
    {

        Lobby lobby;
        String status_gry;
        private Boolean jestem_lobby = false, jestem_gotowy = false;
        public UC_Lobby(Form form, string numer)
        {
            InitializeComponent();
            l_numer.Text = numer;
            lobby = form as Lobby;
        }
        public async Task wczytaj_dane()
        {

            // zapytanie do bazy o graczy lobby: 1;
            String odp = await AsynchronicznyKlient.zapytaj("gracze_z_lobby: " + l_numer.Text);
            string[] slowa = odp.Split(' ');
            if (!odp.Contains("g1:"))
            {
                l_gracz1.Text = "";
            }
            if (!odp.Contains("g2:"))
            {
                l_gracz2.Text = "";
            }
            foreach (string s in slowa)
            {
                string[] parametry = s.Split(':');
                if (parametry[0] == "g1")
                {
                    l_gracz1.Text = parametry[1];
                }
                if (parametry[0] == "g2")
                {
                    l_gracz2.Text = parametry[1];
                }
                if (parametry[0] == "status")
                {
                    status_gry = parametry[1];
                }
            }
            l_inf.Text = status_gry;
            if (status_gry == "rozpoczynam" && jestem_lobby && !aplikacja.OstatniaGra)
            {
                // Start gry;
                timer_aktywnosc.Stop();
                //timer_aktywnosc.Stop();
                if (l_gracz1.Text == aplikacja.Login)
                {
                    aplikacja.Przeciwnik = l_gracz2.Text;
                }
                else
                {
                    aplikacja.Przeciwnik = l_gracz1.Text;
                }
                Gra gra = new Gra(this);
                gra.Show();
                gra.WczytajDane();
                // 5 sec sprawdza kto jest w lobby oraz status gry wiec nie musi sprawdac czy drugi gracz jest gotowy

            }
            Boolean wynik_pelny_server = l_gracz1.Text.Length != 0 && l_gracz2.Text.Length != 0;
            if (aplikacja.Nr_lobby != "")
            {
                if (aplikacja.Nr_lobby == l_numer.Text)
                {
                    btn_dolacz.Visible = true;
                    btn_dolacz.Text = "Wyjdź";
                    if (wynik_pelny_server)
                    {
                        btn_start.Visible = true;
                        if (jestem_gotowy)
                        {
                            btn_start.Text = "Anuluj";
                        }
                        else
                        {
                            btn_start.Text = "Start";
                        }
                    }
                    else
                    {
                        btn_start.Visible = false;
                    }
                }
                else
                {
                    btn_dolacz.Visible = false;
                    btn_start.Visible = false;
                }
            }
            else
            {
                if (wynik_pelny_server)
                {
                    btn_dolacz.Visible = false;
                    btn_start.Visible = false;
                }
                else
                {
                    btn_dolacz.Visible = true;
                    btn_dolacz.Text = "Dołącz";
                    btn_start.Visible = false;
                }
            }
        }
        private async void btn_dolacz_Click(object sender, EventArgs e)
        {
            timer_aktywnosc.Stop();
            if (!jestem_lobby)
            {
                // zapytanie do bazy danych czy lobby o numer ma wolne miejsce;
                // odp gracz w dodaj_lobby: numer
                String odp = await AsynchronicznyKlient.zapytaj("dodaj_gracza_do_lobby: " + l_numer.Text + " " + aplikacja.Login);

                jestem_lobby = Boolean.Parse(odp);
                // jeśli jestem w loby tick co 5 sec pytaj server kto jest w lobby
                // tick async wczytaj_Dane()
                //czekam = CzekamGracza2();
                aplikacja.Nr_lobby = l_numer.Text;
            }
            else
            {
                String odp = await AsynchronicznyKlient.zapytaj("usun_gracz_z_lobby: " + l_numer.Text + " " + aplikacja.Login);
                jestem_lobby = Boolean.Parse(odp);
                jestem_gotowy = false;
                aplikacja.Nr_lobby = "";
            }
            wczytaj_dane();
            lobby.odswierzReszte(l_numer.Text);
            timer_aktywnosc.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            wczytaj_dane();
        }

        private void UC_Lobby_Load(object sender, EventArgs e)
        {
            timer_aktywnosc.Start();
        }
        public void wywołajOdswierzenie()
        {
            timer_aktywnosc.Stop();
            wczytaj_dane();
            timer_aktywnosc.Start();
        }
        public async Task Zamykanie()
        {
            if (jestem_lobby)
            {
                AsynchronicznyKlient.zapytaj("usun_gracz_z_lobby: " + l_numer.Text + " " + aplikacja.Login);
            }
        }


        private async void btn_start_Click(object sender, EventArgs e)
        {
            timer_aktywnosc.Stop();
            if (!jestem_gotowy)
            {
                AsynchronicznyKlient asynchronousClient = new AsynchronicznyKlient();
                String odp = await AsynchronicznyKlient.zapytaj("jestem_gotowy: " + l_numer.Text + " " + aplikacja.Login);
                jestem_gotowy = Boolean.Parse(odp);
            }
            else
            {
                String odp = await AsynchronicznyKlient.zapytaj("niejestem_gotowy: " + l_numer.Text + " " + aplikacja.Login);
                jestem_gotowy = Boolean.Parse(odp);
            }
            wczytaj_dane();
            timer_aktywnosc.Start();
        }
        // Task tick co 5 sec pytaj server czy_pelny server
        // przy stworzeniu kontrolki aktualuzowanie jej co 5 sec przez tick który uruchamia wczytaj_dane()

        public void UruchomSprawdzanieLobby()
        {
            timer_aktywnosc.Start();
            jestem_gotowy = false;
        }

    }
}
