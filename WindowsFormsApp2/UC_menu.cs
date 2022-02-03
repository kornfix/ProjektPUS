using System;
using System.Threading.Tasks;
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
            l_imie.Text = Uzytkownik.Imie;
            l_nazwisko.Text = Uzytkownik.Nazwisko;
            l_login.Text = Uzytkownik.Login;
        }


        private void button_wyloguj_Click(object sender, EventArgs e)
        {
            // wyczysczenie obiektu klasy statycznej gdzie mamy gracza 
            // odpiecie od serwera też 
            if (!backgroundWorker1.IsBusy)
            {
                menu.tryb_czekanie();
                bg_logout.RunWorkerAsync();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Aplikacja.Lobby == null)
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
            if (Aplikacja.EdycjaUzytkownika==null)
            {
                EdycjaUzytkownika edycja = new EdycjaUzytkownika(this);
                edycja.Show();
            }
        }

        private void timer_zalogowany_Tick(object sender, EventArgs e)
        {
            timer_zalogowany.Stop();
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("dziala");
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = AsynchronicznyKlient.zapytaj("sesja: " + Uzytkownik.Login);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                // Ogolny error
                MessageBox.Show(e.Error.ToString());
                return;
            }
            else if (e.Cancelled)
            {
                // Cancelacia 
                MessageBox.Show("Anulowano");
                return;
            }
            if (e.Result != null)
            {
                // Zwrocono cos
                String odp = e.Result.ToString();
                // Jakiś serwer nie odpowiedzial w ciagu 5 sekund albo zrwocil error;
                if (odp == "CzasUplynal" || odp =="error")
                {
                    MessageBox.Show("Brak dostępu do serwera");
                }else if (odp !=Uzytkownik.Sesja)
                {
                    Aplikacja.clear();
                    Uzytkownik.clear();
                    menu.tryb_logowanie();
                }
                else
                {
                    timer_zalogowany.Start();
                }
            }
            else
            {
                MessageBox.Show("Problem z zwracaniem resultatu");
            }            
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        private void bg_logout_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = AsynchronicznyKlient.zapytaj("wyloguj: " + Uzytkownik.Login);
        }
        private void bg_logout_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.ToString(), "Problem");
            }
            else if (e.Cancelled)
            {
                MessageBox.Show(e.Error.ToString(), "Problem");
            }
            else if (e.Result != null)
            {
                if (e.Result.Equals("True"))
                {
                    Aplikacja.clear();
                    Uzytkownik.clear();
                    menu.tryb_logowanie();
                }
                else
                {
                    MessageBox.Show("Nie udana próba wylogowania!", "Problem");
                }
            }   
        }
    }
}
