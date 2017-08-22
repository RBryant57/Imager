using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imager
{

    public class Triangle
    {
        public VertexPoint V1 { get; set; }
        public VertexPoint V2 { get; set; }
        public VertexPoint V3 { get; set; }
        public virtual int SideA { get; }
        public virtual int SideB { get; }

        public virtual bool IsValid
        {
            get
            {
                return !(V1.X * (V2.Y - V3.Y) + V2.X * (V3.Y - V1.Y) + V3.X * (V1.Y - V2.Y) == 0);
            }
        }

    }
    /// <summary>
    /// This class represents a right triangle. The V1 vertex is the vertex of the right angle. V2 is the vertex adjacent
    /// the right angle via the Y axis. These vertices are connected by SideA. The V3 vertex is the vertex adjacent the 
    /// right angle via the X axis. These vertices are connected by SideB.
    /// </summary>
    public class RightTriangle : Triangle
    {
        public override int SideA
        {
            get
            {
                return Math.Abs(V1.Y - V2.Y);
            }
        }

        public override int SideB
        {
            get
            {
                return Math.Abs(V1.X - V3.X);
            }
        }

        public RightTriangle(VertexPoint v1, VertexPoint v2, VertexPoint v3)
        {
            V1 = v1;
            V2 = v2;
            V3 = v3;
        }

        /// <summary>
        /// This method determines wheter the the right angles is on the left side
        /// of the triangle.
        /// </summary>
        public bool IsLeft
        {
            get
            {
                return V1.Y > V2.Y;
            }
        }

        public override bool IsValid
        {
            get
            {

                if (V1.X != V2.X || (V1.X + SideB != V3.X && V1.X - SideB != V3.X))
                    return false;
                if (V1.Y != V3.Y || (V1.Y + SideA != V2.Y && V1.Y - SideA != V2.Y))
                    return false;

                // In the context of this image, even valid right triangles could be considered
                // invalid.
                if (V1.X > V3.X && V1.Y > V2.Y)
                    return false;
                if (V1.X < V3.X && V1.Y < V2.Y)
                    return false;

                return true;
            }
        }
    }

    public class TriangleCollection
    {
        List<List<Triangle>> collectionList = new List<List<Triangle>>();

        private int convertToRowNumber(string rowString)
        {
            var c = rowString.First();
            return ((int)c - Constants.ASCII_OFFSET) + (Constants.ALPHA_LENGTH * (rowString.Length - 1));

        }
        public TriangleCollection(List<List<Triangle>> triangleList)
        {
            collectionList = triangleList;
        }

        public Triangle this[MatrixPoint point]
        {
            get
            {
                return collectionList[convertToRowNumber(point.Row) - 1][point.Column - 1];
            }
        }

        public Triangle this[string row, int column]
        {
            get
            {
                return collectionList[convertToRowNumber(row) - 1][column - 1];
            }
        }
    }
}
