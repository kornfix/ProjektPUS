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
    public partial class UC_edycja_parametru : UserControl
    {
        private int wiekszy = 23;
        public enum wyk_tryb
        {
            imie = 1,
            nazwisko = 2,
            email = 3,
            haslo = 4        
        }
        private wyk_tryb tryb;
        private Boolean edytowany = false;
        private Boolean wynik_walidacji = false;
        private string nazwa_parametru;
        private string stara_wartosc;
        private Label l_haslo2;
        private TextBox txt_haslo2;
        public UC_edycja_parametru(wyk_tryb wk)
        {
            InitializeComponent();
            this.tryb = wk;
            this.nazwa_parametru = wk.ToString();
            l_parametr.Text = FirstLetterToUpper(nazwa_parametru);
            // tryb haslo
            if(tryb == wyk_tryb.haslo)
            {
                l_haslo2 = new Label();
                l_haslo2.Text = "Powtórz";
                l_haslo2.AutoSize = true;
                l_haslo2.Visible = false;
                l_haslo2.Location = new Point(l_parametr.Location.X, l_parametr.Location.Y + l_parametr.Height + 10);
                this.Controls.Add(l_haslo2);

                txt_haslo2 = new TextBox();
                txt_haslo2.Visible = false;
                txt_haslo2.PasswordChar = '*';
                txt_haslo2.Location = new Point(txt_edytowany.Location.X, txt_edytowany.Location.Y + txt_edytowany.Height + 2);
                txt_haslo2.Width = txt_edytowany.Width;
                this.Controls.Add(txt_haslo2);

                txt_edytowany.Text = "123456";
                txt_edytowany.PasswordChar = '*';              
            }
            wczytajWartoscParametru();
        }
        private async void wczytajWartoscParametru()
        {
            if (tryb != wyk_tryb.haslo)
            {
                stara_wartosc = await AsynchronousClient.zapytaj("uzyt_wartosc_parametru: " + aplikacja.Login + " " + nazwa_parametru);
                txt_edytowany.Text = stara_wartosc;
            }
        }

        private void btn_edycja_Click(object sender, EventArgs e)
        {
            if(!edytowany)
            {
                btn_edycja.Text = "Anuluj";
                txt_edytowany.Enabled = true;
                if(tryb == wyk_tryb.haslo)
                {
                    this.Height = this.Height + wiekszy;
                    btn_edycja.Location = new Point(btn_edycja.Location.X, btn_edycja.Location.Y + wiekszy);
                    l_haslo2.Visible = true;
                    txt_haslo2.Visible = true;
                    txt_edytowany.Clear();
                    txt_haslo2.Clear();
                }
                edytowany = !edytowany;
            }else
            {
                btn_edycja.Text = "Edytuj";
                errorProvider1.Clear();
                txt_edytowany.Text = stara_wartosc;
                txt_edytowany.Enabled = false;
                if (tryb == wyk_tryb.haslo)
                {
                    this.Height = this.Height - wiekszy;
                    btn_edycja.Location = new Point(btn_edycja.Location.X, btn_edycja.Location.Y - wiekszy);
                    l_haslo2.Visible = false;
                    txt_haslo2.Visible = false;
                    txt_edytowany.Text = "123456";
                }
                edytowany = !edytowany;
            }
        }
        public async Task<Boolean> SprawdzEdycje()
        {
            if (edytowany && stara_wartosc != txt_edytowany.Text)
            {
                switch (tryb)
                {
                    case wyk_tryb.email:
                        wynik_walidacji = await Walidacja.WalidacjaEmail(txt_edytowany, errorProvider1);
                        break;
                    case wyk_tryb.imie:
                        wynik_walidacji = await Walidacja.WalidacjaImienia(txt_edytowany, errorProvider1);
                        break;
                    case wyk_tryb.nazwisko:
                        wynik_walidacji = await Walidacja.WalidacjaNazwiska(txt_edytowany, errorProvider1);
                        break;
                    case wyk_tryb.haslo:
                        Boolean wynikHaslo1= await Walidacja.WalidacjaHaslo1(txt_edytowany, errorProvider1);
                        if (wynikHaslo1)
                        {
                            Boolean wynikHaslo2 = await Walidacja.WalidacjaHaslo2(txt_edytowany.Text,txt_haslo2, errorProvider1);
                            wynik_walidacji = wynikHaslo2;
                        }
                        break;
                }
                return wynik_walidacji;
            }else
            {
                return true;
            }
        }
        public async Task<Boolean> ZakonczEdycje()
        {
            Boolean wynik_edycji = true;
            if (wynik_walidacji)
            {
                String odp = await AsynchronousClient.zapytaj("uzyt_zm_par: " + aplikacja.Login + " " + nazwa_parametru + " " + txt_edytowany.Text);
                MessageBox.Show(odp, nazwa_parametru);
                if (odp == "True")
                {
                    switch (tryb)
                    {
                        case wyk_tryb.email:
                            aplikacja.Email = txt_edytowany.Text;
                            break;
                        case wyk_tryb.imie:
                            aplikacja.Imie = txt_edytowany.Text;
                            break;
                        case wyk_tryb.nazwisko:
                            aplikacja.Nazwisko = txt_edytowany.Text;
                            break;
                    }
                }else
                {
                    wynik_edycji = false;
                    MessageBox.Show("Wystapił błąd podczas edycji pola"+ nazwa_parametru);
                }
            }
            return wynik_edycji;
        }

        public string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

    }
}
