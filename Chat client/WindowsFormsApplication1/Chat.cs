using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Chat_client
{
    public partial class Chat : Form
    {
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        NetworkStream serverStream = default(NetworkStream);
        string readData = null;

        public Chat()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; 
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (!connBtn.Enabled)
            {
                try
                {
                    byte[] outStream = System.Text.Encoding.ASCII.GetBytes(textBox1.Text + "$");
                    serverStream.Write(outStream, 0, outStream.Length);
                    serverStream.Flush();
                    textBox1.Text = "";
                }
                catch(Exception exx){
                
                }
            }
        }

       private void button2_Click(object sender, EventArgs e)
        {

            if (textBox3.Text != "")
            {
                
                try {
                clientSocket.Connect("127.0.0.1", 8888);
                connBtn.Enabled = false;
                readData = "Conected to Chat Server ...";
                msg();

                serverStream = clientSocket.GetStream();

                byte[] outStream = System.Text.Encoding.ASCII.GetBytes(textBox3.Text + "$");
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();
                Thread ctThread = new Thread(getMessage);
                ctThread.IsBackground = true;
                ctThread.Start();
            }
                catch(Exception ex){
                    MessageBox.Show ("Server Not Available");
                    
                }

            }
            
          
            
            
        }

        private void getMessage()
        {
            while (true)
            {
                serverStream = clientSocket.GetStream();
                int buffSize = 0;
                byte[] inStream = new byte[10025];
                buffSize = clientSocket.ReceiveBufferSize;
                serverStream.Read(inStream, 0, buffSize);
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                readData = "" + returndata;
                msg();
            }
        }

        private void msg()
        {
           if (this.InvokeRequired)
               this.Invoke(new MethodInvoker(msg));
           else
                textBox2.Text = "\n"+ textBox2.Text + Environment.NewLine + ">>" + readData ;
        }

        private void Chat_Load(object sender, EventArgs e)
        {

        }

    }
}
