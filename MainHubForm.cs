using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            this.MaximizeBox = false;
            Panel bottomSpacer = new Panel
            {
                Height = 80,
                Width = 10,
                Margin = new Padding(0),
                Enabled = false
            };
            flowLayoutPanel1.Controls.Add(bottomSpacer);
        }

        private void btnNewMake_Click(object sender, EventArgs e)
        {
            MakeForm makeForm = new MakeForm();
            makeForm.FormClosed += MakeForm_FormClosed;
            makeForm.Show();
            this.Hide();
        }

        private void MakeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 두 번째 폼이 닫힐 때 첫 번째 폼도 종료
            this.Show();
        }

        private void btnMakeImg_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Image Files|*.png;*.jpeg";
            openFileDialog.ShowDialog();
        }
    }
}
