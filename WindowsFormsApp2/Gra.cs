using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Gra : Form
    {
        UC_Lobby uC_Lobby;
        public Gra(UC_Lobby uC_Lobby)
        {
            this.uC_Lobby = uC_Lobby;
            InitializeComponent();
        }

        public async void WczytajDane()
        {
            UC_plansza uc_plansza = new UC_plansza(this);
            uc_plansza.WczytajPlansze();
            tableLayoutPanel2.Controls.Add(uc_plansza);
            tableLayoutPanel2.Anchor = AnchorStyles.None;
        }

        public async void Gra_FormClosed(object sender, FormClosedEventArgs e)
        {
            String odp = await AsynchronicznyKlient.zapytaj("zakonczGre: " + aplikacja.Nr_lobby);

            uC_Lobby.UruchomSprawdzanieLobby();
            aplikacja.OstatniaGra = false;
        }

        private void Gra_Load(object sender, EventArgs e)
        {
            aplikacja.OstatniaGra = true;
        }
    }
}
