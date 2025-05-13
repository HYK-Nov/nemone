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
    public partial class NemoPlayer: BaseNemoGridControl
    {
        private List<List<int>> rowHints = new List<List<int>>();
        private List<List<int>> colHints = new List<List<int>>();
        private int[,] solutionGrid;

        public NemoPlayer(string filePath)
        {
            InitializeComponent();

            LoadFromFile(filePath);
            GetRowHints();
            GetColHints();
        }

        private void GetRowHints()
        {
            for (int y = 0; y < GridSize; y++)
            {
                List<int> hints = new List<int>();
                int count = 0;

                for (int x = 0; x < GridSize; x++)
                {
                    if (solutionGrid[y, x] == 1) count++;
                    else if(count > 0)
                    {
                        hints.Add(count);
                        count = 0;
                    }
                }

                if (count > 0) hints.Add(count);
                if (hints.Count == 0) hints.Add(0);

                rowHints.Add(hints);
            }
        }

        private void GetColHints()
        {
            for (int x = 0; x < GridSize; x++)
            {
                List<int> hints = new List<int>();
                int count = 0;

                for (int y = 0; y < GridSize; y++)
                {
                    if (solutionGrid[y, x] == 1)
                    {
                        count++;
                    }
                    else if(count > 0)
                    {
                        hints.Add(count);
                        count = 0;
                    }
                }

                if (count > 0) hints.Add(count);
                if (hints.Count == 0) hints.Add(0);

                colHints.Add(hints);
            }
        }

        private bool IsCorrect()
        {
            for (int y = 0; y < GridSize; y++)
            {
                for (int x = 0; x < GridSize; x++)
                {
                    if (GridState[y, x] != solutionGrid[y, x])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void CheckAnswer()
        {
            if (IsCorrect())
            {
                MessageBox.Show("정답입니다!", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.FindForm().Close();
            }
        }

        override protected void OnMouseDownInternal(object sender, MouseEventArgs e)
        {
            base.OnMouseDownInternal(sender, e);

            CheckAnswer();
        }

        private void DrawRowHints(Graphics g)
        {
            int cellSize = CellSize;
            int offsetX = 5 * cellSize;

            for (int y = 0; y < GridSize; y++)
            {
                var hints = rowHints[y];
                string hintText = string.Join(" ", hints);
                Rectangle rect = new Rectangle(0, y * cellSize, offsetX, cellSize);
                TextRenderer.DrawText(g, hintText, Font, rect, Color.Black, 
                    TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
            }
        }

        private void DrawColHints(Graphics g)
        {
            int cellSize = CellSize;
            int offsetY = 5 * cellSize;
            int hintMargin = 2;

            for (int x = 0; x < GridSize; x++)
            {
                var hints = colHints[x];
                string hintText = string.Join(" ", hints);

                int totalHeight = hints.Count * (Font.Height + hintMargin);
                int startY = offsetY - totalHeight;

                for (int i = 0; i < hints.Count; i++)
                {
                    string hint = hints[i].ToString();
                    float posX = x * cellSize + (cellSize / 2);
                    float posY = startY + i * (Font.Height + hintMargin);

                    // 가운데 정렬용 크기 측정
                    Size textSize = TextRenderer.MeasureText(hint, Font);
                    Rectangle drawRect = new Rectangle(
                        (int)(posX - textSize.Width / 2),
                        (int)posY,
                        textSize.Width,
                        textSize.Height
                    );

                    TextRenderer.DrawText(g, hint, Font, drawRect, Color.Black,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
            }
        }

        override protected void DrawGrid(Graphics g)
        {
            base.DrawGrid(g);

            //DrawRowHints(g);
            //DrawColHints(g);
        }

        override public void LoadFromFile(string filePath)
        {
            string plainText = File.ReadAllText(filePath);
            var lines = plainText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            if (lines.Length == 0) return;

            if (int.TryParse(lines[0], out int newSize))
            {
                GridSize = newSize;
                solutionGrid = new int[newSize, newSize];
            }

            for (int y = 0; y < GridSize && y + 1 < lines.Length; y++)    // line[1]부터 실제 데이터
            {
                var tokens = lines[y + 1].Split(',');
                for (int x = 0; x < GridSize && x < tokens.Length; x++)
                {
                    if (int.TryParse(tokens[x], out int value))
                    {
                        solutionGrid[y, x] = value;
                    }
                }
            }

            Invalidate();
        }

    }
}
