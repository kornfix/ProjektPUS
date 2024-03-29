﻿using System;
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
    public partial class Menu : Form
    {
        Dictionary<wybrany_tryb, UserControl> kontrolki;
        enum wybrany_tryb
        {
            logowanie = 0,
            rejestracja = 1,
            menu = 2
        }

        private void zmiana_trybu(wybrany_tryb wk)
        {
            foreach (var item in kontrolki)
            {
                if(item.Key == wk)
                {
                    item.Value.Visible = true;
                }
                else
                {
                    item.Value.Visible = false;
                }
            }
        }


        public Menu()
        {
            InitializeComponent();
            kontrolki = new Dictionary<wybrany_tryb, UserControl>();
        }
        public void tryb_logowanie()
        {

            if(!kontrolki.ContainsKey(wybrany_tryb.logowanie))
            {
                UC_logowanie uC_Logowanie = new UC_logowanie(this);
                kontrolki.Add(wybrany_tryb.logowanie, uC_Logowanie);
                TLP_MENU.Controls.Add(uC_Logowanie);
                //uC_Logowanie.Dock = DockStyle.Fill;
            }
            zmiana_trybu(wybrany_tryb.logowanie);
        }
        public void tryb_rejestracja()
        {

            if (!kontrolki.ContainsKey(wybrany_tryb.rejestracja))
            {
                UC_rejestracja uC_Rejestracja = new UC_rejestracja(this);
                kontrolki.Add(wybrany_tryb.rejestracja, uC_Rejestracja);
                TLP_MENU.Controls.Add(uC_Rejestracja);
                //uC_Rejestracja.Dock = DockStyle.Fill;
            }
            zmiana_trybu(wybrany_tryb.rejestracja);
        }
        public void tryb_menu()
        {

            if (!kontrolki.ContainsKey(wybrany_tryb.menu))
            {
                UC_menu uC_Menu = new UC_menu(this);
                kontrolki.Add(wybrany_tryb.menu, uC_Menu);
                TLP_MENU.Controls.Add(uC_Menu);
                //uC_Menu.Dock = DockStyle.Fill;
            }
            zmiana_trybu(wybrany_tryb.menu);
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            tryb_logowanie();
        }


    }
}
