using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    class Error
    {
        private Control control;
        private String tresc;
        public Error(Control control, string tresc)
        {
            this.control = control;
            this.Tresc = tresc;
        }

        public Control Control { get => control; set => control = value; }
        public string Tresc { get => tresc; set => tresc = value; }
    }
}
