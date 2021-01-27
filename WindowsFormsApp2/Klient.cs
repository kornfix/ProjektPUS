using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WindowsFormsApp2
{
    public partial class Klient : Form
    {
        string[][] wyloswana_plansza;
        
        public Klient()
        {
            InitializeComponent();

        }
        class Przycisk : Label
        {
            int x;
            int y;
            Przycisk(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public int X { get => x; set => x = value; }
            public int Y { get => y; set => y = value; }
        }
        string zapytanie = "ruch_gracza login:"+ uzytkownik.Login;
        int ruch = 1;
        bool pierszy_sprawdzany = true;
        private void label_Click(object sender, EventArgs e)
        {
            //Label lslwqlfqfw;
            // qrwq
            Przycisk przycisk = sender as Przycisk;
            zapytanie += przycisk.X + ";" + przycisk.Y ;
            if(pierszy_sprawdzany)
            {
                zapytanie += ":";
                pierszy_sprawdzany = !pierszy_sprawdzany;
            }
        }
    }
}
