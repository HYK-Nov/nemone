using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemone
{
    public class NemoData
    {
        public string Title { get; set; }
        public int GridSize { get; set; }
        public int[][] GridState { get; set; }
    }

    public class PlayStatus
    {
        public int Id { get; set; }
        public int PuzzleId { get; set; }
        public string Title { get; set; }
        public DateTime LastPlayedAt { get; set; }
        public int[,] Process { get; set; }
        public bool IsCompleted { get; set; }
    }
}
