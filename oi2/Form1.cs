using oi2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace oi2
{
    public partial class Form1 : Form
    {
        Bitmap sourceImage;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                sourceImage = new Bitmap(dialog.FileName);
                pictureBox1.Image = sourceImage;
                pictureBox1.SizeMode=PictureBoxSizeMode.StretchImage;
                pictureBox1.Refresh();
            }

        }

        private void globalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            globalfilt globalfilt = new globalfilt();
            Bitmap resultIm = globalfilt.procIm(sourceImage);
            pictureBox1.Image = resultIm;
            pictureBox1.Refresh();

        }

        private void histogrammToolStripMenuItem_Click(object sender, EventArgs e)
        {
            binhist bhist = new binhist();
            Bitmap resultIm = bhist.procIm(sourceImage);
            pictureBox1.Image = resultIm;
            pictureBox1.Refresh();

        }

        private void niblackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            niblack niblatb = new niblack();
            Bitmap resultIm = niblatb.procIm(sourceImage);
            pictureBox1.Image = resultIm;
            pictureBox1.Refresh();
        }
    }
}
