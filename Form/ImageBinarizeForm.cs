using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nemone
{
    public partial class ImageBinarizeForm: Form
    {
        Bitmap original;
        Bitmap resized;
        int size;
        public int[,] Binarized { get; private set; }

        public ImageBinarizeForm(Bitmap original, int size)
        {
            InitializeComponent();
            this.original = original;
            this.size = size;
            imgBefore.Image = original;
            resized = new Bitmap(original, size, size);
            Binarized = new int[size, size];

            binarizedImage();
        }

        private void binarizedImage()
        {
            resized = new Bitmap(original, size, size);

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    Color pixel = resized.GetPixel(x, y);
                    int gray = (pixel.R + pixel.G + pixel.B) / 3;    // grayscale
                    Binarized[y, x] = gray < binarySlider.Value ? 1 : 0;

                    // 흰색 or 검정색 픽셀로 설정
                    Color binColor = Binarized[y, x] == 1 ? Color.Black : Color.White;
                    resized.SetPixel(x, y, binColor);
                }
            }

            // 미리보기 이미지 만들기
            int zoom = 10;
            Bitmap previewImage = new Bitmap(size * zoom, size * zoom);
            using (Graphics g = Graphics.FromImage(previewImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                g.DrawImage(resized, new Rectangle(0, 0, previewImage.Width, previewImage.Height));
            }

            imgAfter.Image = previewImage;
        }

        private void binarySlider_ValueChanged(object sender, EventArgs e)
        {
            binarizedImage();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
