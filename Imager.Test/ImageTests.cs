using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imager.Test
{
    [TestClass]
    public class ImageTests
    {
        [TestMethod]
        public void GenerateImageShouldYieldCorrectMatrix()
        {
            var myImage = new Image(60, 60, 10, 10);
            var myTriangles = myImage.Triangles;

            var testTriangle = myTriangles["D", 9];
            testTriangle = myTriangles[new MatrixPoint("D", 9)];

            Assert.AreEqual(40, testTriangle.V1.X);
            Assert.AreEqual(40, testTriangle.V1.Y);

            Assert.AreEqual(40, testTriangle.V2.X);
            Assert.AreEqual(30, testTriangle.V2.Y);

            Assert.AreEqual(50, testTriangle.V3.X);
            Assert.AreEqual(40, testTriangle.V3.Y);
        }
    }
}
