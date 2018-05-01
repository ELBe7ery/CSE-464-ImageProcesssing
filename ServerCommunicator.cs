using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing_Project
{
    class ServerCommunicator
    {
        // private data members section
        private int port;                   // TCP port number
        private string tcp_ip;              // Server TCP ip
        private string database_dir;        // Database images default directory location
        private string detected_face_dir;   // Detected faces directory
        private string tcp_msg_inbox;       // response data for the TCP connection
        RichTextBox logBox;                 // reference to the GUI log section
        private bool isConnected;           // flag for connectivity checking
        bool faceFound;                     // flag for database matching

        // ctor
        public ServerCommunicator(RichTextBox _logbox ,int _port=5005, string _tcp_ip="127.0.0.1",  string _database_dir="db/",
                           string _detected_face_dir = "faces/")
        {
            logBox = _logbox;
            port = _port;
            tcp_ip = _tcp_ip;
            database_dir = _database_dir;
            detected_face_dir = _detected_face_dir;
            string ret = SendTCP("echo");
            if (ret.IndexOf("running") != -1)
                isConnected = true;
            else
                isConnected = false;
        }
        // hidden TCP sender
        private string SendTCP(string toSend)
        {
            string ret = "";
            try
            {
                TcpClient client = new TcpClient(tcp_ip, port);
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(toSend);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                data = new byte[1024];
                Int32 bytes = stream.Read(data, 0, 1024);
                tcp_msg_inbox = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                ret += "\n" + tcp_msg_inbox;
                stream.Close();
                client.Close();
            }
            catch (Exception e)
            {

                ret += "Connectivity Error: \n" + e.ToString();
            }

            logBox.AppendText("\n" + ret);
            logBox.ScrollToCaret();

            if (ret.IndexOf("img:")==-1)
                faceFound = false;
            else
                faceFound = true;
            return ret;
        }
        // public image fetching method
        public List<string> Infer(string img_dir)
        {
            string recieved = SendTCP("infer\n" + img_dir);
            List<string> ret = recieved.Split('\n').ToList<string>();
            return ret;
        }
        // public database insertion method
        public void AddDB(string img_dir, string img_info)
        {
            SendTCP("add\n" + img_dir+"\n"+img_info);
        }
        // public connectivity checking method
        public bool getIsConnected() { return isConnected; }

        public bool isFaceDetected() { return faceFound; }
    }
}
