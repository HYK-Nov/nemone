using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using static System.Windows.Forms.AxHost;

namespace Nemone
{
    public partial class NemoGrid: UserControl
    {
        private const int MIN_SIZE = 10;
        private const int MAX_SIZE = 30;
        private int gridSize = MAX_SIZE;  // 기본 maxsize
        private Button[,] cells;
        public int[,] gridState;

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
                cells = new Button[gridSize, gridSize];
                gridState = new int[gridSize, gridSize];
                CreateGrid();
            }
        }
        public int CellSize { get; private set; }

        public NemoGrid()
        {
            cells = new Button[gridSize, gridSize];
            gridState = new int[gridSize, gridSize];
            CreateGrid();
        }

        // 그리드 생성
        private void CreateGrid()
        {
            this.Controls.Clear();
            // 그리드 사이즈에 따라 셀 사이즈 변경
            int CellSize = Math.Min(this.Width, this.Height) / gridSize;

            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    Button cell = new Button
                    {
                        Size = new Size(CellSize, CellSize),
                        Location = new Point(x * CellSize, y * CellSize),
                        BackColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = Tuple.Create(0, x, y)   //  0 : 빈칸, 1 : 검정, 2 : X
                    };
                    cell.FlatAppearance.BorderColor = Color.DarkGray;
                    cell.MouseDown += Cell_MouseDown;

                    cells[y, x] = cell;
                    this.Controls.Add(cell);

                    if ((x+1) % 5 == 0 && (x+1) != gridSize)
                    {
                        Panel rightLine = new Panel
                        {
                            BackColor = Color.DarkGray,
                            Size = new Size(3, CellSize),
                            Location = new Point(cell.Right - 1, cell.Top)
                        };
                        this.Controls.Add(rightLine);
                        rightLine.BringToFront();
                    }

                    if ((y + 1) % 5 == 0 && (y + 1) != gridSize)
                    {
                        Panel bottomLine = new Panel
                        {
                            BackColor = Color.DarkGray,
                            Size = new Size(CellSize, 3),
                            Location = new Point(cell.Left, cell.Bottom - 1)
                        };
                        this.Controls.Add(bottomLine);
                        bottomLine.BringToFront();
                    }
                }
            }
        }

        private void ApplyCellState(Button cell, MouseButtons button)
        {
            var tag = (Tuple<int, int, int>)cell.Tag;
            int state = tag.Item1;
            int x = tag.Item2;
            int y = tag.Item3;

            if (button == MouseButtons.Left)
            {
                if (state == 0)
                {
                    state = 1;
                    cell.BackColor = Color.Black;
                }
                else 
                {
                    state = 0;
                    cell.BackColor = Color.White;
                }
                cell.BackgroundImage = null;
            }
            else if (button == MouseButtons.Right)
            {
                if (state != 2)
                {
                    state = 2;
                    cell.BackColor = Color.White;
                    cell.BackgroundImage = Properties.Resources.x_icon;
                }
                else
                {
                    state = 0;
                    cell.BackColor = Color.White;
                    cell.BackgroundImage = null;
                }
            }
            gridState[y, x] = state;
            // Tag 업데이트
            cell.Tag = Tuple.Create(state, x, y);
        }

        private void Cell_MouseDown(object sender, MouseEventArgs e)
        {
            ApplyCellState(sender as Button, e.Button);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CreateGrid();
        }

        public void SaveToFile(string filePath)
        {
            var sb = new StringBuilder();

            sb.AppendLine(gridSize.ToString());
            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    int value = gridState[y, x] == 2 ? 0 : gridState[y, x];
                    sb.Append(value);
                    if (x < gridSize - 1)
                    {
                        sb.Append(",");
                    }
                }
                sb.AppendLine();
            }

            // Base64 인코딩
            string plainText = sb.ToString();
            string encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
            File.WriteAllText(filePath, encoded);
        }

        public void LoadFromFile(string filePath)
        {
            string encoded = File.ReadAllText(filePath);
            string plainText = Encoding.UTF8.GetString(Convert.FromBase64String(encoded));
            var lines = plainText.Split(new[] { "\r\n", "\n"}, StringSplitOptions.None);

            if (lines.Length == 0) return;

            if (int.TryParse(lines[0], out int newSize))
            {
                GridSize = newSize; // 자동으로 CreateGrid 호출
            }

            for (int y = 0; y < gridSize && y+1 < lines.Length; y++)    // line[1]부터 실제 데이터
            {
                var tokens = lines[y + 1].Split(',');
                for (int x = 0; x < gridSize && x < tokens.Length; x++)
                {
                    if (int.TryParse(tokens[x], out int value))
                    {
                        gridState[y, x] = value;

                        var cell = cells[y, x];

                        if (value == 1)
                        {
                            cell.Tag = Tuple.Create(1, x, y);
                            cell.BackColor = Color.Black;
                        }
                        else
                        {
                            cell.Tag = Tuple.Create(0, x, y);
                            cell.BackColor = Color.White;
                        }
                    }
                }
            }
        }
    }
}
