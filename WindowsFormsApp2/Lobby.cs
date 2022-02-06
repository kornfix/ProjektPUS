using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Lobby : Form
    {
        Dictionary<string, UC_pokoj_lobby> wyswietlane_lobby = new Dictionary<string, UC_pokoj_lobby>();
        public Lobby()
        {
            InitializeComponent();
            wczytaj_lobby();
        }


        public void wczytaj_lobby()
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }   
        }
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            flp_lobby.Controls.Clear();
            wczytaj_lobby();
        }
        private void Lobby_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Rozgrywka.Nr_lobby != "")
            {
                wyswietlane_lobby[Rozgrywka.Nr_lobby].Zamykanie();
            }
        }

        private void Lobby_Load(object sender, EventArgs e)
        {
            Aplikacja.Lobby = this;
        }

        private void Lobby_FormClosed(object sender, FormClosedEventArgs e)
        {
            Zakoncz();
            Aplikacja.Lobby = null;
        }
        public void Zakoncz()
        {
            wyswietlane_lobby.Values.ToList().ForEach(x => x.Zakoncz());
            Rozgrywka.Nr_lobby = "";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = AsynchronicznyKlient.zapytaj(Pytanie.komendy.wielkosc_lobby,null);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.ToString(), "Problem");
                Aplikacja.clear();
                Close();
                return;
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Brak dostępu do serwera!");
                Aplikacja.clear();
                Close();
                return;
            }
            if (e.Result != null)
            {

                String odp = e.Result.ToString();
                if (odp == "CzasUplynal" || odp == "error")
                {
                    MessageBox.Show("Coś poszło nie tak!");
                    Close();
                    return;
                }
                else
                {
                    string[] slowa = e.Result.ToString().Split(':');
                    int ile = Int32.Parse(slowa[1]);
                    for (int i = 1; i <= ile; i++)
                    {
                        UC_pokoj_lobby uC_Lobby = new UC_pokoj_lobby(this, i.ToString());
                        uC_Lobby.wczytaj_dane();
                        wyswietlane_lobby.Add(i.ToString(), uC_Lobby);
                        flp_lobby.Controls.Add(uC_Lobby);
                    }
                }

            }
        }
    }
}
