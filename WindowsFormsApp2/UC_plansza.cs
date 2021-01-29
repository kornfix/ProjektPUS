using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class UC_plansza : UserControl
    {
        class Przycisk : Label
        {
            int indeks;
            static int licznik = 0;
            public Przycisk()
            {
                indeks = licznik++;
            }
            public int getIndeks()
            {
                return indeks;
            }
        }


        Label firstClicked, secondClick;
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
            String odp = await AsynchronicznyKlient.zapytaj("pobierz_plansze: " + aplikacja.Nr_lobby );
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
            }
            else
            {
                aktualnyGracz.Text = aplikacja.Przeciwnik;
                czyZaczynam = false;
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
                }
            }
            if (!czyZaczynam)
            {
                timer1.Start();
            }
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

            Przycisk clickLabel = sender as Przycisk; //  as próbuje przekonwertowac sender na label

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
                return;
            }

            secondClick = clickLabel;
            secondClick.ForeColor = Color.Black;

            CheckWinner();

            if (firstClicked.Text == secondClick.Text)
            {
                // wyślij inf na server; uzykownik.Nr_lobby " " zmienna bool czy koniec gry + ruch
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
                // wyślij inf na server oraz to że zaczyna drugi gracz // nie aktualne ??
                // żle kliknął
                aplikacja.wait(2000);
                firstClicked.ForeColor = firstClicked.BackColor;
                secondClick.ForeColor = firstClicked.BackColor;
                if (czyZaczynam)
                {
                    aktualnyGracz.Text = aplikacja.Przeciwnik;
                    timer1.Start();
                }
                else
                {
                    aktualnyGracz.Text = aplikacja.Login;
                    timer1.Stop();
                }
                czyZaczynam = !czyZaczynam;
            }
            firstClicked = null;
            secondClick = null;

        }
        async void tick()
        {
            string odp = await AsynchronicznyKlient.zapytaj("wczytaj_ruchy: " + aplikacja.Nr_lobby + " " + liczba_ruchow );
            if (odp != "error" && odp != "")
            {
                string[] indeksy = odp.Split(' ');
                foreach (string s in indeksy)
                {
                    if (s == "")
                    {
                        continue;
                    }else if(s == "koniec")
                    {
                        gra.Close();
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
            // Sprawdz kto ma wiecej pkt
            MessageBox.Show("You matched all inccons.");
            //Close();
        }
        private void wygeneruj_labele(int rozmiar)
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowCount = rozmiar;
            tableLayoutPanel1.ColumnCount = rozmiar;
            for (int i = 0; i < rozmiar * rozmiar; i++)
            {

                Przycisk przycisk = new Przycisk();
                przycisk.Font = l_wzorzec.Font;
                przycisk.Enabled = true;
                przycisk.ForeColor = przycisk.BackColor;
                przycisk.Dock = DockStyle.Fill;
                przycisk.TextAlign = ContentAlignment.MiddleCenter;
                przycisk.Click += new EventHandler(click_Label);
                tableLayoutPanel1.Controls.Add(przycisk);
            }

        }

        private void zakonczGre_Click(object sender, EventArgs e)
        {
            // jeszcze tutaj kod konca gry;
        }

        private void timer1_Tick_2(object sender, EventArgs e)
        {
            tick();
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
