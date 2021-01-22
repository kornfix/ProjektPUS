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
    public partial class UC_rejestracja : UserControl
    {
        private Menu menu = null;
        public UC_rejestracja(Form form)
        {
            menu = form as Menu;
            InitializeComponent();
        }

        private void button_rejestracja_Click(object sender, EventArgs e)
        {
            // Kod walidacyjny

            // Kod wyslania prośby do serwera
            // oczekiwanie prośby

            // prosba udana 
            // logowanie do menu
            menu.tryb_menu();
            // prośba nie udana wyświetlenie inf
            
        }

        private void button_anuluj_Click(object sender, EventArgs e)
        {
            menu.tryb_logowanie();
        }
    }
}
