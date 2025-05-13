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

namespace Nemone
{
    public partial class NemoEditor: BaseNemoGridControl
    {
        public NemoEditor()
        {

        }

        override public void SaveToFile(string filePath)
        {
            var sb = new StringBuilder();

            sb.AppendLine(GridSize.ToString());
            for (int y = 0; y < GridSize; y++)
            {
                for (int x = 0; x < GridSize; x++)
                {
                    int value = GridState[y, x] == 2 ? 0 : GridState[y, x];
                    sb.Append(value);
                    if (x < GridSize - 1)
                    {
                        sb.Append(",");
                    }
                }
                sb.AppendLine();
            }

            string plainText = sb.ToString();
            File.WriteAllText(filePath, plainText);
        }

        override public void LoadFromFile(string filePath)
        {
            string plainText = File.ReadAllText(filePath);
            var lines = plainText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            if (lines.Length == 0) return;

            if (int.TryParse(lines[0], out int newSize))
            {
                GridSize = newSize; // 자동으로 CreateGrid 호출
            }

            for (int y = 0; y < GridSize && y + 1 < lines.Length; y++)    // line[1]부터 실제 데이터
            {
                var tokens = lines[y + 1].Split(',');
                for (int x = 0; x < GridSize && x < tokens.Length; x++)
                {
                    if (int.TryParse(tokens[x], out int value))
                    {
                        GridState[y, x] = value;
                    }
                }
            }
        }
    }
}
