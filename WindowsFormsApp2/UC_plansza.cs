﻿using System;
using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsApp2
{
    public partial class UC_plansza : UserControl
    {
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

        Label firstClicked, secondClick;
        Color kolor;
        Color kolor1 = Color.LightSteelBlue;
        Color kolor2 = Color.CornflowerBlue;
        int pkt_gr1 = 0;
        int pkt_gr2 = 0;
        int liczba_ruchow = 0;
        Gra gra;
        Boolean czyZaczynam;
        public UC_plansza(Form form)
        {
            InitializeComponent();
            gra = form as Gra;
        }
        public async void WczytajPlansze()
        {
            String odp = await AsynchronicznyKlient.zapytaj("pobierz_plansze: " + aplikacja.Nr_lobby);
            if (odp == "error")
            {
                return;
            }
            string[] odpowiedz = odp.Split(' ');
            int rozmiar = Int32.Parse(odpowiedz[0]);
            wygeneruj_labele(rozmiar);
            gracz1.Text = aplikacja.Login;
            gracz2.Text = aplikacja.Przeciwnik;
            if (odpowiedz[1] == aplikacja.Login)
            {
                aktualnyGracz.Text = aplikacja.Login;
                czyZaczynam = true;
                aktualnyGracz.ForeColor = kolor2;
            }
            else
            {
                aktualnyGracz.Text = aplikacja.Przeciwnik;
                czyZaczynam = false;
                aktualnyGracz.ForeColor = kolor1;
            }
            int koniec = odpowiedz.Length;
            for (int i = 2; i < koniec; i++)
            {
                string litera = odpowiedz[i].ToString();
                Przycisk label;
                if (tableLayoutPanel1.Controls[i - 2] is Przycisk)
                {
                    label = (Przycisk)tableLayoutPanel1.Controls[i - 2];
                    label.Text = litera;
                    label.ForeColor = Color.LightGray;
                }
            }
            if (!czyZaczynam)
            {
                timer1.Start();
            }
            timer2_koniecGry.Start();
        }
        private void click_Label(object sender, EventArgs e)
        {
            if (!czyZaczynam)
                return;
            przycisk_click(sender, e);
        }
        private async void przycisk_click(object sender, EventArgs e)
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
                String odp = await AsynchronicznyKlient.zapytaj("zapisz_ruch: " + aplikacja.Nr_lobby + " " + clickLabel.getIndeks());
                if (odp == "False")
                {
                    return;
                }
            }
            liczba_ruchow++;
            if (firstClicked == null)
            {
                firstClicked = clickLabel;
                firstClicked.ForeColor = Color.Black;
                if (aktualnyGracz.Text == aplikacja.Przeciwnik)
                    firstClicked.BackColor = kolor1;
                else if (aktualnyGracz.Text == aplikacja.Login)
                    firstClicked.BackColor = kolor2;

                return;
            }
            secondClick = clickLabel;
            secondClick.ForeColor = Color.Black;
            if (aktualnyGracz.Text == aplikacja.Przeciwnik)
                secondClick.BackColor = kolor1;
            else if (aktualnyGracz.Text == aplikacja.Login)
                secondClick.BackColor = kolor2;
            if (firstClicked.Text == secondClick.Text)
            {
                if (czyZaczynam)
                {
                    pkt_gr1 += 10;
                    g1_pkt.Text = pkt_gr1.ToString();
                }
                else
                {
                    pkt_gr2 += 10;
                    g2_pkt.Text = pkt_gr2.ToString();
                }
            }
            else
            {
                aplikacja.wait(2000);
                firstClicked.BackColor = kolor;
                secondClick.BackColor = kolor;
                firstClicked.ForeColor = firstClicked.BackColor;
                secondClick.ForeColor = firstClicked.BackColor;
                if (czyZaczynam)
                {
                    aktualnyGracz.Text = aplikacja.Przeciwnik;
                    aktualnyGracz.ForeColor = kolor1;
                    timer1.Start();
                }
                else
                {
                    aktualnyGracz.Text = aplikacja.Login;
                    aktualnyGracz.ForeColor = kolor2;
                    timer1.Stop();
                }
                czyZaczynam = !czyZaczynam;
            }
            firstClicked = null;
            secondClick = null;

            CheckWinner();
        }
        async void tick()
        {
            string odp = await AsynchronicznyKlient.zapytaj("wczytaj_ruchy: " + aplikacja.Nr_lobby + " " + liczba_ruchow);
            if (odp != "error" && odp != "")
            {
                string[] indeksy = odp.Split(' ');
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
                MessageBox.Show($"Wygrał użytkownik: {aplikacja.Login}. {aplikacja.Login} zyskałeś {punkty_1} punktów. Gratulacje!");
            }
            else if (punkty_1 < punkty_2)
            {
                MessageBox.Show($"Wygrał użytkownik: {aplikacja.Przeciwnik}. {aplikacja.Przeciwnik} zyskałeś {punkty_2} punktów. Gratulacje!");
            }
            else if (punkty_1 == punkty_2)
            {
                MessageBox.Show($"Gra zakończyła się remisem.");
            }
            aplikacja.wait(2000);
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
            tick();
        }
        private void timer2_koniec(object sender, EventArgs e)
        {
            czyKoniecGry();
        }
        async void czyKoniecGry()
        {
            timer2_koniecGry.Stop();
            String odp = await AsynchronicznyKlient.zapytaj("czyKoniecGry: " + aplikacja.Nr_lobby);
            if (odp == "True")
            {
                MessageBox.Show("Gra zakonczona");
                zakonczGre_Click(null, null);
            }
            else
            {
                timer2_koniecGry.Start();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void g2_pkt_Click(object sender, EventArgs e)
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