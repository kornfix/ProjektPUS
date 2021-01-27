using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class UC_plansza : UserControl
    {
        Label firstClicked, secondClick;
        int counter = 0;
        Gra gra;
        Label label;

        public UC_plansza(Form form)
        {
            InitializeComponent();
            gra = form as Gra;
        }

        public async void WczytajPlnasze()
        {
            AsynchronousClient asynchronousClient = new AsynchronousClient();
            String odp = await asynchronousClient.StartClient("pobierz_plansze: " + " <EOF>");

            string[] odpowiedz = odp.Split(' ');
            int rozmiar = odpowiedz.Length;

            for (int i = 0; i < rozmiar; i++)
            {
                string pary = odpowiedz[i];
                string[] dane = pary.Split(':');

                int x = Convert.ToInt32(dane[0]);
                string litera = dane[1].ToString();

                if (tableLayoutPanel1.Controls[i] is Label)
                {
                    label = (Label)tableLayoutPanel1.Controls[x];
                }
                else
                {
                    continue;
                }
                label = (Label)tableLayoutPanel1.Controls[x];
                label.Text = litera;
            }
        }
        /*
        private void click_Label(object sender, EventArgs e)
        {
            if (firstClicked != null && secondClick != null)
                return;

            Label clickLabel = sender as Label; //  as próbuje przekonwertowac sender na label

            if (clickLabel == null)
                return;

            if (clickLabel.ForeColor == Color.Black)
                return;

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
                firstClicked = null;
                secondClick = null;

                counter = counter + 10;
                //ScoreCounter.Text = Convert.ToString(counter);
            }
            else
            {
                timer1.Start();
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

            MessageBox.Show("You matched all inccons.");
            //Close();
        }

        private void timer1_Tick(object sender, EventArgs e) //ukrywa po upływie kilku sekund obydwa obrazki
        {
            timer1.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClick.ForeColor = secondClick.BackColor;

            firstClicked = null;
            secondClick = null;
        }
        */
    }
}
