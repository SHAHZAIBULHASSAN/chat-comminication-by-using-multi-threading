using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Client
{
    public partial class formMain : Form
    {

       

        public TcpClient clientSocket;
        public NetworkStream serverStream = default(NetworkStream);

        string readData = null;
        Thread ctThread;
        String name = null;
        //Dictionary<string, Object> nowChatting = new Dictionary<string, Object>();
        List<string> nowChatting = new List<string>();
        List<string> chat = new List<string>();

        public void setName(String title)
        {
            this.Text = title;
            name = title;
        }

        public formMain()
        {
           
            InitializeComponent();
          

            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // Connect to the specified host.



            IPHostEntry host;
            IPAddress LocalIP = null; string str = string.Empty;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress i in host.AddressList)
            {
                if (i.AddressFamily.ToString() == "InterNetwork")

                {
                    LocalIP = i;

                    str = LocalIP.ToString();
                    //    Console.WriteLine(str);
                }

                String Host = Dns.GetHostName();
                IsADSAlive(str);
                Ping myPing = new Ping();
              //PingReply reply = myPing.Send(str, 5000);
              //  if (reply != null)
              //  {
              //      string re = reply.Status.ToString();
              //      MessageBox.Show($"Server is available {re}");

              //      // Console.WriteLine("Status :  " + reply.Status + " \n Time : " + reply.RoundtripTime.ToString() + " \n Address : " + reply.Address);
              //      //Console.WriteLine(reply.ToString());

              //  }
              //  else
              //  {
              //      MessageBox.Show("server is not available");
              //  }

            }

        }
        public static bool IsADSAlive(String hostName)
        {
            try
            {
                using (TcpClient tcpClient = new TcpClient())
                {
                    
                    tcpClient.Connect(hostName, 5000);

                    MessageBox.Show("Server is Available");

                    return true;
                    
                }
            }
            catch (SocketException)
            {
                MessageBox.Show("Server is not available");
                return false;
            }
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (!input.Text.Equals(""))
                {
                    chat.Add("gChat");
                    chat.Add(input.Text);
                    byte[] outStream = ObjectToByteArray(chat);

                    serverStream.Write(outStream, 0, outStream.Length);
                    serverStream.Flush();
                    input.Text = "";
                    chat.Clear();
                }
            }
            catch (Exception er)
            {
                btnConnect.Enabled = true;
            }

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            clientSocket = new TcpClient();
            try
            {
                clientSocket.Connect("127.0.0.1", 5000);
                readData = "Connected to Server ";


                byte[] nm = new byte[283];
                NetworkStream stre = clientSocket.GetStream(); //Gets The Stream of The Connection
                                                               //  stre.Write(nm, 0, nm.Length);// send the msg


                stre.Read(nm, 0, nm.Length);
                String ack = Encoding.ASCII.GetString(nm);
                stre.Flush();
                //MessageBox.Show(ack);
                // received data
                //Socket list;
                ////   sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //list = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //list.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000));
                //list.Listen(0);
                //Socket sk = list.Accept();
                //byte[] buffer = new byte[1238];
                //int y = sk.Receive(buffer, 0, buffer.Length, 0);
                //Array.Resize(ref buffer, y);



                //string ser= Encoding.ASCII.GetString(buffer);


                Update(ack);
                msg();

                serverStream = clientSocket.GetStream();

                byte[] outStream = Encoding.ASCII.GetBytes(name + "$");
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();
                btnConnect.Enabled = false;


                ctThread = new Thread(getMessage);
                ctThread.Start();
            }
            catch (Exception er)
            {
                Dateup(true);
            //    MessageBox.Show("Server Not Started");
            }
        }

        private void Dateup(bool v)
        {
            Invoke((Action)delegate
                {
                    lbl.Text = "Server is Disconnected";
                    btnSend.Enabled = false;
                    btnConnect.Enabled = false;
                }

                );
        }

        private void Update(string v)
        {

            Invoke((Action)delegate
            {
                lbl.Text = v;

                    // label1.Visible = textBoxEmployee.Visible = !toggle;

                    //  labelIP.Visible = textBoxAddress.Visible = !toggle;
                });

        }

        public void getUsers(List<string> parts)
        {
            this.Invoke((MethodInvoker)delegate
            {
                listBox1.Items.Clear();
                for (int i = 1; i < parts.Count; i++)
                {
                    listBox1.Items.Add(parts[i]);

                }
            });
        }

        private void getMessage()
        {
            try
            {
                while (true)
                {
                    serverStream = clientSocket.GetStream();
                    byte[] inStream = new byte[10025];
                    serverStream.Read(inStream, 0, inStream.Length);
                    List<string> parts = null;

                    if (!SocketConnected(clientSocket))
                    {
                        MessageBox.Show("You've been Disconnected");
                        ctThread.Abort();
                        clientSocket.Close();
                        btnConnect.Enabled = true;
                    }

                    parts = (List<string>)ByteArrayToObject(inStream);
                    switch (parts[0])
                    {
                        case "userList":
                            getUsers(parts);
                            break;

                        case "gChat":
                            readData = "" + parts[1];
                            msg();
                            break;

                        case "pChat":
                            managePrivateChat(parts);
                            break;
                    }

                    if (readData[0].Equals('\0'))
                    {
                        readData = "Reconnect Again";
                        msg();

                        this.Invoke((MethodInvoker)delegate // To Write the Received data
                        {
                            btnConnect.Enabled = true;
                        });

                        ctThread.Abort();
                        clientSocket.Close();
                        break;
                    }
                    chat.Clear();
                }
            }
            catch (Exception e)
            {
                ctThread.Abort();
                clientSocket.Close();
                btnConnect.Enabled = true;
                Console.WriteLine(e);
            }

        }

        private void msg()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(msg));
            else
                history.Text = history.Text + Environment.NewLine + " >> " + readData;
        }

        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want to exit? ", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    ctThread.Abort();
                    clientSocket.Close();
                }
                catch (Exception ee) { }

                Application.ExitThread();
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }


        public void managePrivateChat(List<string> parts)
        {

            this.Invoke((MethodInvoker)delegate // To Write the Received data
            {
                if (parts[3].Equals("new"))
                {
                    formPrivate privateC = new formPrivate(parts[2], clientSocket, name);
                    nowChatting.Add(parts[2]);
                    privateC.Text = "Private Chat with " + parts[2];
                    privateC.Show();
                }
                else
                {
                    if (Application.OpenForms["formPrivate"] != null)
                    {
                        (Application.OpenForms["formPrivate"] as formPrivate).setHistory(parts[3]);
                    }
                }

            });

        }


        public byte[] ObjectToByteArray(object _Object)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, _Object);
                return stream.ToArray();
            }
        }

        public Object ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }

        bool SocketConnected(TcpClient s) //check whether client is connected server
        {
            bool flag = false;
            try
            {
                bool part1 = s.Client.Poll(10, SelectMode.SelectRead);
                bool part2 = (s.Available == 0);
                if (part1 && part2)
                {
                    Upddate(true);

                    indicator.BackColor = Color.Red;

                    this.Invoke((MethodInvoker)delegate // cross threads
                    {
                        btnConnect.Enabled = true;
                    });
                    flag = false;
                }
                else
                {
                   // lbl.Text = "Server is Connected";
                    indicator.BackColor = Color.Green;
                    flag = true;

                }
            }
            catch (Exception er)
            {
                Console.WriteLine(er);
            }
            return flag;
        }

        private void Upddate(bool v)
        {



            Invoke((Action)delegate
            {
                lbl.Text = "Server is DisConnected";

                // label1.Visible = textBoxEmployee.Visible = !toggle;

                //  labelIP.Visible = textBoxAddress.Visible = !toggle;
            }); 
        }

        private void privateChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                String clientName = listBox1.GetItemText(listBox1.SelectedItem);
                chat.Clear();
                chat.Add("pChat");
                chat.Add(clientName);
                chat.Add(name);
                chat.Add("new");

                byte[] outStream = ObjectToByteArray(chat);
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();

                formPrivate privateChat = new formPrivate(clientName, clientSocket, name);
                nowChatting.Add(clientName);
                privateChat.Text = "Private Chat with " + clientName;
                privateChat.Show();
                chat.Clear();
            }
        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            history.Clear();
        }

        private void history_TextChanged(object sender, EventArgs e)
        {
            history.SelectionStart = history.TextLength;
            history.ScrollToCaret();
        }

        private void indicator_BackColorChanged(object sender, EventArgs e)
        {

        }

        private void formMain_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            clientSocket = new TcpClient();
            
                clientSocket.Connect("127.0.0.1", 5000);
                readData = "Connected to Server ";

            //  msg();
            Updateser(true);
            serverStream = clientSocket.GetStream();

            byte[] outStream = Encoding.ASCII.GetBytes(name + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            btnConnect.Enabled = false;


            ctThread = new Thread(getMessage);
            ctThread.Start();

        }

        private void Updateser(bool v)
        {
            Invoke((Action)delegate
            {
                lbl.Text = "Server is Connected";
                btnConnect.Enabled = true;
                btnSend.Enabled = true;
                btntry.Enabled = false;


                // label1.Visible = textBoxEmployee.Visible = !toggle;

                //  labelIP.Visible = textBoxAddress.Visible = !toggle;
            });
        }

        private void btnnew_Click(object sender, EventArgs e)
        {

        }
    }
}
