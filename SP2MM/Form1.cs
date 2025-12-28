using System.Diagnostics;
using System.IO.Compression;
using System.Net;

namespace SP2_Mod_Manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("C:\\Program Files (x86)\\Steam\\steamapps\\common\\SimplePlanes 2 Playtest\\SimplePlanes 2.exe"))
            {
                string gameLocation = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\SimplePlanes 2 Playtest";
                textBox1.Text = gameLocation;
            }
            else
            {
                MessageBox.Show("Couldn't find install, please locate it", "Couldn't find install", MessageBoxButtons.OK, MessageBoxIcon.Error);
                showFileBrowser();
            }
        }

        private void showFileBrowser()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showFileBrowser();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                string url = "https://github.com/BepInEx/BepInEx/releases/download/v5.4.23.4/BepInEx_win_x64_5.4.23.4.zip";
                string path = textBox1.Text;
                string filePath = $"{path}\\BepInEx_win_x64_5.4.23.4.zip";
                string pluginPath = $"{path}\\BepInEx\\plugins";
                using (WebClient client = new WebClient())
                {
                    label4.Text = ("Installing BepInEx");
                    client.DownloadFile(url, filePath);
                    ZipFile.ExtractToDirectory(filePath, path, true);
                    Directory.CreateDirectory(pluginPath);
                    label4.Text = ("Install Complete");
                }
            }

            if (checkBox2.Checked)
            {
                string url = "https://github.com/miniusbhater/SP2Unlocker/releases/latest/download/SP2Unlocker.dll";
                string path = textBox1.Text;
                string bepPath = $"{path}\\BepInEx\\plugins\\SP2Unlocker.dll";
                using (WebClient client1 = new WebClient())
                {
                    label4.Text = ("Installing SP2 Unlocker");
                    client1.DownloadFile(url, bepPath);
                    label4.Text = ("Install Complete");
                }
            }

            if (checkBox3.Checked)
            {
                string url = "https://github.com/miniusbhater/DisplayFPS/releases/latest/download/DisplayFPS.dll";
                string path = textBox1.Text;
                string bepPath = $"{path}\\BepInEx\\plugins\\DisplayFPS.dll";
                using (WebClient client1 = new WebClient())
                {
                    label4.Text = ("Installing DisplayFPS");
                    client1.DownloadFile(url, bepPath);
                    label4.Text = ("Install Complete");
                }
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "https://github.com/miniusbhater/SP2-Mod-Manager",
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

