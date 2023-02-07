using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bitmap2PngConvertor
{
    public partial class ConvertorForm : Form
    {
        public ConvertorForm()
        {
            InitializeComponent();
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = (Bitmap)Image.FromFile(openFileDialog1.FileName);
                var bmp = new Bitmap(pictureBox1.Image);
                var zero = bmp.GetPixel(0, 0);
                for (var y = 0; y < bmp.Height; y++)
                {
                    for (var x = 0; x < bmp.Width; x++)
                    {
                        var color = bmp.GetPixel(x, y);
                        if (color == zero)
                        {
                            color = Color.FromArgb(0, color);
                            bmp.SetPixel(x, y, color);
                        }
                    }
                }
                pictureBox2.Image = bmp;
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = Path.ChangeExtension(openFileDialog1.FileName, ".png");
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FilterIndex == 1)
                    pictureBox2.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
                if (saveFileDialog1.FilterIndex == 2)
                {

                    pictureBox2.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Icon);
                }
            }
        }
    }
}
