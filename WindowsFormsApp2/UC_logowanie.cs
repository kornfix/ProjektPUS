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
    public partial class UC_logowanie : UserControl
    {
        private Menu menu = null;
        public UC_logowanie(Form form)
        {
            menu = form as Menu;
            InitializeComponent();
        }

        private async void buttonZaloguj_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            var walidacjaLoginu = WalidacjaLoginu();
            var walidacjaHasla = WalidacjaHasla();
            Task[] zadania = new Task[] { walidacjaLoginu, walidacjaHasla };

            await Task.WhenAll(zadania);
            aplikacja.wait(1000);
            if (!walidacjaLoginu.Result || !walidacjaHasla.Result)
            {
                menu.tryb_logowanie();
                return;
            }
            menu.tryb_czekanie();
            // Zapytanie do serwera z tym stringiem
            string zapytanie = "zaloguj: " + textBoxLogin1.Text + " " + textBoxHaslo1.Text;
            String odp = await AsynchronicznyKlient.zapytaj(zapytanie);
            zalogowanieUzytkownika(odp);
        }
        async void zalogowanieUzytkownika(string odp)
        {
            String[] slowa = odp.Split(' ');
            // prosba udana 
            if (slowa.Length == 5)
            {
                aplikacja.Imie = slowa[0];
                aplikacja.Nazwisko = slowa[1];
                aplikacja.Login = slowa[2];
                aplikacja.Email = slowa[3];
                aplikacja.Sesja = slowa[4];
                menu.tryb_menu();
                menu.reset_rejestacji();
            }
            // prosba nieudana
            else if (slowa.Length == 1 && slowa[0] == "bledneDane")
            {
                menu.tryb_logowanie();
                errorProvider1.SetError(linkLabelZapomnialem, "Błędne dane");
            }
            else if (slowa.Length == 1 && slowa[0] == "uzytkownik_jest_juz_zalogowany")
            {
                DialogResult dialogResult = MessageBox.Show("Powyższy użytkownik jest już zalogowany! Czy chcesz wymusić jego wylogowanie?", "Logowanie", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    String wyl = await AsynchronicznyKlient.zapytaj("wyloguj: " + textBoxLogin1.Text);
                    String zaloguj = await AsynchronicznyKlient.zapytaj("zaloguj: " + textBoxLogin1.Text + " " + textBoxHaslo1.Text);
                    zalogowanieUzytkownika(zaloguj);
                }
                else
                {
                    menu.tryb_logowanie();
                }
            }
        }

        private void button_rejestracja_Click(object sender, EventArgs e)
        {
            menu.tryb_rejestracja();
        }

        async Task<Boolean> WalidacjaLoginu()
        {
            String login = textBoxLogin1.Text;
            errorProvider1.SetError(textBoxLogin1, "");

            if (login.Length == 0)
            {
                errorProvider1.SetError(textBoxLogin1, "Nie podano loginu!");
                return false;
            }
            return true;
        }
        async Task<Boolean> WalidacjaHasla()
        {
            String haslo = textBoxHaslo1.Text;
            errorProvider1.SetError(textBoxHaslo1, "");
            if (haslo.Length == 0)
            {
                errorProvider1.SetError(textBoxHaslo1, "Nie podano hasła!");
                return false;
            }
            return true;
        }
    }
}
