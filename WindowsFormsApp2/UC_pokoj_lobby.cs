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
    public partial class UC_pokoj_lobby : UserControl
    {

        private Lobby lobby;
        private String status_gry, gracz1, gracz2;
        private bool w_lobby = false, jestem_gotowy = false;
        public UC_pokoj_lobby(Form form, string numer)
        {
            InitializeComponent();
            l_numer.Text = numer;
            lobby = form as Lobby;
        }
        public void wczytaj_dane()
        {

            status_gry = "";
            gracz1 = "";
            gracz2 = "";
            if (!bg_odswierzanie.IsBusy)
            {
                bg_odswierzanie.RunWorkerAsync();
            }

        }
        private async void btn_dolacz_Click(object sender, EventArgs e)
        {
            if (Aplikacja.OstatniaGra != null)
            {
                MessageBox.Show("Coś poszło nie tak!");
                return;
            }
            if (!bg_dolaczanie.IsBusy)
            {
                bg_dolaczanie.RunWorkerAsync();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            wczytaj_dane();
        }

        private void UC_Lobby_Load(object sender, EventArgs e)
        {
            timer_aktywnosc.Start();
        }
        public void Zamykanie()
        {
            if (w_lobby)
            {
                AsynchronicznyKlient.zapytaj(Pytanie.komendy.usun_gracz_z_lobby,
                    new object[] { l_numer.Text, Uzytkownik.Instance.Login});
            }
        }


        private async void btn_start_Click(object sender, EventArgs e)
        {
            if (Aplikacja.OstatniaGra == null && !bg_startgry.IsBusy)
            {
                bg_startgry.RunWorkerAsync();
            }
        }
        private void bg_dolaczanie_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!w_lobby)
            {
                e.Result = AsynchronicznyKlient.zapytaj(Pytanie.komendy.dodaj_gracza_do_lobby,
                    new object[] { l_numer.Text, Uzytkownik.Instance.Login });
            }
            else
            {
                e.Result = AsynchronicznyKlient.zapytaj(Pytanie.komendy.usun_gracz_z_lobby, 
                    new object[] { l_numer.Text, Uzytkownik.Instance.Login});
            }
        }
        private void bg_dolaczanie_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                String odp = e.Result.ToString();
                if (odp == "CzasUplynal" || odp == "error")
                {
                    MessageBox.Show("Nie udane polaczenie z serverem!");
                }
                else
                {
                    w_lobby = !w_lobby;
                    Rozgrywka.Nr_lobby = w_lobby ? l_numer.Text : "";
                    wczytaj_dane();
                }
            }
        }

        private void bg_startgry_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!jestem_gotowy)
            {
                e.Result = AsynchronicznyKlient.zapytaj(Pytanie.komendy.jestem_gotowy,
                    new object[] { l_numer.Text, Uzytkownik.Instance.Login, 
                        Uzytkownik.Instance.Sesja});
            }
            else
            {
                e.Result = AsynchronicznyKlient.zapytaj(Pytanie.komendy.niejestem_gotowy,
                    new object[] { l_numer.Text, Uzytkownik.Instance.Login,
                        Uzytkownik.Instance.Sesja });
            }
        }

        private void bg_startgry_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                String odp = e.Result.ToString();
                if (odp == "CzasUplynal" || odp == "error")
                {
                    MessageBox.Show("Nie udane polaczenie z serverem!", "Problem");
                }
                else
                {
                    jestem_gotowy = Boolean.Parse(odp);
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = AsynchronicznyKlient.zapytaj(Pytanie.komendy.gracze_z_lobby
                , new object[] { l_numer.Text});
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                String odp = e.Result.ToString();
                if (odp == "CzasUplynal" || odp == "error")
                {
                    MessageBox.Show("Nie udane polaczenie z serverem!");
                    lobby.Close();
                }
                else
                {
                    string[] slowa = odp.Split(' ');
                    foreach (string s in slowa)
                    {
                        string[] parametry = s.Split(':');
                        switch (parametry[0])
                        {
                            case "g1":
                                gracz1 = parametry[1];
                                break;
                            case "g2":
                                gracz1 = parametry[1];
                                break;
                            case "status":
                                status_gry = parametry[1];
                                break;
                        }
                    }
                    //w_lobby = gracz1.Equals(Uzytkownik.Login) || gracz2.Equals(Uzytkownik.Login);
                    if (!l_gracz1.Text.Equals(gracz1)) l_gracz1.Text = gracz1;
                    if (!l_gracz2.Text.Equals(gracz2)) l_gracz2.Text = gracz2;
                    if (!l_inf.Text.Equals(status_gry)) l_inf.Text = status_gry;

                    if (status_gry == "rozpoczynam" && w_lobby && Aplikacja.OstatniaGra == null)
                    {
                        // Start gry;
                        Rozgrywka.Przeciwnik = gracz1.Equals(Uzytkownik.Instance.Login) ? gracz2 : gracz1;
                        Gra gra = new Gra(this);
                        gra.Show();
                        gra.WczytajDane();
                    }
                    bool wynik_pelny_server = gracz1.Length != 0 && gracz1.Length != 0;
                    if (Rozgrywka.Nr_lobby != "")
                    {
                        if (Rozgrywka.Nr_lobby == l_numer.Text)
                        {
                            btn_dolacz.Visible = true;
                            btn_dolacz.Text = "Wyjdź";
                            if (wynik_pelny_server)
                            {
                                btn_start.Visible = true;
                                btn_start.Text = jestem_gotowy ? "Anuluj" : "Start";
                            }
                            else
                            {
                                btn_start.Visible = false;
                            }
                        }
                        else
                        {
                            btn_dolacz.Visible = false;
                            btn_start.Visible = false;
                        }
                    }
                    else
                    {
                        if (wynik_pelny_server)
                        {
                            btn_dolacz.Visible = false;
                            btn_start.Visible = false;
                        }
                        else
                        {
                            btn_dolacz.Visible = true;
                            btn_dolacz.Text = "Dołącz";
                            btn_start.Visible = false;
                        }
                    }
                }
            }
        }

        public void Zakoncz()
        {
            if (Aplikacja.OstatniaGra != null)
            {
                Aplikacja.OstatniaGra.Close();
            }
            timer_aktywnosc.Stop();
        }
    }
}
