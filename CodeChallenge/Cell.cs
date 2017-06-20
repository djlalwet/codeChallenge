using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    class Cell
    {

        public Cell(int col, int row, string content)
        {
            this.col = col;
            this.row = row;
            this.content = content;
        }

        public int col { get; private set; }
        public int row { get; private set; }
        public string content { get; private set; }
    }
}
