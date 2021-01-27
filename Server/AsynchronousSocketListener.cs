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
        private static int liczba_lobby = 5;
        private static Dictionary<string, Lobby> slownik_lobby;
        private static List<string> gracze = new List<string>();
        // Thread signal.  
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public AsynchronousSocketListener()
        {
            
        }
        static void wczytaj_lobby()
        {
            slownik_lobby = new Dictionary<string, Lobby>();
            for (int i = 1; i <= liczba_lobby; i++)
            {
                slownik_lobby.Add(i.ToString(), new Lobby(i));
            }
        }
        public static void StartListening()
        {
            wczytaj_lobby();
            //gracze = new List<string>();
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
                    if (slowa.Length >= 2)
                    {
                        
                        switch (slowa[0])
                        {
                            case "sprawdz_email:":
                                System.Threading.Thread.Sleep(5000);
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
                            case "wielkosc_lobby:":
                                odpowiedz = "ll:" + liczba_lobby;
                                break;
                            case "dodaj_gracza_do_lobby:":
                                if (!gracze.Contains(slowa[2]))
                                {
                                    gracze.Add(slowa[2]);

                                    Boolean wynik_sprawdzania = true;
                                    foreach (Lobby w in slownik_lobby.Values)
                                    {
                                        if (w.czy_jestem_w_lobby(slowa[2]))
                                        {
                                            wynik_sprawdzania = false;
                                            break;
                                        }
                                    }
                                    if (wynik_sprawdzania && slownik_lobby.ContainsKey(slowa[1]))
                                    {
                                        odpowiedz = slownik_lobby[slowa[1]].dodaj(slowa[2]).ToString();
                                    }
                                    else
                                    {
                                        odpowiedz = "false";
                                    }
                                    gracze.Remove(slowa[2]);
                                }else
                                {
                                    odpowiedz = "False";
                                }
                                    break;
                            case "usun_gracz_z_lobby:":
                                if (slownik_lobby.ContainsKey(slowa[1]))
                                {
                                    odpowiedz = slownik_lobby[slowa[1]].usun(slowa[2]).ToString();
                                }else
                                {
                                    odpowiedz = "False";
                                }
                                break;
                            case "gracze_z_lobby:":
                                if (slownik_lobby.ContainsKey(slowa[1]))
                                {
                                    odpowiedz = slownik_lobby[slowa[1]].gracze();
                                }else
                                {
                                    odpowiedz = "g1: g2:";
                                }
                                break;
                            case "czy_pelne_lobby:":
                                // Sprawdzić użycie w kliencie
                                if (slownik_lobby.ContainsKey(slowa[1]))
                                {
                                    odpowiedz = slownik_lobby[slowa[1]].czy_pelne_lobby().ToString();
                                }else
                                {
                                    odpowiedz = "False";
                                }
                                break;
                            case "jestem_gotowy:":
                                if (!gracze.Contains(slowa[2]))
                                {
                                    gracze.Add(slowa[2]);
                                    if (slownik_lobby.ContainsKey(slowa[1]))
                                    {
                                        odpowiedz = slownik_lobby[slowa[1]].gotowy(slowa[2]).ToString();
                                    }
                                    else
                                    {
                                        odpowiedz = "False";
                                    }
                                     gracze.Remove(slowa[2]);
                                }
                                break;
                            case "niejestem_gotowy:":
                                if (slownik_lobby.ContainsKey(slowa[1]))
                                {
                                    odpowiedz = slownik_lobby[slowa[1]].niegotowy(slowa[2]).ToString();
                                }
                                else
                                {
                                    odpowiedz = "False";
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
