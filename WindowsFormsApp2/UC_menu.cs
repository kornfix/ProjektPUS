using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
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
            
        }
        public void wczytaj_dane()
        {
            l_imie.Text = uzytkownik.Imie;
            l_nazwisko.Text = uzytkownik.Nazwisko;
            l_login.Text = uzytkownik.Login;
        }


        private void button_wyloguj_Click(object sender, EventArgs e)
        {
            // wyczysczenie obiektu klasy statycznej gdzie mamy gracza 
            // odpiecie od serwera też 
            menu.tryb_logowanie();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Lobby lobby = new Lobby();
            lobby.Show();
        }

        private void UC_menu_VisibleChanged(object sender, EventArgs e)
        {
            wczytaj_dane();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
        }
    }
}
