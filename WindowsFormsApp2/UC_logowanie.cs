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
            var walidacjaLoginu = WalidacjaLoginu();
            var walidacjaHasla = WalidacjaHasla();
            Task[] zadania = new Task[] { walidacjaLoginu, walidacjaHasla };
            await Task.WhenAll(zadania);
            if (!walidacjaLoginu.Result || !walidacjaHasla.Result)
            {
                return;
            }
            // Zapytanie do serwera z tym stringiem
            string zapytanie = "zaloguj: "+ textBoxLogin1.Text + " " + textBoxHaslo1.Text;
            String odp = await AsynchronousClient.zapytaj(zapytanie);
            String[] slowa = odp.Split(' ');
            // prosba udana 
            if (slowa.Length == 4)
            {
                uzytkownik.Imie = slowa[0];
                uzytkownik.Nazwisko = slowa[1];
                uzytkownik.Login = slowa[2];
                uzytkownik.Email = slowa[3];
                menu.tryb_menu();
                menu.reset_rejestacji();
            }
            // prosba nieudana
            else if(slowa.Length == 1 && slowa[0] == "bledneDane")
            {
                errorProvider1.SetError(linkLabelZapomnialem, "Błędne dane");
            }
            
            // Kod odpwoiedzi
            // jesli odpowiedż ma true w tab[0] to zalogowano poprawnie a reszta 
            // tab ma inf o koncie 
            // co zapisujemy w jakieś klasie najlepiej statycznej zalogowany gracz
            // dodajemy uc_menu do panelu 
            // a to ustaiwamy na false ;
            // jesli false to wyswietlenie inf ze blad logowania
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
