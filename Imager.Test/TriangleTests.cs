using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imager.Test
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void ValidTriangleShouldReturnCorrectColumn()
        {
            var myImage = new Image(60, 60, 10, 10);
            var myLeftTriangle = new RightTriangle(new VertexPoint(0, 10), new VertexPoint(0, 0), new VertexPoint(10, 10));
            var myRightTriangle = new RightTriangle(new VertexPoint(10, 0), new VertexPoint(10, 10), new VertexPoint(0, 0));
            var myTriangle = new RightTriangle(new VertexPoint(40, 30), new VertexPoint(40, 40), new VertexPoint(30, 30));

            Assert.IsTrue(myLeftTriangle.IsValid);
            Assert.IsTrue(myRightTriangle.IsValid);

            var myResult = myImage.CalculateMatrixPosition(myLeftTriangle);
            Assert.AreEqual(1, myResult.Column);

            myResult = myImage.CalculateMatrixPosition(myRightTriangle);
            Assert.AreEqual(2, myResult.Column);

            myResult = myImage.CalculateMatrixPosition(myTriangle);
            Assert.AreEqual(8, myResult.Column);

            myTriangle = new RightTriangle(new VertexPoint(30, 40), new VertexPoint(30, 30), new VertexPoint(40, 40));
            myResult = myImage.CalculateMatrixPosition(myTriangle);
            Assert.AreEqual(7, myResult.Column);
        }

        [TestMethod]
        public void ValidTriangleShouldReturnCorrectRow()
        {
            var myImage = new Image(60, 60, 10, 10);
            var myLeftTriangle = new RightTriangle(new VertexPoint(0, 10), new VertexPoint(0, 0), new VertexPoint(10, 10));
            var myRightTriangle = new RightTriangle(new VertexPoint(10, 0), new VertexPoint(10, 10), new VertexPoint(0, 0));
            var myTriangle = new RightTriangle(new VertexPoint(40, 30), new VertexPoint(40, 40), new VertexPoint(30, 30));

            Assert.IsTrue(myLeftTriangle.IsValid);
            Assert.IsTrue(myRightTriangle.IsValid);

            var myResult = myImage.CalculateMatrixPosition(myLeftTriangle);
            Assert.AreEqual("A", myResult.Row);

            myResult = myImage.CalculateMatrixPosition(myRightTriangle);
            Assert.AreEqual("A", myResult.Row);

            myResult = myImage.CalculateMatrixPosition(myTriangle);
            Assert.AreEqual("D", myResult.Row);

            myTriangle = new RightTriangle(new VertexPoint(30, 40), new VertexPoint(30, 30), new VertexPoint(40, 40));
            myResult = myImage.CalculateMatrixPosition(myTriangle);
            Assert.AreEqual("D", myResult.Row);
        }

        [TestMethod]
        public void InvalidPositionShouldReturnNoPosition()
        {
            var myImage = new Image(60, 60, 10, 10);
            var myTriangle = new RightTriangle(new VertexPoint(60, 10), new VertexPoint(60, 0), new VertexPoint(70, 10));

            Assert.IsTrue(myTriangle.IsValid);
            Assert.IsNull(myImage.CalculateMatrixPosition(myTriangle).Row);
            Assert.AreEqual(0, myImage.CalculateMatrixPosition(myTriangle).Column);

        }

    }
}
