using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class UC_menu : UserControl
    {
        private Menu menu = null;
        public UC_menu(Form form)
        {
            menu = form as Menu;
            InitializeComponent();
            wczytaj_dane();
            timer_zalogowany.Start();
        }
        public void wczytaj_dane()
        {
            l_imie.Text = aplikacja.Imie;
            l_nazwisko.Text = aplikacja.Nazwisko;
            l_login.Text = aplikacja.Login;
        }


        private async void button_wyloguj_Click(object sender, EventArgs e)
        {
            // wyczysczenie obiektu klasy statycznej gdzie mamy gracza 
            // odpiecie od serwera też 
            String wyl = await AsynchronicznyKlient.zapytaj("wyloguj: " + aplikacja.Login);
            if (wyl == "True")
            {
                aplikacja.clear();
            }
            menu.tryb_logowanie();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (aplikacja.Lobby == null)
            {
                Lobby lobby = new Lobby();
                lobby.Show();
            }


        }

        private void UC_menu_VisibleChanged(object sender, EventArgs e)
        {
            wczytaj_dane();
            if (this.Visible == true)
            {
                timer_zalogowany.Start();
            }
            else
            {
                timer_zalogowany.Stop();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (aplikacja.EdycjaUzytkownika==null)
            {
                EdycjaUzytkownika edycja = new EdycjaUzytkownika(this);
                edycja.Show();

            }
        }

        private void timer_zalogowany_Tick(object sender, EventArgs e)
        {
            SprawdzCzyZalogowany();
        }

        async void SprawdzCzyZalogowany()
        {
            timer_zalogowany.Stop();
            String odp = await AsynchronicznyKlient.zapytaj("sesja: " + aplikacja.Login);
            if (odp != aplikacja.Sesja)
            {
                aplikacja.clear();
                menu.tryb_logowanie();
            }
            else
            {
                timer_zalogowany.Start();
            }
        }
    }
}
