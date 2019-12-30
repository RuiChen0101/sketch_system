using System.Collections.Generic;
using DrawingModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrawingTest
{
    [TestClass]
    public class ShapeTest
    {
        const double x1 = 100;
        const double y1 = 100;
        const double x2 = 200;
        const double y2 = 200;
        const double x3 = 300;
        const double y3 = 300;
        //ut
        [TestMethod]
        public void DefaultShapeTest()
        {
            Shape shape = new Shape();
            PrivateObject testTarget = new PrivateObject(shape);
            shape.SetStartPoint(x1, y1);
            shape.OnDrag(x2, y2);
            shape.SetStopPoint(x3, y3);

            Assert.AreEqual(x1, testTarget.GetFieldOrProperty("_x1"));
            Assert.AreEqual(y1, testTarget.GetFieldOrProperty("_y1"));
            Assert.AreEqual(x3, testTarget.GetFieldOrProperty("_x2"));
            Assert.AreEqual(y3, testTarget.GetFieldOrProperty("_y2"));
            Assert.AreEqual("Selected : Default Shape(100,100,300,300)",shape.GetShapeInfo());
        }

        //ut
        [TestMethod]
        public void ReverseDragTest()
        {
            Shape shape = new Shape();
            PrivateObject testTarget = new PrivateObject(shape);
            shape.SetStartPoint(x3, y3);
            shape.OnDrag(x2, y2);
            shape.SetStopPoint(x1, y1);

            Assert.AreEqual(x1, testTarget.GetFieldOrProperty("_x1"));
            Assert.AreEqual(y1, testTarget.GetFieldOrProperty("_y1"));
            Assert.AreEqual(x3, testTarget.GetFieldOrProperty("_x2"));
            Assert.AreEqual(y3, testTarget.GetFieldOrProperty("_y2"));
            Assert.AreEqual("Selected : Default Shape(100,100,300,300)", shape.GetShapeInfo());
        }

        //ut
        [TestMethod]
        public void ShapeCloneTest()
        {
            Shape shape = new Shape();
            shape.SetStartPoint(x1, y1);
            shape.OnDrag(x2, y2);
            shape.SetStopPoint(x3, y3);

            Shape newShape = shape.Clone();
            PrivateObject testTarget = new PrivateObject(newShape);

            shape.SetStopPoint(x2, y2);

            Assert.AreEqual(x1, testTarget.GetFieldOrProperty("_x1"));
            Assert.AreEqual(y1, testTarget.GetFieldOrProperty("_y1"));
            Assert.AreEqual(x3, testTarget.GetFieldOrProperty("_x2"));
            Assert.AreEqual(y3, testTarget.GetFieldOrProperty("_y2"));
            Assert.AreEqual("Selected : Default Shape(100,100,300,300)", newShape.GetShapeInfo());
        }

        //ut
        [TestMethod]
        public void ShapeClickTest()
        {
            Shape shape = new Shape();
            shape.SetStartPoint(x1, y1);
            shape.OnDrag(x2, y2);
            shape.SetStopPoint(x3, y3);

            Assert.IsFalse(shape.IsShapeClick(400, 400));
            Assert.IsFalse(shape.IsShapeClick(0, 0));
            Assert.IsTrue(shape.IsShapeClick(x2, x2));
        }

        //ut
        [TestMethod]
        public void LineTest()
        {
            Line shape = new Line();
            PrivateObject testTarget = new PrivateObject(shape);
            shape.SetStartPoint(x1, y1);
            shape.OnDrag(x2, y2);
            shape.SetStopPoint(x3, y3);
            Assert.AreEqual("Line", shape.GetShapeName());
            Assert.AreEqual("Selected : Line(100,100,300,300)", shape.GetShapeInfo());
        }

        //ut
        [TestMethod]
        public void RectangleTest()
        {
            Rectangle shape = new Rectangle();
            PrivateObject testTarget = new PrivateObject(shape);
            shape.SetStartPoint(x1, y1);
            shape.OnDrag(x2, y2);
            shape.SetStopPoint(x3, y3);
            Assert.AreEqual("Rectangle", shape.GetShapeName());
            Assert.AreEqual("Selected : Rectangle(100,100,300,300)", shape.GetShapeInfo());
        }

        //ut
        [TestMethod]
        public void HexagonTest()
        {
            Hexagon shape = new Hexagon();
            PrivateObject testTarget = new PrivateObject(shape);
            shape.SetStartPoint(x1, y1);
            shape.OnDrag(x2, y2);
            shape.SetStopPoint(x3, y3);
            Assert.AreEqual("Hexagon", shape.GetShapeName());
            Assert.AreEqual("Selected : Hexagon(100,100,300,300)", shape.GetShapeInfo());
        }

        //ut
        [TestMethod]
        public void LineCloneTest()
        {
            Line shape = new Line();
            PrivateObject testTarget = new PrivateObject(shape);
            shape.SetStartPoint(x1, y1);
            shape.OnDrag(x2, y2);
            shape.SetStopPoint(x3, y3);
            Shape newShape = shape.Clone();
            shape.SetStopPoint(x2, y2);
            Assert.AreEqual("Line", newShape.GetShapeName());
            Assert.AreEqual("Selected : Line(100,100,300,300)", newShape.GetShapeInfo());
        }

        //ut
        [TestMethod]
        public void RectangleCloneTest()
        {
            Rectangle shape = new Rectangle();
            PrivateObject testTarget = new PrivateObject(shape);
            shape.SetStartPoint(x1, y1);
            shape.OnDrag(x2, y2);
            shape.SetStopPoint(x3, y3);
            Shape newShape = shape.Clone();
            shape.SetStopPoint(x2, y2);
            Assert.AreEqual("Rectangle", newShape.GetShapeName());
            Assert.AreEqual("Selected : Rectangle(100,100,300,300)", newShape.GetShapeInfo());
        }

        //ut
        [TestMethod]
        public void HexagonCloneTest()
        {
            Hexagon shape = new Hexagon();
            PrivateObject testTarget = new PrivateObject(shape);
            shape.SetStartPoint(x1, y1);
            shape.OnDrag(x2, y2);
            shape.SetStopPoint(x3, y3);
            Shape newShape = shape.Clone();
            shape.SetStopPoint(x2, y2);
            Assert.AreEqual("Hexagon", newShape.GetShapeName());
            Assert.AreEqual("Selected : Hexagon(100,100,300,300)", newShape.GetShapeInfo());
        }
    }
}
