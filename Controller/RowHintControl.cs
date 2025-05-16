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
    public partial class RowHintControl: UserControl
    {
        public List<List<int>> Hints { get; set; }
        public int CellSize { get; set; } = 5;

        public RowHintControl(List<List<int>> rowHints)
        {
            Hints = rowHints;

            InitializeComponent();
            DoubleBuffered = true;

            this.Resize += RowHintControl_Resize;
            Invalidate();
        }

        private void RowHintControl_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            int offsetY = 0;

            foreach (var hintRow in Hints)
            {
                string hintText = string.Join("  ", hintRow);
                Rectangle rect = new Rectangle(0, offsetY, Width, CellSize);

                // 박스 위, 아래 선그리기
                g.DrawLine(Pens.Gray, rect.Left, rect.Top, rect.Right, rect.Top);   // 위
                g.DrawLine(Pens.Gray, rect.Left, rect.Bottom, rect.Right, rect.Bottom); // 아래

                // 텍스트 출력 (우측 정렬 + 수직 정렬)
                TextRenderer.DrawText(
                    g,
                    hintText,
                    new Font(Font.Name, CellSize * 0.5f, FontStyle.Bold),
                    rect,
                    Color.Black,
                    TextFormatFlags.Right | TextFormatFlags.VerticalCenter
                );

                offsetY += CellSize;
            }
        }
    }
}
