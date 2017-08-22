using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imager
{
    public class Constants
    {
        public const int ALPHA_LENGTH = 26;
        public const int ASCII_OFFSET = 64;
    }
    public class MatrixPoint
    {
        public string Row { get; set; }
        public int Column { get; set; }

        public MatrixPoint() { }

        public MatrixPoint(string row, int column)
        {
            Row = row;
            Column = column;
        }
    }

    public class VertexPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public VertexPoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

}
