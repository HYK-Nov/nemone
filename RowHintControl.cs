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
        public int CellSize { get; set; } = 25;

        public RowHintControl()
        {
            InitializeComponent();
            Hints = new List<List<int>>();
            DoubleBuffered = true;
            AutoSize = false;  // AutoSize 제거
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            int offsetY = 0;

            foreach (var hintRow in Hints)
            {
                string hintText = string.Join(" ", hintRow);
                Rectangle rect = new Rectangle(0, offsetY, Width, CellSize);
                TextRenderer.DrawText(g, hintText, Font, rect, Color.Black,
                    TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
                offsetY += CellSize;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate(); // 크기 변경 시 다시 그리기
        }

        public void RefreshHints(List<List<int>> newHints)
        {
            Hints = newHints;
            Height = Hints.Count * CellSize; // 힌트에 맞게 높이 계산
            Width = Parent?.ClientSize.Width ?? 200; // Width를 부모에 맞추거나 고정값으로 설정
            Invalidate(); // 변경 사항 반영
        }

        public void AdjustLocation(int gridHeight)
        {
            // RowHintControl이 그리드 안으로 침범하지 않도록 위치를 설정
            Location = new Point(0, gridHeight); // 예시로 그리드 아래에 배치
        }
    }
}
