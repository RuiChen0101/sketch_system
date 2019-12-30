using System;
using System.Collections.Generic;
using DrawingModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrawingTest
{
    [TestClass]
    public class ShapeFactoryTest
    {
        ShapeFactory _shapeFactory;

        //init
        [TestInitialize]
        public void TestInitialize()
        {
            _shapeFactory = new ShapeFactory();
        }

        //ut
        [TestMethod]
        public void TestShapeCreate()
        {
            Shape shape = _shapeFactory.CreateShape(Model.ShapeType.IDLE);
            Assert.IsNull(shape);

            shape = _shapeFactory.CreateShape(Model.ShapeType.LINE);
            Assert.AreEqual("Line", shape.GetShapeName());

            shape = _shapeFactory.CreateShape(Model.ShapeType.RECTANGLE);
            Assert.AreEqual("Rectangle", shape.GetShapeName());

            shape = _shapeFactory.CreateShape(Model.ShapeType.HEXAGON);
            Assert.AreEqual("Hexagon", shape.GetShapeName());
        }
    }
}
