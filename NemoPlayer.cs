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
using System.Text.Json;

namespace Nemone
{
    public partial class NemoPlayer: BaseNemoGridControl
    {
        public List<List<int>> rowHints { get; private set; }
        public List<List<int>> colHints { get; private set; }
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
            rowHints = new List<List<int>>();

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
            colHints = new List<List<int>>();

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

        private async Task<bool> IsCorrectAsync()
        {
            for (int y = 0; y < GridSize; y++)
            {
                for (int x = 0; x < GridSize; x++)
                {
                    if ((GridState[y, x] == 2 ? 0 : GridState[y, x]) != solutionGrid[y, x])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private async Task CheckAnswerAsync()
        {
            bool isCorrect = await IsCorrectAsync();
            if (isCorrect)
            {
                MessageBox.Show("완성!", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.FindForm().Close();
            }
        }

        override protected void OnMouseDownInternal(object sender, MouseEventArgs e)
        {
            base.OnMouseDownInternal(sender, e);

            // 백그라운드 스레드에서 비동기 메서드를 실행
            Task.Run(async () => await CheckAnswerAsync());
        }

        override public void LoadFromFile(string filePath)
        {
            string json = File.ReadAllText(filePath);
            var data = JsonSerializer.Deserialize<NemoData>(json);

            if (data == null || data.GridSize <= 0 || data.GridState == null) return;

            this.GridSize = data.GridSize;
            solutionGrid = new int[data.GridSize, data.GridSize];

            for (int y = 0; y < GridSize; y++)
            {
                for (int x = 0; x < GridSize; x++)
                {
                    solutionGrid[y, x] = data.GridState[y][x];
                }
            }

            Invalidate();
        }

        override protected void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate(); // 크기 변경 시 다시 그리기
        }
    }
}
