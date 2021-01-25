using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public class AsynchronousSocketListener
    {
        // Thread signal.  
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public AsynchronousSocketListener()
        {
        }

        public static void StartListening()
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
                    //Console.WriteLine("Waiting for a connection...");
                    //MessageBox.Show("Czekam na połączenie..");
                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        listener);

                    // Wait until a connection is made before continuing.  
                    allDone.WaitOne();
                }

            }
            catch (Exception e)
            {
                //Console.WriteLine(e.ToString());
                MessageBox.Show(e.ToString());
            }

            //Console.WriteLine("\nPress ENTER to continue...");
            //MessageBox.Show("Przyciśnij any key");
            //Console.Read();

        }

        public static void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.  
            allDone.Set();

            // Get the socket that handles the client request.  
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // Create the state object.  
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);
        }
        public static void ReadCallback(IAsyncResult ar)
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
                    //Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",content.Length, content);
                    //MessageBox.Show("Wczytano " + content.Length + " bitów z socketu. Data: "+ content);
                    // Echo the data back to the client.  
                    string[] slowa = content.Split(' ');
                    string odpowiedz = "error";
                    // Kod który wczytuje wysłaną wiadomośc i odpowiada.
                    if (slowa.Length > 2)
                    {
                        
                        switch (slowa[0])
                        {
                            case "sprawdz_email:":
                                var q_e = from uzytkownik in SingletonBaza.Instance.BazaDC.uzytkownicy
                                            where uzytkownik.email == slowa[1]
                                            select uzytkownik;
                                if (q_e.Any())
                                {
                                    odpowiedz = "true";

                                }
                                else
                                {
                                    odpowiedz = "false";
                                }
                                break;
                            case "sprawdz_login:":
                                var q_l = from uzytkownik in SingletonBaza.Instance.BazaDC.uzytkownicy
                                            where uzytkownik.login == slowa[1]
                                            select uzytkownik;
                                if (q_l.Any())
                                {
                                    odpowiedz = "true";

                                }
                                else
                                {
                                    odpowiedz = "false";
                                }
                                break;
                            case "zarejestruj_uzytkownika:":
                                uzytkownicy u = new uzytkownicy();

                                foreach (string s in slowa)
                                {
                                    string[] parametry = s.Split(':');

                                    if (parametry.Length != 2)
                                    {
                                        continue;
                                    }
                                    //MessageBox.Show(String.Join(" ", parametry),s);
                                    if (parametry[0] == "haslo")
                                    {
                                        u.haslo = hashowanie.GetHashString(parametry[1]);
                                    }
                                    else
                                    {
                                        PropertyInfo prop = u.GetType().GetProperty(parametry[0]);
                                        if (prop != null)
                                        {
                                            prop.SetValue(u, parametry[1], null);
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                }
                                    
                                SingletonBaza.Instance.BazaDC.uzytkownicy.InsertOnSubmit(u);
                                SingletonBaza.Instance.BazaDC.SubmitChanges();
                                odpowiedz = "true";
                                break;
                            case "zaloguj:":
                                var q_z = from uzytkownik in SingletonBaza.Instance.BazaDC.uzytkownicy
                                          where uzytkownik.login == slowa[1]
                                          && uzytkownik.haslo ==
                                          hashowanie.GetHashString(slowa[2])
                                          select uzytkownik;
                                if (q_z.Any())
                                {
                                    uzytkownicy zalogowany = q_z.FirstOrDefault();
                                    odpowiedz = zalogowany.imie + " " + zalogowany.nazwisko
                                        + " " + zalogowany.login + " " + zalogowany.email;
                                }
                                else
                                {
                                    odpowiedz = "bledneDane";
                                }
                                break;
                        }
                    }
                    Send(handler, odpowiedz);
                }
                else
                {
                    
                    // Not all data received. Get more.  
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }
            }
        }

        private static void Send(Socket handler, String data)
        {
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.  
            handler.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), handler);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = handler.EndSend(ar);
                //Console.WriteLine("Sent {0} bytes to client.", bytesSent);
                //MessageBox.Show("Wysłano " + bytesSent + " bitow do klienta");
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

            }
            catch (Exception e)
            {
                //Console.WriteLine(e.ToString());
                MessageBox.Show(e.ToString());
            }
        }
    }
}
