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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Xml.Linq;

namespace Nemone
{
    public partial class PlayForm : Form
    {
        private NemoPlayer nemoPlayer;

        public PlayForm(string filePath)
        {
            InitializeComponent();

            nemoPlayer = new NemoPlayer(filePath);
            int targetSize = Math.Min(ClientSize.Width, ClientSize.Height);
            nemoPlayer.Size = new Size(targetSize, targetSize);
            Console.WriteLine(targetSize);
            //this.Controls.Add(nemoPlayer);
            tableLayoutPanel.Controls.Add(nemoPlayer, 1, 1);
            

            this.Resize += PlayForm_Resize;
            CenterComponents();
        }

        private void CenterComponents()
        {
            int targetSize = (int)(Math.Min(ClientSize.Width, ClientSize.Height) * 0.9);
            nemoPlayer.Size = new Size(targetSize, targetSize);
            nemoPlayer.Location = new Point((ClientSize.Width - nemoPlayer.Width) / 2,
                                            (ClientSize.Height - nemoPlayer.Height) / 2);
        }

        private void PlayForm_Resize(object sender, EventArgs e)
        {
            CenterComponents();
        }

    }
}
