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
        NemoGrid nemoGrid = new NemoGrid
        {
            GridSize = 10,
            Size = new Size(550, 550)
        };

        public MakeForm()
        {
            InitializeComponent();
            pnGrid.Controls.Add(nemoGrid);
            this.Resize += MakeForm_Resize;
            CenterNemoGrid();
        }

        private void CenterNemoGrid()
        {
            nemoGrid.Location = new Point(
                (pnGrid.Width - nemoGrid.Width) / 2,
                (pnGrid.Height - nemoGrid.Height) / 2
                );
        }
        private void MakeForm_Resize(object sender, EventArgs e)
        {
            CenterNemoGrid();
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
    }
}
