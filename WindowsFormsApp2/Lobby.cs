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
    public partial class Lobby : Form
    {
        Dictionary<string, UC_Lobby> wyswietlane_lobby = new Dictionary<string, UC_Lobby>();
        public Lobby()
        {
            InitializeComponent();
            wczytaj_lobby();
        }
        private async void wczytaj_lobby()
        {
            // zapytanie do serwera  ile mam lobby;
            AsynchronousClient asynchronousClient = new AsynchronousClient();
            String odp = await asynchronousClient.StartClient("wielkosc_lobby: <EOF>");
            string[] slowa = odp.Split(':'); 
            int ile = Int32.Parse(slowa[1]);
            for (int i=1; i<=ile; i++)
            {
                UC_Lobby uC_Lobby = new UC_Lobby(this,i.ToString());
                uC_Lobby.wczytaj_dane();
                wyswietlane_lobby.Add(i.ToString(), uC_Lobby);
                flp_lobby.Controls.Add(uC_Lobby);
            }
        }
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            flp_lobby.Controls.Clear();
            wczytaj_lobby();
        }
        public async Task odswierzReszte(string wywolal)
        {
            foreach(var item in wyswietlane_lobby)
            {
                if(item.Key != wywolal)
                {
                    item.Value.wywołajOdswierzenie();
                }
            }
        }

        private void Lobby_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(uzytkownik.Nr_lobby!="")
            {
                wyswietlane_lobby[uzytkownik.Nr_lobby].Zamykanie();
            }
        }
    }
}
