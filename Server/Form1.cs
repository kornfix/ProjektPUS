using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{

     public partial class Server : Form
    {
        public void wypisz(string s)
        {
            listBox1.Invoke(new Action(delegate ()
            {
                listBox1.Items.Add(s);
            }));
            //listBox1.Items.Add(s);
        }
        public class StateObject
        {
            // Rozmiar uzyskiwanych danych.  
            public const int BufferSize = 1024;

            // Receive buffer.  
            public byte[] buffer = new byte[BufferSize];

            // Received data string.
            public StringBuilder sb = new StringBuilder();

            // Client socket.
            public Socket workSocket = null;
        }
            // Thread signal.  
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public void StartListening()
        {
           
                // Establish the local endpoint for the socket.  
                // The DNS name of the computer  
                // running the listener is "host.contoso.com".  
                
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

                // Create a TCP/IP socket.  
                Socket listener = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Bind the socket to the local endpoint and listen for incoming connections.  
                try
                {
                    listener.Bind(localEndPoint);
                    listener.Listen(100);
                   
                    while (true)
                    {
                        // Set the event to nonsignaled state.  
                        allDone.Reset();

                        // Start an asynchronous socket to listen for connections.  
                        wypisz("Czekam na połączenie");
                        //Console.WriteLine("Waiting for a connection...");
                        listener.BeginAccept(
                            new AsyncCallback(AcceptCallback),
                            listener);

                        // Wait until a connection is made before continuing.  
                        allDone.WaitOne();
                    }

                }
                catch (Exception e)
                {
                    wypisz(e.ToString());
                    Console.WriteLine(e.ToString());
                }
                wypisz("Przycisnije enter aby kontynować...");
                //Console.WriteLine("\nPress ENTER to continue...");
                //Console.Read();

            }

            public  void AcceptCallback(IAsyncResult ar)
            {
                // Signal the main thread to continue.  
                allDone.Set();
                // Get the socket that handles the client request.  
                Socket listener = (Socket)ar.AsyncState;
                Socket handler = listener.EndAccept(ar);
                wypisz("tutaj");
                // Create the state object.  
                StateObject state = new StateObject();
                state.workSocket = handler;
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
            }

            public  void ReadCallback(IAsyncResult ar)
            {
                String content = String.Empty;

                // Retrieve the state object and the handler socket  
                // from the asynchronous state object.  
                StateObject state = (StateObject)ar.AsyncState;
                Socket handler = state.workSocket;

                // Read data from the client socket.
                int bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There  might be more data, so store the data received so far.  
                    state.sb.Append(Encoding.ASCII.GetString(
                        state.buffer, 0, bytesRead));

                    // Check for end-of-file tag. If it is not there, read
                    // more data.  
                    content = state.sb.ToString();
                    if (content.IndexOf("<EOF>") > -1)
                    {
                    // All the data has been read from the
                    // client. Display it on the console.  
                    wypisz("Zczytano"+ content.Length+ "bytów z socketu");
                    wypisz(content);
                       // Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                       //     content.Length, content);
                        // Echo the data back to the client.  
                        Send(handler, content);
                    }
                    else
                    {
                        // Not all data received. Get more.  
                        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReadCallback), state);
                    }
                }
            }

            private  void Send(Socket handler, String data)
            {
                // Convert the string data to byte data using ASCII encoding.  
                byte[] byteData = Encoding.ASCII.GetBytes(data);

                // Begin sending the data to the remote device.  
                handler.BeginSend(byteData, 0, byteData.Length, 0,
                    new AsyncCallback(SendCallback), handler);
            }

            private  void SendCallback(IAsyncResult ar)
            {
                try
                {
                    // Retrieve the socket from the state object.  
                    Socket handler = (Socket)ar.AsyncState;

                    // Complete sending the data to the remote device.  
                    int bytesSent = handler.EndSend(ar);
                    //Console.WriteLine("Sent {0} bytes to client.", bytesSent);
                    wypisz("Wysłano " + bytesSent + " bytów do klienta");
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                    
                }
                catch (Exception e)
                {
                wypisz(e.ToString());
                    //Console.WriteLine(e.ToString());
                }
            }
        
        public Server()
        {
            InitializeComponent();
            //StartListening();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartListening();
        }
        // Logowanie 
        private void sprawdz_login_haslo(string login, string haslo)
        {
            var query = from uzytkownik in SingletonBaza.Instance.BazaDC.uzytkownicy
                        where uzytkownik.login == login
                        && uzytkownik.haslo ==
                        hashowanie.GetHashString(haslo)
                        select uzytkownik;
            if (query.Any())
            {
                // Kod zalogowano pomyślnie wysłanie inf do clienta
                // Jak nie wiem :D

            }
            else
            {
                MessageBox.Show("Błąd logowania do bazy danych!");
                // Kod odpowiedż że się nie udało :D 

            }
        }


    }
}
