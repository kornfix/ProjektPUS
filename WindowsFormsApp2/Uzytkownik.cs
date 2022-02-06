using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public class Uzytkownik
    {
        private static Uzytkownik _instance;
        private string sesja;
        private  string imie;
        private  string nazwisko;
        private  string login;
        private  string email;
        public  string Imie { get => imie; set => imie = value; }
        public  string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public  string Login { get => login; set => login = value; }
        public  string Email { get => email; set => email = value; }
        public  string Sesja { get => sesja; set => sesja = value; }
        public static Uzytkownik Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Uzytkownik();

                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        public static void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
        public static void clear()
        {
            _instance = null;
        }
    }
}
