using System;
using System.Collections.Generic;
using DrawingModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrawingTest
{
    [TestClass]
    public class ModelTest
    {
        Model _model;
        PrivateObject _testTarget;

        //init
        [TestInitialize]
        public void TestInitialize()
        {
            _model = new Model();
            _testTarget = new PrivateObject(_model);
            _model._modelChanged += this.TestEvent;
        }

        //ui
        [TestMethod]
        public void TestChangeShape()
        {
            _model.ChangeShape(Model.Status.IDLE);
            Assert.AreEqual(Model.Status.IDLE, _testTarget.GetFieldOrProperty("_currentShape"));
            Assert.IsNull(_testTarget.GetFieldOrProperty("_hint"));

            _model.ChangeShape(Model.Status.LINE);
            Assert.AreEqual(Model.Status.LINE, _testTarget.GetFieldOrProperty("_currentShape"));
            Assert.IsNotNull(_testTarget.GetFieldOrProperty("_hint"));

            _model.ChangeShape(Model.Status.RECTANGLE);
            Assert.AreEqual(Model.Status.RECTANGLE, _testTarget.GetFieldOrProperty("_currentShape"));
            Assert.IsNotNull(_testTarget.GetFieldOrProperty("_hint"));
        }

        //ui
        [TestMethod]
        public void TestPointerIdelDraw()
        {
            _model.ChangeShape(Model.Status.IDLE);
            _model.PressPointer(1, 1);
            _model.MovePointer(1, 1);
            _model.ReleasePointer(1, 1);
            Assert.AreEqual(false, _testTarget.GetFieldOrProperty("_isPressed"));
        }

        //ui
        [TestMethod]
        public void TestPointerNoPressDraw()
        {
            _model.ChangeShape(Model.Status.LINE);
            _model.PressPointer(-1, 0);
            Assert.AreEqual(false, _testTarget.GetFieldOrProperty("_isPressed"));
            _model.MovePointer(100, 100);
            _model.ReleasePointer(100, 100);
            Assert.AreEqual(false, _testTarget.GetFieldOrProperty("_isPressed"));

            _model.ChangeShape(Model.Status.LINE);
            _model.PressPointer(0, -1);
            Assert.AreEqual(false, _testTarget.GetFieldOrProperty("_isPressed"));
            _model.MovePointer(100, 100);
            _model.ReleasePointer(100, 100);
            Assert.AreEqual(false, _testTarget.GetFieldOrProperty("_isPressed"));
        }

        //TestPointerLineDraw
        [TestMethod]
        public void TestPointerLineDraw()
        {
            _model.ChangeShape(Model.Status.LINE);

            _model.PressPointer(1, 1);
            Assert.AreEqual(true, _testTarget.GetFieldOrProperty("_isPressed"));
            _model.MovePointer(1, 1);
            Assert.AreEqual(true, _testTarget.GetFieldOrProperty("_isPressed"));
            _model.ReleasePointer(2, 2);
            Assert.AreEqual(false, _testTarget.GetFieldOrProperty("_isPressed"));
            Assert.AreEqual(Model.Status.LINE, _testTarget.GetFieldOrProperty("_currentShape"));
        }

        //TestPointerRectangleDraw
        [TestMethod]
        public void TestPointerRectangleDraw()
        {
            _model.ChangeShape(Model.Status.RECTANGLE);

            _model.PressPointer(1, 1);
            Assert.AreEqual(true, _testTarget.GetFieldOrProperty("_isPressed"));
            _model.MovePointer(100, 100);
            Assert.AreEqual(true, _testTarget.GetFieldOrProperty("_isPressed"));
            _model.ReleasePointer(100, 100);
            Assert.AreEqual(false, _testTarget.GetFieldOrProperty("_isPressed"));
            Assert.AreEqual(Model.Status.RECTANGLE, _testTarget.GetFieldOrProperty("_currentShape"));

            _model.PressPointer(100, 100);
            Assert.AreEqual(true, _testTarget.GetFieldOrProperty("_isPressed"));
            _model.MovePointer(1, 1);
            Assert.AreEqual(true, _testTarget.GetFieldOrProperty("_isPressed"));
            _model.ReleasePointer(1, 1);
            Assert.AreEqual(false, _testTarget.GetFieldOrProperty("_isPressed"));
            Assert.AreEqual(Model.Status.RECTANGLE, _testTarget.GetFieldOrProperty("_currentShape"));
        }

        //TestClear
        [TestMethod]
        public void TestClear()
        {
            _model.ChangeShape(Model.Status.RECTANGLE);

            _model.PressPointer(1, 1);
            _model.MovePointer(1, 1);
            _model.ReleasePointer(2, 2);

            List<Shape> shapes = (List<Shape>)_testTarget.GetFieldOrProperty("_shapes");
            Assert.AreEqual(1, shapes.Count);

            _model.Clear();

            shapes = (List<Shape>)_testTarget.GetFieldOrProperty("_shapes");
            Assert.AreEqual(0, shapes.Count);
        }

        //event
        private void TestEvent()
        {
            _model.Draw(new TestGraphicsAdaptor());
        }
    }
}
