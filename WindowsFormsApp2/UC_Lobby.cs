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
        Task czekam;
        String status_gry;
        private Boolean jestem_lobby = false, jestem_gotowy=false;
        public UC_Lobby(string numer)
        {
            InitializeComponent();
            l_numer.Text = numer;
        }
        public async Task wczytaj_dane()
        {
            // zapytanie do bazy o graczy lobby: 1;
            AsynchronousClient asynchronousClient = new AsynchronousClient();
            String odp = await asynchronousClient.StartClient("gracze_z_lobby: " + l_numer.Text + " <EOF>");
            string[] slowa = odp.Split(' ');
            l_gracz1.Text = "";
            l_gracz2.Text = "";
            foreach( string s in slowa)
            {
                string[] parametry = s.Split(':');
                if(parametry[0]== "g1")
                {
                    l_gracz1.Text = parametry[1];
                }else if(parametry[0] == "g2")
                {
                    l_gracz2.Text = parametry[1];
                }
                if(parametry[0] == "status")
                {
                    status_gry = parametry[1];
                }
            }
            l_inf.Text = status_gry;
            if(status_gry == "rozpoczynam gre" && jestem_lobby)
            {
                // Start gry;
                // 5 sec sprawdza kto jest w lobby oraz status gry wiec nie musi sprawdac czy drugi gracz jest gotowy

            }
            btn_dolacz.Visible = true;
            btn_dolacz.Text = "Dołacz";
            btn_start.Text = "Start";
            btn_start.Visible = false;
            if(slowa[0].Length >3 && slowa[1].Length >3)
            {
                MessageBox.Show(slowa[0] + " " +slowa[1]);
                btn_dolacz.Visible = false;
            } 
            if(jestem_lobby)
            {
                btn_dolacz.Visible = true;
                btn_dolacz.Text = "Wyjdź";
            }
            if (jestem_lobby && slowa[0].Length > 3 && slowa[1].Length > 3)
            {
                btn_start.Visible = true;
            }
            if(jestem_gotowy)
            {
                btn_start.Text = "Anuluj";
            }

        }
        private async void btn_dolacz_Click(object sender, EventArgs e)
        {
            
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
            }else
            {
                AsynchronousClient asynchronousClient = new AsynchronousClient();
                String odp = await asynchronousClient.StartClient("usun_gracz_z_lobby: " + l_numer.Text + " " + uzytkownik.Login + " <EOF>");
                jestem_lobby = Boolean.Parse(odp);
                jestem_gotowy = false;
            }
            wczytaj_dane();
        }

        private async void btn_start_Click(object sender, EventArgs e)
        {
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

        }
        // Task tick co 5 sec pytaj server czy_pelny server
        // przy stworzeniu kontrolki aktualuzowanie jej co 5 sec przez tick który uruchamia wczytaj_dane()

    }
}
