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
        private Boolean jestem_lobby = false, jestem_gotowy=false;
        public UC_Lobby(Form form,string numer)
        {
            InitializeComponent();
            l_numer.Text = numer;
            lobby = form as Lobby;
        }
        public async Task wczytaj_dane()
        {
            
            // zapytanie do bazy o graczy lobby: 1;
            AsynchronousClient asynchronousClient = new AsynchronousClient();
            String odp = await asynchronousClient.StartClient("gracze_z_lobby: " + l_numer.Text + " <EOF>");
            string[] slowa = odp.Split(' ');
            if(!odp.Contains("g1:"))
            {
                l_gracz1.Text = "";
            }
            if(!odp.Contains("g2:"))
            {
                l_gracz2.Text = "";
            }
            foreach( string s in slowa)
            {
                string[] parametry = s.Split(':');
                if(parametry[0]== "g1")
                {
                    l_gracz1.Text = parametry[1];
                }
                if(parametry[0] == "g2")
                {
                    l_gracz2.Text = parametry[1];
                }
                if(parametry[0] == "status")
                {
                    status_gry = parametry[1];
                }
            }
            l_inf.Text = status_gry;
            if(status_gry == "rozpoczynam" && jestem_lobby)
            {
                // Start gry;
                MessageBox.Show("Zaczynasz grę :P");
                timer_aktywnosc.Stop();
                // 5 sec sprawdza kto jest w lobby oraz status gry wiec nie musi sprawdac czy drugi gracz jest gotowy

            }
            Boolean wynik_pelny_server = l_gracz1.Text.Length !=0 && l_gracz2.Text.Length != 0;
            l_inf.Text = l_inf.Text + " " + wynik_pelny_server.ToString();
            if (uzytkownik.Nr_lobby != "")
            {
                if(uzytkownik.Nr_lobby == l_numer.Text)
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
                }else
                {
                    btn_dolacz.Visible = false;
                    btn_start.Visible = false;
                }
            }else
            {
                if(wynik_pelny_server)
                {
                    btn_dolacz.Visible = false;
                    btn_start.Visible = false;
                }else
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
                AsynchronousClient asynchronousClient = new AsynchronousClient();
                String odp = await asynchronousClient.StartClient("dodaj_gracza_do_lobby: " + l_numer.Text +" "+ uzytkownik.Login+ " <EOF>");

                    jestem_lobby = Boolean.Parse(odp);
                // jeśli jestem w loby tick co 5 sec pytaj server kto jest w lobby
                // tick async wczytaj_Dane()
                //czekam = CzekamGracza2();
                uzytkownik.Nr_lobby = l_numer.Text;
            }else
            {
                AsynchronousClient asynchronousClient = new AsynchronousClient();
                String odp = await asynchronousClient.StartClient("usun_gracz_z_lobby: " + l_numer.Text + " " + uzytkownik.Login + " <EOF>");
                jestem_lobby = Boolean.Parse(odp);
                jestem_gotowy = false;
                uzytkownik.Nr_lobby = "";
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
            if(jestem_lobby)
            {
                AsynchronousClient asynchronousClient = new AsynchronousClient();
                asynchronousClient.StartClient("usun_gracz_z_lobby: " + l_numer.Text + " " + uzytkownik.Login + " <EOF>");
            }
        }
       

        private async void btn_start_Click(object sender, EventArgs e)
        {
            timer_aktywnosc.Stop();
            if (!jestem_gotowy)
            {
                AsynchronousClient asynchronousClient = new AsynchronousClient();
                String odp = await asynchronousClient.StartClient("jestem_gotowy: " + l_numer.Text + " " + uzytkownik.Login + " <EOF>");
                jestem_gotowy = Boolean.Parse(odp);
            }
            else
            {
                AsynchronousClient asynchronousClient = new AsynchronousClient();
                String odp = await asynchronousClient.StartClient("niejestem_gotowy: " + l_numer.Text + " " + uzytkownik.Login + " <EOF>");
                jestem_gotowy = Boolean.Parse(odp);
            }
            wczytaj_dane();
            timer_aktywnosc.Start();
        }
        // Task tick co 5 sec pytaj server czy_pelny server
        // przy stworzeniu kontrolki aktualuzowanie jej co 5 sec przez tick który uruchamia wczytaj_dane()

    }
}
