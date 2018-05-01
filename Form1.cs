using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing_Project
{
    public partial class Form1 : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        ServerCommunicator clf;
        List<string> dbImgDir;
        List<string> dbInfoRecieved;
        int img_count;
        public Form1()
        {
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Red600, Primary.Red700, Primary.Red200, Accent.Red700, TextShade.WHITE);
            InitializeComponent();

            clf = new ServerCommunicator(logBox); 
            if (clf.getIsConnected())
            {
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green700, Primary.Green200, Accent.Green700, TextShade.WHITE);
            }
            else
            {
                loadButton.Enabled = false;
                inferButton.Enabled = false;
                addToDBButton.Enabled = false;
                nextButton.Enabled = false;
                previousButton.Enabled = false;
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            lostPictureBox.Image = Image.FromFile(openFileDialog1.FileName);
            samePictureBox.Image = null;
            facesDetected.Image = null;
        }

        private void inferButton_Click(object sender, EventArgs e)
        {
            // No file is selected; quit
            if (openFileDialog1.FileName == "")
                return;
            List<string> dbInfo;
            dbImgDir = new List<string>();
            dbInfoRecieved = new List<string>();
            dbInfo = clf.Infer(openFileDialog1.FileName);
            loadImg("faces/face_0.jpg", facesDetected);

            foreach (var item in dbInfo)
            {
                if (item == "") continue;
                int _s = item.IndexOf(':') + 1;
                int _l = item.IndexOf(".jpg") + 3;
                dbImgDir.Add(item.Substring(_s, _l - _s + 1));
                dbInfoRecieved.Add(item.Substring(_l + 1).Replace(';','\n'));
            }
            img_count = 0;
            if (dbImgDir.Count != 0)
            {
                loadImg("img/" + dbImgDir[img_count], samePictureBox);
                foundInfoBox.Text = dbInfoRecieved[img_count];
                img_count++;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void nextButton_Click(object sender, EventArgs e)
        {

        }

        private void previousButton_Click(object sender, EventArgs e)
        {

        }
        void loadImg(string imgDir, PictureBox pb)
        {
            FileStream stream = new FileStream(imgDir, FileMode.Open, FileAccess.Read);
            pb.Image = Image.FromStream(stream);
            stream.Close();
        }

        private void addToDBButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName == "")
                return;
            clf.AddDB(openFileDialog1.FileName, foundInfoBox.Text.Replace('\n', ';'));
            logBox.AppendText("\nImage sent to the server and added to the database\n");
        }
    }
}
