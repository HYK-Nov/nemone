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
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Nemone
{
    public partial class NemoEditor: BaseNemoGridControl
    {
        public NemoEditor() { }

        public event Action GridChanged;

        override protected void OnMouseDownInternal(object sender, MouseEventArgs e)
        {
            base.OnMouseDownInternal(sender, e);
            GridChanged?.Invoke();
        }

        override public void SaveToFile(string filePath)
        {
            var data = new NemoData
            {
                Title = Path.GetFileNameWithoutExtension(filePath),
                GridSize = this.GridSize,
                GridState = new int[GridSize][]
            };

            for (int y = 0; y < GridSize; y++)
            {
                data.GridState[y] = new int[GridSize];
                for (int x = 0; x < GridSize; x++)
                {
                    int value = GridState[y, x] == 2 ? 0 : GridState[y, x]; // X표시(2)는 저장 시 0으로
                    data.GridState[y][x] = value;
                }
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(filePath, json);
        }

        public override void LoadFromFile(string filePath)
        {
            string json = File.ReadAllText(filePath);
            var data = JsonSerializer.Deserialize<NemoData>(json);

            if (data == null || data.GridSize <= 0 || data.GridState == null) return;

            this.GridSize = data.GridSize;

            for (int y = 0; y < GridSize; y++)
            {
                for (int x = 0; x < GridSize; x++)
                {
                    GridState[y, x] = data.GridState[y][x];
                }
            }
        }
    }
}
