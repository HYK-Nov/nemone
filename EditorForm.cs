using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nemone
{
    public partial class EditorForm: Form
    {
        private bool editState = false;
        NemoEditor nemoEditor = new NemoEditor
        {
            GridSize = 10,
        };

        public EditorForm()
        {
            InitializeComponent();
            panel1.Controls.Add(nemoEditor);
            this.Resize += MakeForm_Resize;
            this.FormClosing += Before_FormClosing;
            nemoEditor.GridChanged += GridChangeState; 
            CenterComponents();
        }

        private void GridChangeState()
        {
            if (!editState)
            {
                editState = true;   // 값 변경 감지
                this.Text += "*";
            }
        }

        private void CenterComponents()
        {
            int targetSize = (int)(Math.Min(panel1.Width, panel1.Height) * 0.9);

            // 그리드 크기 변경
            int offsetY = 55;
            nemoEditor.Size = new Size(targetSize - 2, targetSize - 2);
            nemoEditor.Location = new Point((panel1.Width - nemoEditor.Width) / 2,
                                          (panel1.Height - nemoEditor.Height) / 2);
            groupBox.Size = new Size((int)(panel2.Width * 0.8), groupBox.Height);
            groupBox.Location = new Point((panel2.Width - groupBox.Width) / 2,
                                          (int)(panel2.Height * 0.1));
            btnSave.Size = new Size((int)(panel2.Width * 0.8), btnSave.Height);
            btnSave.Location = new Point((panel2.Width - btnSave.Width) / 2,
                                          (int)(panel2.Height * 0.9));
            btnLoad.Size = new Size((int)(panel2.Width * 0.8), btnLoad.Height);
            btnLoad.Location = new Point((panel2.Width - btnLoad.Width) / 2,
                                          btnSave.Location.Y - offsetY);
            btnConvert.Size = new Size((int)(panel2.Width * 0.8), btnConvert.Height);
            btnConvert.Location = new Point((panel2.Width - btnConvert.Width) / 2,
                                          btnLoad.Location.Y - offsetY);
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

        private bool HasEditedGrid()
        {
            for (int y = 0; y < nemoEditor.GridSize; y++)
            {
                for (int x = 0; x < nemoEditor.GridSize; x++)
                {
                    if (nemoEditor.GridState[y, x] == 1)
                        return true;
                }
            }
            return false;
        }

        private void ChangeGridSize(int newSize, RadioButton senderRadio)
        {
            if (nemoEditor.GridSize == newSize) return;

            if (HasEditedGrid())
            {
                var result = MessageBox.Show("변경하면 내용이 초기화됩니다.\n계속하시겠습니까?",
                                             "확인",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                {
                    // 체크 해제 방지
                    senderRadio.CheckedChanged -= Radio_CheckedChanged;
                    senderRadio.Checked = false;
                    senderRadio.CheckedChanged += Radio_CheckedChanged;

                    // 기존 값 복원
                    var currentRadio = new Dictionary<int, RadioButton>
                                    {
                                        { 10, rd10 },
                                        { 15, rd15 },
                                        { 20, rd20 },
                                        { 25, rd25 },
                                        { 30, rd30 },
                                        { 35, rd35 },
                                    }[nemoEditor.GridSize];

                    currentRadio.CheckedChanged -= Radio_CheckedChanged;
                    currentRadio.Checked = true;
                    currentRadio.CheckedChanged += Radio_CheckedChanged;

                    return;
                }
            }

            nemoEditor.GridSize = newSize;
        }

        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
            {
                if (rb == rd10) ChangeGridSize(10, rb);
                else if (rb == rd15) ChangeGridSize(15, rb);
                else if (rb == rd20) ChangeGridSize(20, rb);
                else if (rb == rd25) ChangeGridSize(25, rb);
                else if (rb == rd30) ChangeGridSize(30, rb);
                else if (rb == rd35) ChangeGridSize(35, rb);
            }
        }

        private void MakeForm_Resize(object sender, EventArgs e)
        {
            CenterComponents();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            sfd.Filter = "Nemo Files (*.nemo)|*.nemo";
            if (sfd.FileName == "")
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    nemoEditor.SaveToFile(sfd.FileName);
                    this.Text = Path.GetFileNameWithoutExtension(sfd.FileName);
                    editState = false;
                }
            }
            else
            {
                nemoEditor.SaveToFile(sfd.FileName);
                this.Text = Path.GetFileNameWithoutExtension(sfd.FileName);
                editState = false;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Nemo Files (*.nemo)|*.nemo";

            if (editState)
            {
                var result = MessageBox.Show("변경하면 내용이 초기화됩니다.\n계속하시겠습니까?",
                                     "확인",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return;
            }

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                nemoEditor.LoadFromFile(ofd.FileName);
                sfd.FileName = ofd.FileName;
                this.Text = Path.GetFileNameWithoutExtension(sfd.FileName);

                // 라디오 버튼 변경
                var radioMap = new Dictionary<int, RadioButton>
                {
                    { 10, rd10 },
                    { 15, rd15 },
                    { 20, rd20 },
                    { 25, rd25 },
                    { 30, rd30 },
                    { 35, rd35 }
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

            if (editState)
            {
                var result = MessageBox.Show("변경하면 내용이 초기화됩니다.\n계속하시겠습니까?",
                                     "확인",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return;
            }

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
            sfd.FileName = "";
            this.Text = "네모 만들기*";
            editState = true;
        }

        private void Before_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (editState)
            {
                var result = MessageBox.Show("저장하지 않고 종료하시겠습니까?",
                                             "확인",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
