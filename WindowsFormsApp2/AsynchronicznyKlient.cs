using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp2
{
    public class AsynchronicznyKlient
    {
        private const int port = 11000;
        private ManualResetEvent polaczenieWykonane = new ManualResetEvent(false);
        private ManualResetEvent wyslanieWykonane = new ManualResetEvent(false);
        private ManualResetEvent odebranieWykonane = new ManualResetEvent(false); 
        private String odpowiedz = String.Empty;
        // Funkcja tworząca pojedyńcze zapytania
        public async static Task<String> zapytaj(string zapytanie)
        {
            AsynchronicznyKlient asynchronousClient = new AsynchronicznyKlient();
            String odp = await asynchronousClient.StartKlienta(zapytanie + " <EOF>");
            return odp;
        }


        public async Task<String> StartKlienta(string pytanie)
        {
            try
            {
                IPHostEntry ipHostInfo = await Dns.GetHostEntryAsync(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint zdalnyPK = new IPEndPoint(ipAddress, port);

                Socket klient = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                klient.BeginConnect(zdalnyPK,
                    new AsyncCallback(PolaczCallback), klient);
                polaczenieWykonane.WaitOne();

                Wyslij(klient, pytanie);
                wyslanieWykonane.WaitOne();

                Odbierz(klient);
                odebranieWykonane.WaitOne();

                klient.Shutdown(SocketShutdown.Both);
                klient.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                odpowiedz = "error";
            }
            return odpowiedz;
        }

        private void PolaczCallback(IAsyncResult ar)
        {
            try
            {
                Socket klient = (Socket)ar.AsyncState;
                klient.EndConnect(ar);
                polaczenieWykonane.Set();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void Odbierz(Socket klient)
        {
            try
            {
                StanObiektu stan = new StanObiektu();
                stan.socket = klient;
                klient.BeginReceive(stan.buffer, 0, StanObiektu.rozmiarBuffera, 0,
                    new AsyncCallback(OdbierzCallback), stan);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void OdbierzCallback(IAsyncResult ar)
        {
            try
            {
                StanObiektu stan = (StanObiektu)ar.AsyncState;
                Socket klient = stan.socket;
                int bajtyOdczytane = klient.EndReceive(ar);

                if (bajtyOdczytane > 0)
                {
                    stan.sb.Append(Encoding.ASCII.GetString(stan.buffer, 0, bajtyOdczytane));
                    klient.BeginReceive(stan.buffer, 0, StanObiektu.rozmiarBuffera, 0,
                        new AsyncCallback(OdbierzCallback), stan);
                }
                else
                {
                    if (stan.sb.Length > 1)
                    {
                        odpowiedz = stan.sb.ToString();
                    }
                    odebranieWykonane.Set();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void Wyslij(Socket klient, String dane)
        {  
            byte[] bajtoweDane = Encoding.ASCII.GetBytes(dane);
            klient.BeginSend(bajtoweDane, 0, bajtoweDane.Length, 0,
                new AsyncCallback(WyslijCallback), klient);
        }

        private void WyslijCallback(IAsyncResult ar)
        {
            try
            {
                Socket klient = (Socket)ar.AsyncState;
                int bajtyWyslane = klient.EndSend(ar);
                wyslanieWykonane.Set();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

    }
}
