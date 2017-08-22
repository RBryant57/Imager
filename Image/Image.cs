using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imager
{
    /// <summary>
    /// This class represents an image which is an array of right triangles. It assumes the use of a semi-inverted
    /// Cartesian plane. The x values behave as expected (increasing as one moves to the right). But the y values are inverted, i.e.
    /// they increase as one moves down.
    /// </summary>
    public class Image
    {
        private TriangleCollection imageTriangles;
        public int Height { get; set; }
        public int Width { get; set; }
        public int HeightIncrements { get; set; }
        public int WidthIncrements { get; set; }
        public TriangleCollection Triangles
        {
            get
            {
                var result = new List<List<Triangle>>();

                var rowList = new List<Triangle>();
                var column = 0;
                var row = 0;
                RightTriangle imgTriangle = null;

                do
                {
                    rowList = new List<Triangle>();
                    do
                    {
                        var v1 = new VertexPoint(column * WidthIncrements, (row + 1) * HeightIncrements);
                        var v2 = new VertexPoint(column * WidthIncrements, row * HeightIncrements);
                        var v3 = new VertexPoint((column + 1) * WidthIncrements, (row + 1) * HeightIncrements);
                        imgTriangle = new RightTriangle(v1, v2, v3);

                        rowList.Add(imgTriangle);

                        v1 = new VertexPoint((column + 1) * WidthIncrements, row * HeightIncrements);
                        v2 = new VertexPoint((column + 1) * WidthIncrements, (row + 1) * HeightIncrements);
                        v3 = new VertexPoint(column * WidthIncrements, row * HeightIncrements);
                        imgTriangle = new RightTriangle(v1, v2, v3);

                        rowList.Add(imgTriangle);

                        column++;

                    } while (imgTriangle.V1.X < Width);

                    result.Add(rowList);

                    column = 0;
                    row++;

                } while (row * HeightIncrements < Height);

                imageTriangles = new TriangleCollection(result);
                return imageTriangles;
            }
            set { imageTriangles = value; }
        }

        /// <summary>
        /// This method will convert a row number into a string. If there are
        /// more than 26 rows, the letters are repeated, i.e. AA, BB... AAA, BBB...
        /// </summary>
        /// <param name="rowNumber">An integer that represents the row number.</param>
        /// <returns>A string representing the converted row number.</returns>
        private string convertToRowString(int rowNumber)
        {
            var result = new StringBuilder();

            var multliplier = (rowNumber / Constants.ALPHA_LENGTH) + 1;
            var remainder = rowNumber % Constants.ALPHA_LENGTH;

            var c = (char)(Constants.ASCII_OFFSET + remainder);

            for (int i = 0; i < multliplier; i++)
            {
                result.Append(c.ToString());
            }

            return result.ToString();
        }

        private bool isValidPosition(RightTriangle triangle)
        {
            var heightBounds = new List<int>() { triangle.V1.Y, triangle.V2.Y, triangle.V3.Y, Height };
            var widthBounds = new List<int>() { triangle.V1.X, triangle.V2.X, triangle.V3.X, Width };

            if (heightBounds.Max() != Height)
                return false;

            if (widthBounds.Max() != Width)
                return false;

            return true;
        }

        public Image(int height, int width, int heightIncrements, int widthIncrements)
        {
            Height = height;
            Width = width;
            HeightIncrements = heightIncrements;
            WidthIncrements = widthIncrements;
        }

        public MatrixPoint CalculateMatrixPosition(RightTriangle triangle)
        {
            var result = new MatrixPoint();

            if (!triangle.IsValid || !isValidPosition(triangle))
                return result;

            if (triangle.SideA != HeightIncrements || triangle.SideB != WidthIncrements)
                return result;

            var heightIncrements = triangle.V1.Y / triangle.SideA;
            result.Row = triangle.IsLeft ? convertToRowString(heightIncrements) : convertToRowString(heightIncrements + 1);

            var widthIncrements = triangle.V1.X / triangle.SideB;
            result.Column = triangle.IsLeft ? (widthIncrements * 2) + 1 : widthIncrements * 2;

            return result;
        }

    }
}
