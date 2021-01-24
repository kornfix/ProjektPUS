﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace WindowsFormsApp2
{
    public partial class UC_rejestracja : UserControl
    {
        private Menu menu = null;
        public UC_rejestracja(Form form)
        {
            menu = form as Menu;
            InitializeComponent();
        }

        private async void button_rejestracja_Click(object sender, EventArgs e)
        {
            // Kod walidacyjny
            Boolean walidacjaEmail = await WalidacjaEmail();
            Boolean walidacjaHaslo1 = await WalidacjaHaslo1();
            Boolean walidacjaHaslo2 = await WalidacjaHaslo2();
            Boolean walidacjaLoginu = await  WalidacjaLoginu();
            Boolean walidacjaImienia = await WalidacjaImienia();
            Boolean walidacjaNazwiska = await WalidacjaNazwiska();
            if(!walidacjaEmail || !walidacjaHaslo1 || !walidacjaHaslo2 || 
                !walidacjaLoginu || !walidacjaImienia || !walidacjaNazwiska)
            {
                return;
            }
            string email = " email:" + txt_email.Text;
            string haslo = " haslo:" + txt_haslo1.Text;
            string login = " login:" + txt_login.Text;
            string imie = " imie:" + txt_imie.Text;
            string nazwisko = " nazwisko:" + txt_nazwisko.Text;
            // Kod wyslania prośby do serwera
            string zapytanie = "zarejestruj_uzytkownika: " + email + haslo + login
                + imie + nazwisko + " <EOF>";
            AsynchronousClient asynchronousClient = new AsynchronousClient();
            asynchronousClient.StartClient(zapytanie);
            // oczekiwanie prośby
            while (asynchronousClient.Odpowiedz== "")
            {
            }
            // prosba udana 
            if(asynchronousClient.Odpowiedz == "true")
            {
                uzytkownik.Imie = txt_imie.Text;
                uzytkownik.Nazwisko = txt_nazwisko.Text;
                uzytkownik.Login = txt_login.Text;
                menu.tryb_menu();
                menu.reset_rejestacji();
            }
            // logowanie do menu
            //menu.tryb_menu();
            // prośba nie udana wyświetlenie inf

        }

        private void button_anuluj_Click(object sender, EventArgs e)
        {
            menu.tryb_logowanie();
        }
        bool czyPrawidlowyEmail(String email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        async Task<Boolean> WalidacjaEmail()
        {
            errorProvider1.Clear();
            String email = txt_email.Text;
            
            if (email == "")
            {
                errorProvider1.SetError(txt_email, "Email jest wymagany!");
                return false;
            }
            else if (!czyPrawidlowyEmail(email))
            {
                errorProvider1.SetError(txt_email, "Podany emial jest nieprawidłowy!");
                return false;
            }
            else if (SprawdzenieCzyMailIstnieje(email))
            {
                errorProvider1.SetError(txt_email, "Podany email już istnieje!");
                return false;
            }

            return true;
        }
        bool SprawdzenieCzyMailIstnieje(String email)
        {
            AsynchronousClient asynchronousClient = new AsynchronousClient();
            asynchronousClient.StartClient("sprawdz_email: " + email + " <EOF>");
            while (asynchronousClient.Odpowiedz == "")
            {
            }
            if (asynchronousClient.Odpowiedz == "false")
            {
                return false;
            }
            else
            {

                return true;
            }
        }
        async Task<Boolean> WalidacjaHaslo1()
        {
            String haslo1 = txt_haslo1.Text;
            errorProvider1.SetError(txt_haslo1, "");
            if (haslo1.Length == 0)
            {
                errorProvider1.SetError(txt_haslo1,"Hasło jest wymagane!");
                return false;
            }
            else if (haslo1.Length < 6)
            {
                errorProvider1.SetError(txt_haslo1, "Hasło musi posiadać przynajmniej 6 znaków");
                return false;
            }
            return true;
        }
        async Task<Boolean> WalidacjaHaslo2()
        {
            String haslo1 = txt_haslo1.Text;
            String haslo2 = txt_haslo2.Text;
            errorProvider1.SetError(txt_haslo2, "");
            if (haslo2.Length == 0)
            {
                errorProvider1.SetError(txt_haslo2, "Powtórz hasło!");
                return false;
            }
            else if (haslo2 != haslo1)
            {
                errorProvider1.SetError(txt_haslo2, "Podane hasła muszą być takie same!");
                return false;
            }
            return true;
        }
        async Task<Boolean> WalidacjaLoginu()
        {
            String login = txt_login.Text;
            errorProvider1.SetError(txt_login, "");
            
            if (login.Length ==0)
            {
                errorProvider1.SetError(txt_login,"Nazwa użytkownika jest wymagana!");
                return false;
            }
            else if (SprawdzenieCzyLoginIstnieje(login))
            {
                errorProvider1.SetError(txt_login, "Podany login już istnieje!");
                return false;
            }
            return true;
        }
        bool SprawdzenieCzyLoginIstnieje(String login)
        {
            AsynchronousClient asynchronousClient = new AsynchronousClient();
            asynchronousClient.StartClient("sprawdz_login: " + login + " <EOF>");
            while (asynchronousClient.Odpowiedz == "")
            {
            }
            if (asynchronousClient.Odpowiedz == "false")
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        async Task<Boolean> WalidacjaImienia()
        {
            String imie = txt_imie.Text;
            errorProvider1.SetError(txt_imie, "");
            if (imie.Length == 0)
            {
                errorProvider1.SetError(txt_imie, "Imię jest wymagane!");
                return false;
            }
            return true;
        }
        async Task<Boolean> WalidacjaNazwiska()
        {
            String nazwisko = txt_nazwisko.Text;
            errorProvider1.SetError(txt_nazwisko, "");
            if (nazwisko.Length == 0)
            {
                errorProvider1.SetError(txt_nazwisko, "Nazwisko jest wymagane!");
                return false;
            }
            return true;
        }
    }
}