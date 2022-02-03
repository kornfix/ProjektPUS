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
        private List<Task<Error>> zadania = new List<Task<Error>>();
        public UC_rejestracja(Form form)
        {
            menu = form as Menu;
            InitializeComponent();
        }
        private async void button_anuluj_Click(object sender, EventArgs e)
        {
            menu.tryb_logowanie();
        }
        private async void button_rejestracja_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (backgroundWorker1.IsBusy != true)
            {
                menu.tryb_czekanie();
                backgroundWorker1.RunWorkerAsync();
            }
        }      
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Kod walidacyjny
            zadania.Clear();
            var walidacjaEmail = Walidacja.WalidacjaEmail(txt_email);
            zadania.Add(walidacjaEmail);
            var walidacjaHaslo1 = Walidacja.WalidacjaHaslo1(txt_haslo1);
            zadania.Add(walidacjaHaslo1);
            var walidacjaHaslo2 = Walidacja.WalidacjaHaslo2(txt_haslo1.Text, txt_haslo2);
            zadania.Add(walidacjaHaslo2);
            var walidacjaLoginu = Walidacja.WalidacjaLoginu(txt_login);
            zadania.Add(walidacjaLoginu);
            var walidacjaImienia = Walidacja.WalidacjaImienia(txt_imie);
            zadania.Add(walidacjaImienia);
            var walidacjaNazwiska = Walidacja.WalidacjaNazwiska(txt_nazwisko);
            zadania.Add(walidacjaNazwiska);
            Task.WaitAll(zadania.ToArray());
            Boolean udanaWalidacja = true;
            foreach (Task<Error> task in zadania)
            {
                if (task.Result != null)
                {
                    e.Cancel = true;
                    udanaWalidacja = false;
                    break;
                }
            }
            if (udanaWalidacja)
            {
                string email = " email:" + txt_email.Text;
                string haslo = " haslo:" + txt_haslo1.Text;
                string login = " login:" + txt_login.Text;
                string imie = " imie:" + txt_imie.Text;
                string nazwisko = " nazwisko:" + txt_nazwisko.Text;
                // Kod wyslania prośby do serwera
                // oczekiwanie prośby
                String odp = AsynchronicznyKlient.zapytaj("zarejestruj_uzytkownika: " + email + haslo + login
                    + imie + nazwisko);
                
                if (odp == "CzasUplynal" || odp == "error")
                {
                    // problem z serwerem udana 
                    MessageBox.Show("Nie udane wyjscie z gry");
                }
                else
                {
                    // prosba udana 
                    e.Result = odp;
                }
                // logowanie do menu
                //menu.tryb_menu();
                // prośba nie udana wyświetlenie inf
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.ToString(),"Problem");
            }else if(e.Cancelled)
            {
                foreach (Task<Error> task in zadania)
                {
                    if (task.Result != null)
                    {
                        Error error = task.Result;
                        errorProvider1.SetError(error.Control, error.Tresc);
                    }
                }
                menu.tryb_rejestracja();
            }else if (e.Result != null)
            {
                if (e.Result.ToString() == "true")
                {
                    Uzytkownik.Imie = txt_imie.Text;
                    Uzytkownik.Nazwisko = txt_nazwisko.Text;
                    Uzytkownik.Login = txt_login.Text;
                    Uzytkownik.Email = txt_email.Text;
                    menu.tryb_menu();
                    menu.reset_rejestacji();
                }else
                {
                    MessageBox.Show("Nie udana rejestracja!");
                }
            }
        }
    }
}
