using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Gra : Form
    {
        UC_pokoj_lobby uC_Lobby;
        public Gra(UC_pokoj_lobby uC_Lobby)
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
        private void Gra_Load(object sender, EventArgs e)
        {
            Aplikacja.OstatniaGra = this;
        }

        private void Gra_FormClosing(object sender, FormClosingEventArgs e)
        {
            String odp = AsynchronicznyKlient.zapytaj("zakonczGre: " + Rozgrywka.Nr_lobby);
            if (odp == "CzasUplynal" || odp == "error")
            {
                e.Cancel = true;
                MessageBox.Show("Nie udane wyjscie z gry");
            }
            else
            {
                Aplikacja.OstatniaGra = null;
            }
        }
    }
}
