using System;
using System.IO;

using System.Windows.Forms;
using VideoLibrary;

namespace youtubeMP3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("YouTube to MP3 converter by Abdul Hajiyev\nVersion V1.0");
        }

        private async void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select your path"})
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    var youtube = YouTube.Default;
                    var video = await youtube.GetVideoAsync(gunaTextBox1.Text);
                    File.WriteAllBytes(fbd.SelectedPath + @"\" + video.FullName + ".mp3", await video.GetBytesAsync());
                    gunaGradientButton1.Text = "Download Complete";
                }
            }
        }
    }
}
