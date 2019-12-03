using System;
using DrawingModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrawingTest
{
    class TestGraphicsAdaptor : IGraphics
    {
        //ClearAll
        public void ClearAll()
        {
            Assert.IsTrue(true);
        }

        //DrawLine
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            Assert.IsTrue(x1 >= 0);
            Assert.IsTrue(x2 >= 0);
            Assert.IsTrue(y1 >= 0);
            Assert.IsTrue(y2 >= 0);
        }

        //DrawRectangle
        public void DrawRectangle(double x1, double y1, double width, double height)
        {
            Assert.IsTrue(x1 >= 0);
            Assert.IsTrue(y1 >= 0);
            Assert.IsTrue(width >= 0);
            Assert.IsTrue(height >= 0);
        }
    }
}
