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
    public partial class HintPanelControl: UserControl
    {
        private Panel colHintPanel;
        private Panel rowHintPanel;
        private NemoGridControl nemoGrid;
        private int[,] grid;

        private const int HintSize = 40;

        public HintPanelControl(int[,] grid)
        {
            this.grid = grid;
            InitializeComponent();
            InitializeLayout();
        }

        public void InitializeLayout()
        {
            this.SuspendLayout();

            // 열 힌트
            colHintPanel = new Panel
            {
                Height = HintSize,
                Dock = DockStyle.Top,
                BackColor = Color.White
            };
            colHintPanel.Paint += ColHintPanel_Paint;
            this.Controls.Add(colHintPanel);

            // 행 힌트
            rowHintPanel = new Panel
            {
                Height = HintSize,
                Dock = DockStyle.Left,
                BackColor = Color.White
            };
            rowHintPanel.Paint += RowHintPanel_Paint;
            this.Controls.Add(rowHintPanel);

            // 네모 그리드
            nemoGrid = new NemoGridControl
            {
                Dock = DockStyle.Fill,
                //Margin = new Padding(0)
            };
            this.Controls.Add(nemoGrid);

            this.ResumeLayout();
        }

        private void ColHintPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void RowHintPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font font = new Font(this.Font.Name, 9);
            int cellSize = nemoGrid.CellSize;

            for (int y = 0; y < nemoGrid.GridSize; y++)
            {
                string hint = GetRowHints();    // TODO: 열 힌트
                SizeF size = g.MeasureString(hint, font);
                float xPos = rowHintPanel.Width - size.Width;
                float yPos = HintSize + (y * cellSize) + (cellSize - size.Height) / 2;
                g.DrawString(hint, font, Brushes.Black, xPos, yPos);
            }
        }

        public static List<List<int>> GetRowHints(int[,] grid)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            var result = new List<List<int>>();

            for (int y = 0; y < rows; y++)
            {
                var hints = new List<int>();
                int count = 0;

                for (int x = 0; x < cols; x++)
                {
                    if (grid[y, x] == 1)
                    {
                        count++;
                    }
                    else if (count > 0)
                    {
                        hints.Add(count);
                        count = 0;
                    }
                }

                if (count > 0) hints.Add(count);
                if (hints.Count == 0) hints.Add(0);

                result.Add(hints);
            }

            return result;
        }

        public static List<List<int>> GetColHints(int[,] grid)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            var result = new List<List<int>>();

            for (int x = 0; x < cols; x++)
            {
                var hints = new List<int>();
                int count = 0;

                for (int y = 0; y < rows; y++)
                {
                    if (grid[y, x] == 1)
                    {
                        count++;
                    }
                    else if (count > 0)
                    {
                        hints.Add(count);
                        count = 0;
                    }
                }

                if (count > 0) hints.Add(count);
                if (hints.Count == 0) hints.Add(0);

                result.Add(hints);
            }

            return result;
        }
    }
}
