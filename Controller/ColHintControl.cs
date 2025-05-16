using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nemone
{
    public partial class ColHintControl: UserControl
    {
        public List<List<int>> Hints { get; set; }
        public int CellSize { get; set; } = 10;

        public ColHintControl(List<List<int>> colHints)
        {
            Hints = colHints;

            InitializeComponent();
            DoubleBuffered = true;

            this.Paint += ColHintControl_Paint;
            Invalidate();
        }

        private void ColHintControl_Paint(object sender, PaintEventArgs e)
        {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            int maxHintHeight = Hints.Max(h => h.Count);
            float cellHeight = (float)Height / maxHintHeight;
            int offsetX = 0;

            foreach (var hintCol in Hints)
            {
                int emptyCount = maxHintHeight - hintCol.Count;

                for (int i = 0; i < hintCol.Count; i++)
                {
                    int rowIndex = emptyCount + i;
                    float drawY = rowIndex * cellHeight;
                    RectangleF rect = new RectangleF(offsetX, drawY, CellSize, cellHeight);

                    // 좌우 선
                    g.DrawLine(Pens.Gray, offsetX, 0, offsetX, Height);
                    g.DrawLine(Pens.Gray, offsetX + CellSize, 0, offsetX + CellSize, Height);

                    // 텍스트
                    using (Font font = new Font(Font.Name, CellSize * 0.5f, FontStyle.Bold))
                    {
                        TextRenderer.DrawText(
                            g,
                            hintCol[i].ToString(),
                            font,
                            Rectangle.Round(rect),
                            Color.Black,
                            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                        );
                    }
                }

                offsetX += CellSize;
            }
        }

    }
}
