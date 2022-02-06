using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Odpowiedz
    {
        private object[] argumenty;
        public object[] Argumenty { get => argumenty; set => argumenty = value; }

        public Odpowiedz(object[] argumenty)
        {
            this.argumenty = argumenty;
        }

        public Odpowiedz()
        {
            argumenty = new object[1];
            argumenty[0] = "error";
        }
    }
}
