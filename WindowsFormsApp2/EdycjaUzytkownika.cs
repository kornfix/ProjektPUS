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
    public partial class EdycjaUzytkownika : Form
    {
        List<UC_edycja_parametru> edytowane_parametry = new List<UC_edycja_parametru>();
        UC_menu menu;
        public EdycjaUzytkownika(UserControl form)
        {
            menu = form as UC_menu;
            InitializeComponent();
            wczytaj_kontrolki();
        }
        void wczytaj_kontrolki()
        {
            foreach (UC_edycja_parametru.wyk_tryb type in Enum.GetValues(typeof(UC_edycja_parametru.wyk_tryb)))
            {
                UC_edycja_parametru uC_Edycja_Parametru = new UC_edycja_parametru(type);
                flp_edycja_uzytkownika.Controls.Add(uC_Edycja_Parametru);
                edytowane_parametry.Add(uC_Edycja_Parametru);
            }
        }


        private void button_anuluj_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button_rejestracja_Click(object sender, EventArgs e)
        {
            List<Task<Boolean>> lista_sprawdzania = new List<Task<Boolean>>();
            foreach(var item in edytowane_parametry)
            {
                lista_sprawdzania.Add(item.SprawdzEdycje());
            }
            await Task.WhenAll(lista_sprawdzania.ToArray());
            foreach(Task<Boolean> task in lista_sprawdzania)
            {
                if(!task.Result)
                {
                    return;
                }
            }
            List<Task<Boolean>> lista_konczoca = new List<Task<Boolean>>();
            foreach (var item in edytowane_parametry)
            {
                lista_konczoca.Add(item.ZakonczEdycje());
            }
            await Task.WhenAll(lista_konczoca.ToArray());
            foreach (Task<Boolean> task in lista_konczoca)
            {
                if (!task.Result)
                {
                    return;
                }
            }
            menu.wczytaj_dane();
            this.Close();
        }
    }
}
