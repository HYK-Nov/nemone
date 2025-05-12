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
    public partial class PlayForm: Form
    {
        NemoGridControl nemo = new NemoGridControl
        {
            Size = new Size(500, 500)
        };

        public PlayForm()
        {
            InitializeComponent();
        }
    }
}
