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
        NemoEditor nemoEditor = new NemoEditor
        {
            GridSize = 10,
            Size = new Size(550, 550)
        };

        public MakeForm()
        {
            InitializeComponent();
            container.Panel1.Controls.Add(nemoEditor);
            this.Resize += MakeForm_Resize;
            CenterComponents();
        }

        private void CenterComponents()
        {
            int baseSize = Math.Min(container.Panel1.Height, container.Panel1.Width);
            int targetSize = (int)(baseSize * 0.9);

            // 그리드 크기 변경
            nemoEditor.Size = new Size(targetSize, targetSize);
            nemoEditor.Location = new Point((container.Panel1.Width - nemoEditor.Width) / 2,
                                          (container.Panel1.Height - nemoEditor.Height) / 2);
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
            int size = nemoEditor.GridSize;

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    nemoEditor.GridState[y, x] = data[y, x];
                }
            }

            // 화면 다시 그리기
            nemoEditor.Invalidate();
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
                nemoEditor.SaveToFile(sfd.FileName);
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
                nemoEditor.LoadFromFile(ofd.FileName);

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

                if (radioMap.TryGetValue(nemoEditor.GridSize, out RadioButton selectedRadio))
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
                int size = nemoEditor.GridSize;
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
            if (rd10.Checked && nemoEditor.GridSize != 10)
            {
                nemoEditor.GridSize = 10;
            }
        }

        private void rd15_CheckedChanged(object sender, EventArgs e)
        {
            if (rd15.Checked && nemoEditor.GridSize != 15)
            {
                nemoEditor.GridSize = 15;
            }
        }

        private void rd20_CheckedChanged(object sender, EventArgs e)
        {
            if (rd20.Checked && nemoEditor.GridSize != 20)
            {
                nemoEditor.GridSize = 20;
            }
        }

        private void rd25_CheckedChanged(object sender, EventArgs e)
        {
            if (rd25.Checked && nemoEditor.GridSize != 25)
            {
                nemoEditor.GridSize = 25;
            }
        }

        private void rd30_CheckedChanged(object sender, EventArgs e)
        {
            if (rd30.Checked && nemoEditor.GridSize != 30)
            {
                nemoEditor.GridSize = 30;
            }
        }

        private void rd35_CheckedChanged(object sender, EventArgs e)
        {
            if (rd35.Checked && nemoEditor.GridSize != 35)
            {
                nemoEditor.GridSize = 35;
            }
        }

        private void rd40_CheckedChanged(object sender, EventArgs e)
        {
            if (rd40.Checked && nemoEditor.GridSize != 40)
            {
                nemoEditor.GridSize = 40;
            }
        }
    }
}
