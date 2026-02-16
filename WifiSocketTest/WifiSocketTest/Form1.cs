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
using System.IO;
using Microsoft.VisualBasic;

namespace WifiSocketTEst
{
   public partial class Form1 : Form
   {
      IPAddress ipAddress;
      IPEndPoint remoteEP;
      Socket client;
      Button[] AntButtons;
      public Form1()
      {
         InitializeComponent();
         ipAddress = IPAddress.Parse(Properties.Settings.Default.RemoteIP);
         remoteEP = new IPEndPoint(ipAddress, Properties.Settings.Default.RemotePort);
         AntButtons = new Button[4];
         AntButtons[0] = SendaBtn;
         AntButtons[1] = SendbBtn;
         AntButtons[2] = SendcBtn;
         AntButtons[3] = SenddBtn;
         SendaBtn.Text = Properties.Settings.Default.Antenna1;
         SendbBtn.Text = Properties.Settings.Default.Antenna2;
         SendcBtn.Text = Properties.Settings.Default.Antenna3;
         SenddBtn.Text = Properties.Settings.Default.Antenna4;
         timer1.Interval = Properties.Settings.Default.TimerUpdate;
      }

      public int SendGetResponse(out string response, string message)
      {
         int rv = 0;
         response = null;
         client = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
         try
         {
            byte[] buffer = Encoding.ASCII.GetBytes(message);
            client.Connect(remoteEP);
            int bytessent = client.Send(buffer);

            byte[] receivebuff = new byte[256];
            client.Receive(receivebuff, 256, SocketFlags.None);
            response = Encoding.ASCII.GetString(receivebuff);
            client.Close();
         }
         catch (Exception ex)
         {
            rv = -1;
         }

         return rv;
      }
      public int writelog(string message)
      {
         LogLB.Items.Add(message);
         LogLB.SelectedIndex = LogLB.Items.Count - 1;
         return 0;
      }

      private void timer1_Tick(object sender, EventArgs e)
      {
         string response;
         SendGetResponse(out response, "s");
         int v = 0;
         int.TryParse(response, out v);
         for (int i = 0; i < 4; i++)
         {
            Color color = Color.Gray;
            if (v == (1 << i))
               color = Color.Green;
            AntButtons[i].BackColor = color;
         }
         // writelog("Status " + response);
      }



      private void SendaBtn_MouseUp(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Right)
         {
            string str = Interaction.InputBox("Enter new button label", SendaBtn.Text);
            Properties.Settings.Default.Antenna1 = str;
            SendaBtn.Text = str;
            Properties.Settings.Default.Save();
         }
         else if (e.Button == MouseButtons.Left)
         {
            string response;
            SendGetResponse(out response, "1");
            writelog("Send 1: " + response);
         }
      }

      private void SendbBtn_MouseUp(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Right)
         {
            string str = Interaction.InputBox("Enter new button label", SendbBtn.Text);
            Properties.Settings.Default.Antenna2 = str;
            SendbBtn.Text = str;
            Properties.Settings.Default.Save();
         }
         else if (e.Button == MouseButtons.Left)
         {
            string response;
            SendGetResponse(out response, "2");
            writelog("Send 2: " + response);
         }
      }

      private void SendcBtn_MouseUp(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Right)
         {
            string str = Interaction.InputBox("Enter new button label", SendcBtn.Text);
            Properties.Settings.Default.Antenna3 = str;
            SendcBtn.Text = str;
            Properties.Settings.Default.Save();
         }
         else if (e.Button == MouseButtons.Left)
         {
            string response;
            SendGetResponse(out response, "3");
            writelog("Send 3: " + response);
         }
      }
      private void SenddBtn_MouseUp(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Right)
         {
            string str = Interaction.InputBox("Enter new button label", SenddBtn.Text);
            Properties.Settings.Default.Antenna4 = str;
            SenddBtn.Text = str;
            Properties.Settings.Default.Save();
         }
         else if (e.Button == MouseButtons.Left)
         {
            string response;
            SendGetResponse(out response, "4");
            writelog("Send 4: " + response);
         }
      }
   }
}
