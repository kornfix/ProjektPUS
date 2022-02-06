using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json;
using System.Windows.Forms;
namespace WindowsFormsApp2
{
    public partial class UC_plansza : UserControl
    {
        int liczba_ruchow = 0;
        private Dictionary<string, int> wyniki_graczy = new Dictionary<string, int>();
        Label firstClicked, secondClick;
        Color kolor;
        Color kolor1 = Color.LightSteelBlue;
        Color kolor2 = Color.CornflowerBlue;
        Gra gra;
        Boolean czyZaczynam;
        class Przycisk : Label
        {
            int indeks;
            public Przycisk(int i)
            {
                indeks = i;
            }
            public int getIndeks()
            {
                return indeks;
            }
        }  
        public UC_plansza(Form form)
        {
            InitializeComponent();
            gra = form as Gra;
        }

        public UC_plansza(int liczba_ruchow)
        {
            this.liczba_ruchow = liczba_ruchow;
        }

        public void WczytajPlansze()
        {
            //TODO
            // Klasa zwracana plansze
            //String odp = AsynchronicznyKlient.zapytaj(Pytanie.komendy.pobierz_plansze,new object[] { Rozgrywka.Nr_lobby });
            //if (odp == "CzasUplynal" || odp == "error")
            //{
            //    MessageBox.Show("Nie udane połaczenie z serwerem");
            //    return;
            //}
            //string[] odpowiedz = odp.Split(' ');
            //int rozmiar = Int32.Parse(odpowiedz[0]);
            //wygeneruj_labele(rozmiar);
            //wyniki_graczy.Add(Uzytkownik.Login, 0);
            //wyniki_graczy.Add(Rozgrywka.Przeciwnik,0);
            //gracz1.Text = Uzytkownik.Login;
            //gracz2.Text = Rozgrywka.Przeciwnik;
            //if (odpowiedz[1] == Uzytkownik.Login)
            //{
            //    aktualnyGracz.Text = Uzytkownik.Login;
            //    czyZaczynam = true;
            //    aktualnyGracz.ForeColor = kolor2;
            //}
            //else
            //{
            //    aktualnyGracz.Text = Rozgrywka.Przeciwnik;
            //    czyZaczynam = false;
            //    aktualnyGracz.ForeColor = kolor1;
            //}
            //int koniec = odpowiedz.Length;
            //for (int i = 2; i < koniec; i++)
            //{
            //    string litera = odpowiedz[i].ToString();
            //    Przycisk label;
            //    if (tableLayoutPanel1.Controls[i - 2] is Przycisk)
            //    {
            //        label = (Przycisk)tableLayoutPanel1.Controls[i - 2];
            //        label.Text = litera;
            //        label.ForeColor = Color.LightGray;
            //    }
            //}
            //if (!czyZaczynam)
            //{
            //    timer1.Start();
            //}
            //timer2_koniecGry.Start();
        }
        private void click_Label(object sender, EventArgs e)
        {
            if (!czyZaczynam)
                return;
            przycisk_click(sender, e);
        }
        private void przycisk_click(object sender, EventArgs e)
        {
            if (firstClicked != null && secondClick != null)
                return;
            Przycisk clickLabel = sender as Przycisk;
            if (clickLabel == null)
                return;
            if (clickLabel.ForeColor == Color.Black)
                return;
            if (czyZaczynam)
            {
                //TODO
                //String odp = AsynchronicznyKlient.zapytaj(Pytanie.komendy.zapisz_ruch,
                //    new object []{Rozgrywka.Nr_lobby, Uzytkownik.Login, Uzytkownik.Sesja, clickLabel.getIndeks()});
                //if (odp == "CzasUplynal" || odp == "error" || odp == "False")
                //{

                //    MessageBox.Show("Nie udane połączenie z serwerem");
                //    return;
                //}
            }
            liczba_ruchow++;
            if (firstClicked == null)
            {
                firstClicked = clickLabel;
                firstClicked.ForeColor = Color.Black;
                if (aktualnyGracz.Text == Rozgrywka.Przeciwnik)
                    firstClicked.BackColor = kolor1;
                else if (aktualnyGracz.Text == Uzytkownik.Instance.Login)
                    firstClicked.BackColor = kolor2;
                return;
            }
            secondClick = clickLabel;
            secondClick.ForeColor = Color.Black;
            if (aktualnyGracz.Text == Rozgrywka.Przeciwnik)
                secondClick.BackColor = kolor1;
            else if (aktualnyGracz.Text == Uzytkownik.Instance.Login)
                secondClick.BackColor = kolor2;
            if (firstClicked.Text == secondClick.Text)
            {
                if (czyZaczynam)
                {
                    wyniki_graczy[Uzytkownik.Instance.Login]+=10;
                }
                else
                {
                    wyniki_graczy[Rozgrywka.Przeciwnik] += 10;
                }
                odswierz_pola_wynikow();
            }
            else
            {
                Uzytkownik.wait(2000);
                firstClicked.BackColor = kolor;
                secondClick.BackColor = kolor;
                firstClicked.ForeColor = firstClicked.BackColor;
                secondClick.ForeColor = firstClicked.BackColor;
                if (czyZaczynam)
                {
                    aktualnyGracz.Text = Rozgrywka.Przeciwnik;
                    aktualnyGracz.ForeColor = kolor1;
                    timer1.Start();
                }
                else
                {
                    aktualnyGracz.Text = Uzytkownik.Instance.Login;
                    aktualnyGracz.ForeColor = kolor2;
                    timer1.Stop();
                }
                czyZaczynam = !czyZaczynam;
            }
            firstClicked = null;
            secondClick = null;

            CheckWinner();
        }
        void tick()
        {
        }
        public void odswierz_pola_wynikow()
        {
            g1_pkt.Text = wyniki_graczy[Uzytkownik.Instance.Login].ToString();
            g2_pkt.Text = wyniki_graczy[Rozgrywka.Przeciwnik].ToString();
        }

        private void CheckWinner()
        {
            Label label;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;
                if (label != null && label.ForeColor == label.BackColor)
                    return;
            }
            int punkty_1 = Convert.ToInt32(g1_pkt.Text); // czyzaczynam - login
            int punkty_2 = Convert.ToInt32(g2_pkt.Text);
            if (punkty_1 > punkty_2)
            {
                MessageBox.Show($"Wygrał użytkownik: {Uzytkownik.Instance.Login}. {Uzytkownik.Instance.Login} zyskałeś {punkty_1} punktów. Gratulacje!");
            }
            else if (punkty_1 < punkty_2)
            {
                MessageBox.Show($"Wygrał użytkownik: {Rozgrywka.Przeciwnik}. {Rozgrywka.Przeciwnik} zyskałeś {punkty_2} punktów. Gratulacje!");
            }
            else if (punkty_1 == punkty_2)
            {
                MessageBox.Show("Gra zakończyła się remisem.");
            }
            Uzytkownik.wait(2000);
            zakonczGre_Click(null, null);
        }
        private void wygeneruj_labele(int rozmiar)
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowCount = rozmiar;
            tableLayoutPanel1.ColumnCount = rozmiar;
            for (int i = 0; i < rozmiar * rozmiar; i++)
            {
                Przycisk przycisk = new Przycisk(i);
                przycisk.Font = l_wzorzec.Font;
                przycisk.Enabled = true;
                przycisk.ForeColor = przycisk.BackColor;
                przycisk.Dock = DockStyle.Fill;
                przycisk.TextAlign = ContentAlignment.MiddleCenter;
                przycisk.Click += new EventHandler(click_Label);
                tableLayoutPanel1.Controls.Add(przycisk);
            }
        }
        async void zakonczGre_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2_koniecGry.Stop();
            gra.Close();
        }
        private void timer1_Tick_2(object sender, EventArgs e)
        {
            if (!bg_stanGry.IsBusy)
            {
                bg_stanGry.RunWorkerAsync();
            }
        }
        private void timer2_koniec(object sender, EventArgs e)
        {
            czyKoniecGry();
        }
        async void czyKoniecGry()
        {
            //TODO
            timer2_koniecGry.Stop();
            //String odp =  AsynchronicznyKlient.zapytaj(Pytanie.komendy.czy_koniec_gry, 
            //    new object[] { Rozgrywka.Nr_lobby });
            //if (odp == "CzasUplynal" || odp == "error")
            //{
            //    MessageBox.Show("Nie udane połaczenie z serwerem");
            //    timer2_koniecGry.Start();
            //}
            //else if (odp == "True")
            //{
            //    MessageBox.Show("Gra zakonczona");
            //    zakonczGre_Click(null, null);
            //}
            //else
            //{
            //    timer2_koniecGry.Start();
            //}
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void g2_pkt_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = AsynchronicznyKlient.zapytaj(Pytanie.komendy.wczytaj_ruchy,
                new object[] {Rozgrywka.Nr_lobby, liczba_ruchow });
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
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
                    string[] dane_gry = odp.Split(';');
                    string[] gracz1 = dane_gry[0].Split(':');
                    string[] gracz2 = dane_gry[1].Split(':');
                    int wynik1;
                    wyniki_graczy[gracz1[0]] = Int32.Parse(gracz1[1]);
                    wyniki_graczy[gracz2[0]] = Int32.Parse(gracz2[1]);
                    odswierz_pola_wynikow();
                    string[] indeksy = dane_gry[2].Split(' ');
                    foreach (string s in indeksy)
                    {
                        if (s == "")
                        {
                            continue;
                        }
                        int indeks = Int32.Parse(s);
                        if (tableLayoutPanel1.Controls[indeks] is Przycisk)
                        {
                            Przycisk przycisk = tableLayoutPanel1.Controls[indeks] as Przycisk;
                            przycisk_click(przycisk, EventArgs.Empty);
                        }
                    }
                }
            }
        }

        private void backgroundWorker1_DoWork_1(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted_1(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e) //ukrywa po upływie kilku sekund obydwa obrazki
        {
            timer1.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClick.ForeColor = secondClick.BackColor;
            firstClicked = null;
            secondClick = null;
        }
    }
}