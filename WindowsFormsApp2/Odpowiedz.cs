using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public class Odpowiedz
    {

        private object[] argumenty;

        public Odpowiedz(object[] argumenty)
        {
            this.argumenty = argumenty;
        }
        public bool czy_wzrocono_error()
        {
            if (argumenty != null && argumenty.Length > 0)
            {
                string arg = argumenty[0].ToString();
                if (arg.Equals("error"))
                {
                    MessageBox.Show("Problem po stronie serwera", "Problem");

                }
                else if (arg.Equals("CzasUplynal"))
                {
                    MessageBox.Show("Nie udane polaczenie z serverem!", "Problem");
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        
        public object[] Argumenty { get => argumenty; set => argumenty = value; }

    }
}
