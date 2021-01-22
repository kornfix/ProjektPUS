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
    public partial class UC_logowanie : UserControl
    {
        private Menu menu = null;
        public UC_logowanie(Form form)
        {
            menu = form as Menu;
            InitializeComponent();
        }

        private void buttonZaloguj_Click(object sender, EventArgs e)
        {
                // Zapytanie do serwera z tym stringiem
                string pytanie = textBoxLogin1 + " " + textBoxHaslo1;
                // Kod odpwoiedzi
                // jesli odpowiedż ma true w tab[0] to zalogowano poprawnie a reszta 
                // tab ma inf o koncie 
                // co zapisujemy w jakieś klasie najlepiej statycznej zalogowany gracz
                // dodajemy uc_menu do panelu 
                // a to ustaiwamy na false 
                menu.tryb_menu();
                // jesli false to wyswietlenie inf ze blad logowania
        }

        private void button_rejestracja_Click(object sender, EventArgs e)
        {
            menu.tryb_rejestracja();
        }
    }
}
