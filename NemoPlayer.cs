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
using Newtonsoft.Json;

namespace Nemone
{
    public partial class NemoPlayer: BaseNemoGridControl
    {
        public List<List<int>> rowHints { get; private set; }
        public List<List<int>> colHints { get; private set; }
        public int PuzzleId { get; private set; }
        public string Title { get; private set; }
        private int[,] solutionGrid;
        public bool IsCompleted { get; private set; }
        private bool isExport;

        public NemoPlayer(PlayStatus playStatus)
        {
            InitializeComponent();

            LoadFromPlayStatus(playStatus);
            GetRowHints();
            GetColHints();

            Invalidate();
        }


        public NemoPlayer(string filePath, bool isExport = false)
        {
            InitializeComponent();
            this.isExport = isExport;

            LoadFromFile(filePath);
            GetRowHints();
            GetColHints();

            Invalidate();
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
                IsCompleted = true;
                MessageBox.Show("완성!", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var data = JsonConvert.DeserializeObject<NemoData>(json);

            if (data == null || data.GridSize <= 0 || data.GridState == null) return;

            this.Title = data.Title;
            this.GridSize = data.GridSize;

            if (isExport == false)
            {
                this.PuzzleId = NemoDB.EnsurePuzzleInDb(data.Title, data.GridSize, data.GridState);
                // 플레이 내역 확인
                PlayStatus existingStatus = NemoDB.LoadPlayStatusByPuzzleId(PuzzleId);
                if (existingStatus != null)
                {
                    // 기존 저장된 상태 불러오기
                    this.GridState = existingStatus.Process;
                }
            }

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

        public void LoadFromPlayStatus(PlayStatus playStatus)
        {
            if (playStatus == null || playStatus.Process == null) return;

            this.Title = playStatus.Title;
            this.PuzzleId = playStatus.PuzzleId;
            this.IsCompleted = playStatus.IsCompleted;

            // 1) DB에서 퍼즐 정답 불러오기
            int[,] originalSolution = NemoDB.GetPuzzleSolutionById(playStatus.PuzzleId);
            if (originalSolution == null)
            {
                MessageBox.Show("퍼즐 데이터를 불러올 수 없습니다.");
                return;
            }

            this.GridSize = originalSolution.GetLength(0);
            solutionGrid = originalSolution;

            // 2) 진행 상태인 Process를 GridState에 복사
            GridState = new int[GridSize, GridSize];

            for (int y = 0; y < GridSize; y++)
            {
                for (int x = 0; x < GridSize; x++)
                {
                    GridState[y, x] = playStatus.Process[y, x];
                }
            }
        }

        override protected void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate(); // 크기 변경 시 다시 그리기
        }
    }
}
