using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nemone
{
    public partial class MainHubForm: Form
    {

        public MainHubForm()
        {
            InitializeComponent();
            MainHubLayout();
        }

        private void MainHubLayout()
        {
            Panel bottomSpacer = new Panel
            {
                Height = 80,
                Width = 10,
                Margin = new Padding(0),
                Enabled = false
            };
            flowLayoutPanel.Controls.Add(bottomSpacer);
        }

        private void OtherForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 두 번째 폼이 닫힐 때 첫 번째 폼도 종료
            this.Show();
        }

        private void btnNewMake_Click(object sender, EventArgs e)
        {
            MakeForm makeForm = new MakeForm();
            makeForm.FormClosed += OtherForm_FormClosed;
            makeForm.Show();
            this.Hide();
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Nemo Files (*.nemo)|*.nemo";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                PlayForm playForm = new PlayForm(ofd.FileName);
                playForm.FormClosed += OtherForm_FormClosed;
                playForm.Show();
                this.Hide();
            }
        }
    }
}
