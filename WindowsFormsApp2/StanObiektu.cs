using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;



namespace WindowsFormsApp2
{
    public class StanObiektu
    {
        // Client socket.  
        public Socket socket = null;
        // Size of receive buffer.  
        public const int rozmiarBuffera = 256;
        // Receive buffer.  
        public byte[] buffer = new byte[rozmiarBuffera];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();
    }
}