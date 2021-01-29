using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class StanObiektu
    {
        public const int rozmiarBuffera = 1024;
        public byte[] buffer = new byte[rozmiarBuffera];
        public StringBuilder sb = new StringBuilder();
        public Socket socket = null;
    }
}
