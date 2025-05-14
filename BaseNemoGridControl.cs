using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Nemone
{
    public partial class BaseNemoGridControl: UserControl
    {
        private const int MIN_SIZE = 10;
        private const int MAX_SIZE = 40;
        private int gridSize = MIN_SIZE;  // 기본 minsize
        protected Point? hoveredCell = null;
        protected Point? pressedCell = null;

        public int[,] GridState { get; set; }
        public int GridSize
        {
            get => gridSize;
            set
            {
                if (value < MIN_SIZE || value > MAX_SIZE)
                {
                    throw new ArgumentOutOfRangeException($"{MIN_SIZE} 이상 {MAX_SIZE} 이하만 가능합니다");
                }

                gridSize = value;
                GridState = new int[gridSize, gridSize];

                Invalidate();
            }
        }
        public int CellSize
        {
            get
            {
                if (Width > 0 && Height > 0)
                {
                    int cellWidth = Width / gridSize;
                    int cellHeight = Height / gridSize;
                    return Math.Min(cellWidth, cellHeight); // 가장 작은 값으로 셀 크기 결정
                }
                return 0;
            }
        }

        public BaseNemoGridControl()
        {
            DoubleBuffered = true;
            GridState = new int[gridSize, gridSize];
            this.MouseDown += OnMouseDownInternal;
            this.MouseUp += (s, e) => { pressedCell = null; Invalidate(); };
            this.MouseMove += OnMouseMoveInternal;
            this.MouseLeave += (s, e) => { hoveredCell = null; Invalidate(); };
            this.Resize += (s, e) => Invalidate();
        }

        protected virtual void OnMouseDownInternal(object sender, MouseEventArgs e)
        {
            if (CellSize <= 0) return;

            int x = e.X / CellSize;
            int y = e.Y / CellSize;

            if (x < 0 || x >= GridSize || y < 0 || y >= GridSize)
            {
                if (pressedCell != null)
                {
                    pressedCell = null;
                    Invalidate();
                }
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                GridState[y, x] = GridState[y, x] == 0 ? 1 : 0;
            }
            else if (e.Button == MouseButtons.Right)
            {
                GridState[y, x] = GridState[y, x] == 2 ? 0 : 2;
            }

            var newPressed = new Point(x, y);
            if (pressedCell != newPressed)
            {
                pressedCell = newPressed;
            }
            Invalidate();
        }

        protected virtual void OnMouseMoveInternal(object sender, MouseEventArgs e)
        {
            if (CellSize <= 0) return;

            int x = e.X / CellSize;
            int y = e.Y / CellSize;

            if (x < 0 || x >= GridSize || y < 0 || y >= GridSize)
            {
                if (hoveredCell != null)
                {
                    hoveredCell = null;
                    Invalidate();
                }
            }

            var newHover = new Point(x, y);
            if (hoveredCell != newHover)
            {
                hoveredCell = newHover;
                Invalidate();
            }
        }

        override protected void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawGrid(e.Graphics);
        }

        protected virtual void DrawGrid(Graphics g)
        {
            int cellSize = CellSize;

            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    Rectangle cellRect = new Rectangle(x * cellSize, y * cellSize, cellSize, cellSize);
                    int value = GridState[y, x];

                    Color fillColor = Color.White;
                    if (value == 1) fillColor = Color.Black;

                    using (Brush brush = new SolidBrush(fillColor))
                        g.FillRectangle(brush, cellRect);

                    // 셀 hover 효과
                    if (hoveredCell.HasValue && hoveredCell.Value.X == x && hoveredCell.Value.Y == y)
                    {
                        using (Brush brush = new SolidBrush(Color.FromArgb(64, Color.Gray)))
                            g.FillRectangle(brush, cellRect);
                    }

                    // 셀 클릭 효과
                    if (pressedCell.HasValue && pressedCell.Value.X == x && pressedCell.Value.Y == y)
                    {
                        using (Brush brush = new SolidBrush(Color.FromArgb(64, Color.DarkGray)))
                            g.FillRectangle(brush, cellRect);
                    }

                    // x 표시
                    if (GridState[y, x] == 2)
                    {
                        Pen crossPen = Pens.Gray;
                        g.DrawLine(crossPen, cellRect.Left, cellRect.Top, cellRect.Right, cellRect.Bottom);
                        g.DrawLine(crossPen, cellRect.Right, cellRect.Top, cellRect.Left, cellRect.Bottom);
                    }

                    // 셀 테두리
                    g.DrawRectangle(Pens.DarkGray, cellRect);

                    // 5칸마다 굵은 선
                    if ((x + 1) % 5 == 0 && (x + 1) != gridSize)
                    {
                        int xPos = (x + 1) * cellSize - 1;
                        g.DrawLine(new Pen(Color.DarkGray, 2), xPos, 0, xPos, gridSize * cellSize);
                    }
                    if ((y + 1) % 5 == 0 && (y + 1) != gridSize)
                    {
                        int yPos = (y + 1) * cellSize - 1;
                        g.DrawLine(new Pen(Color.DarkGray, 2), 0, yPos, gridSize * cellSize, yPos);
                    }
                }
            }
        }

        public virtual void SaveToFile(string filePath) { }

        public virtual void LoadFromFile(string filePath) { }
    }
}
