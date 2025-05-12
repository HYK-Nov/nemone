using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nemone
{
    public partial class MakeForm: Form
    {
        NemoGridControl nemoGrid = new NemoGridControl
        {
            GridSize = 10,
            Size = new Size(550, 550)
        };

        public MakeForm()
        {
            InitializeComponent();
            container.Panel1.Controls.Add(nemoGrid);
            this.Resize += MakeForm_Resize;
            CenterComponents();
        }

        private void CenterComponents()
        {
            int baseSize = Math.Min(container.Panel1.Height, container.Panel1.Width);
            int targetSize = (int)(baseSize * 0.9);

            // 그리드 크기 변경
            nemoGrid.Size = new Size(targetSize, targetSize);
            nemoGrid.Location = new Point((container.Panel1.Width - nemoGrid.Width) / 2,
                                          (container.Panel1.Height - nemoGrid.Height) / 2);
            groupBox.Location = new Point((container.Panel2.Width - groupBox.Width) / 2,
                                          groupBox.Location.Y);
            btnSave.Location = new Point((container.Panel2.Width - btnSave.Width) / 2,
                                          btnSave.Location.Y);
            btnLoad.Location = new Point((container.Panel2.Width - btnLoad.Width) / 2,
                                          btnLoad.Location.Y);
            btnConvert.Location = new Point((container.Panel2.Width - btnConvert.Width) / 2,
                                          btnConvert.Location.Y);
        }

        private void ApplyBinarizedToGrid(int[,] data)
        {
            int size = nemoGrid.GridSize;

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    nemoGrid.gridState[y, x] = data[y, x];
                }
            }

            // 화면 다시 그리기
            nemoGrid.Invalidate();
        }


        private void MakeForm_Resize(object sender, EventArgs e)
        {
            CenterComponents();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            sfd.Filter = "Nemo Files (*.nemo)|*.nemo";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                nemoGrid.SaveToFile(sfd.FileName);
                MessageBox.Show("저장되었습니다");
                this.Close();
            }
            sfd.FileName = "";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Nemo Files (*.nemo)|*.nemo";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                nemoGrid.LoadFromFile(ofd.FileName);

                // 라디오 버튼 변경
                var radioMap = new Dictionary<int, RadioButton>
                {
                    { 10, rd10 },
                    { 15, rd15 },
                    { 20, rd20 },
                    { 25, rd25 },
                    { 30, rd30 },
                    { 35, rd35 },
                    { 40, rd40 }
                };

                if (radioMap.TryGetValue(nemoGrid.GridSize, out RadioButton selectedRadio))
                {
                    selectedRadio.Checked = true;
                }
                else
                {
                    rd10.Checked = true;
                }
            }
            ofd.FileName = "";
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK) 
            {
                string imagePath = ofd.FileName;
                int size = nemoGrid.GridSize;
                Bitmap original = new Bitmap(imagePath);
                

                ImageBinarizeForm imageBinarizeForm = new ImageBinarizeForm(original, size);
                
                if(imageBinarizeForm.ShowDialog() == DialogResult.OK)
                {
                    ApplyBinarizedToGrid(imageBinarizeForm.Binarized);
                }
            }
            ofd.FileName = "";
        }

        private void rd10_CheckedChanged(object sender, EventArgs e)
        {
            if (rd10.Checked && nemoGrid.GridSize != 10)
            {
                nemoGrid.GridSize = 10;
            }
        }

        private void rd15_CheckedChanged(object sender, EventArgs e)
        {
            if (rd15.Checked && nemoGrid.GridSize != 15)
            {
                nemoGrid.GridSize = 15;
            }
        }

        private void rd20_CheckedChanged(object sender, EventArgs e)
        {
            if (rd20.Checked && nemoGrid.GridSize != 20)
            {
                nemoGrid.GridSize = 20;
            }
        }

        private void rd25_CheckedChanged(object sender, EventArgs e)
        {
            if (rd25.Checked && nemoGrid.GridSize != 25)
            {
                nemoGrid.GridSize = 25;
            }
        }

        private void rd30_CheckedChanged(object sender, EventArgs e)
        {
            if (rd30.Checked && nemoGrid.GridSize != 30)
            {
                nemoGrid.GridSize = 30;
            }
        }

        private void rd35_CheckedChanged(object sender, EventArgs e)
        {
            if (rd35.Checked && nemoGrid.GridSize != 35)
            {
                nemoGrid.GridSize = 35;
            }
        }

        private void rd40_CheckedChanged(object sender, EventArgs e)
        {
            if (rd40.Checked && nemoGrid.GridSize != 40)
            {
                nemoGrid.GridSize = 40;
            }
        }
    }
}
