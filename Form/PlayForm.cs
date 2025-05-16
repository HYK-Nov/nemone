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
using System.Data.SQLite;

namespace Nemone
{
    public partial class PlayForm : Form
    {
        private NemoPlayer nemoPlayer;
        private RowHintControl rowHint;
        private ColHintControl colHint;

        public PlayForm(string filePath, bool isExport = false)
        {
            InitializeComponent();

            nemoPlayer = new NemoPlayer(filePath, isExport);
            tableLayoutPanel.Controls.Add(nemoPlayer, 1, 1);

            rowHint = new RowHintControl(nemoPlayer.rowHints);
            rowHint.Dock = DockStyle.Right;
            colHint = new ColHintControl(nemoPlayer.colHints);
            colHint.Dock = DockStyle.Bottom;

            tableLayoutPanel.Controls.Add(rowHint, 0, 1);
            tableLayoutPanel.Controls.Add(colHint, 1, 0);

            this.Text = Path.GetFileNameWithoutExtension(filePath);
            this.Resize += PlayForm_Resize;
            if (isExport == false)
            {
                this.FormClosed += PlayForm_Closed;
            }
            CenterComponents();
        }

        public PlayForm(PlayStatus playStatus)
        {
            InitializeComponent();

            nemoPlayer = new NemoPlayer(playStatus);

            tableLayoutPanel.Controls.Add(nemoPlayer, 1, 1);

            rowHint = new RowHintControl(nemoPlayer.rowHints);
            rowHint.Dock = DockStyle.Right;
            colHint = new ColHintControl(nemoPlayer.colHints);
            colHint.Dock = DockStyle.Bottom;

            tableLayoutPanel.Controls.Add(rowHint, 0, 1);
            tableLayoutPanel.Controls.Add(colHint, 1, 0);

            this.Text = playStatus.Title;
            this.Resize += PlayForm_Resize;
            this.FormClosed += PlayForm_Closed;
            CenterComponents();
        }

        private void CenterComponents()
        {
            int tableSize = (int)(Math.Min(ClientSize.Width, ClientSize.Height) * 0.95);
            tableLayoutPanel.Size = new Size(tableSize, tableSize);
            tableLayoutPanel.Location = new Point((ClientSize.Width - tableLayoutPanel.Width)/2,
                                                (ClientSize.Height - tableLayoutPanel.Height) / 2);

            int targetWidth = tableLayoutPanel.GetColumnWidths()[1];
            int targetHeight = tableLayoutPanel.GetRowHeights()[1];
            int targetSize = (int)(Math.Min(targetWidth, targetHeight)) - 2;

            nemoPlayer.Size = new Size(targetSize, targetSize);

            rowHint.CellSize = nemoPlayer.CellSize;
            colHint.CellSize = nemoPlayer.CellSize;

            rowHint.Width = nemoPlayer.CellSize * (nemoPlayer.rowHints.Select(hints => hints.Count).DefaultIfEmpty(0).Max()+1);
            colHint.Height = nemoPlayer.CellSize * (nemoPlayer.colHints.Select(hints => hints.Count).DefaultIfEmpty(0).Max()+1);

            colHint.Invalidate();
        }

        private void PlayForm_Resize(object sender, EventArgs e)
        {
            CenterComponents();
        }

        private void PlayForm_Closed(object sender, FormClosedEventArgs e)
        {
            NemoDB.SavePlayStatus(nemoPlayer.PuzzleId, nemoPlayer.Title, nemoPlayer.GridState, nemoPlayer.IsCompleted);
        }

        public Bitmap CaptureTableLayoutPanel()
        {
            if (tableLayoutPanel == null || tableLayoutPanel.Width == 0 || tableLayoutPanel.Height == 0)
                return null;

            Bitmap bmp = new Bitmap(tableLayoutPanel.Width, tableLayoutPanel.Height);
            tableLayoutPanel.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            return bmp;
        }

    }
}
