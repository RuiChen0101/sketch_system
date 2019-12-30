using System;
using System.Collections.Generic;
using DrawingModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrawingTest
{
    [TestClass]
    public class ModelTest
    {
        const double x1 = 100;
        const double y1 = 100;
        const double x2 = 200;
        const double y2 = 200;
        const double x3 = 300;
        const double y3 = 300;
        Model _model;
        PrivateObject _testTarget;

        //init
        [TestInitialize]
        public void TestInitialize()
        {
            _model = new Model();
            _testTarget = new PrivateObject(_model);
            _model._modelChanged += this.TestEvent;
            _model._shapeSelect += this.ShapeSelectTestEvent;
        }

        //ut
        [TestMethod]
        public void ChangeShapeTest()
        {
            _model.ChangeShape(Model.ShapeType.LINE);
            Assert.AreEqual(Model.ShapeType.LINE, _testTarget.GetFieldOrProperty("_currentShape"));
            Assert.IsNotNull(_testTarget.GetFieldOrProperty("_hint"));

            _model.ChangeShape(Model.ShapeType.RECTANGLE);
            Assert.AreEqual(Model.ShapeType.RECTANGLE, _testTarget.GetFieldOrProperty("_currentShape"));
            Assert.IsNotNull(_testTarget.GetFieldOrProperty("_hint"));

            _model.ChangeShape(Model.ShapeType.HEXAGON);
            Assert.AreEqual(Model.ShapeType.HEXAGON, _testTarget.GetFieldOrProperty("_currentShape"));
            Assert.IsNotNull(_testTarget.GetFieldOrProperty("_hint"));
        }

        //ut
        [TestMethod]
        public void PointerNoPressDrawTest()
        {
            _model.ChangeShape(Model.ShapeType.LINE);
            _model.PressPointer(-1, -1);
            Assert.IsFalse((bool)_testTarget.GetFieldOrProperty("_isPressed"));
            _model.MovePointer(x2, y2);
            _model.ReleasePointer(x3, y3);
            Assert.IsFalse((bool)_testTarget.GetFieldOrProperty("_isPressed"));
        }

        //ut
        [TestMethod]
        public void PointerLineDrawTest()
        {
            _model.ChangeShape(Model.ShapeType.LINE);

            _model.PressPointer(x1, y1);
            _model.MovePointer(x2, y2);
            _model.ReleasePointer(x3, y3);
            Assert.AreEqual(1, ((List<Shape>)_testTarget.GetFieldOrProperty("_shapes")).Count);
            Assert.AreEqual(Model.ShapeType.LINE, _testTarget.GetFieldOrProperty("_currentShape"));
        }

        //ut
        [TestMethod]
        public void PointerRectangleDrawTest()
        {
            _model.ChangeShape(Model.ShapeType.RECTANGLE);

            _model.PressPointer(x1, y1);
            _model.MovePointer(x2, y2);
            _model.ReleasePointer(x3, y3);
            Assert.AreEqual(1, ((List<Shape>)_testTarget.GetFieldOrProperty("_shapes")).Count);
            Assert.AreEqual(Model.ShapeType.RECTANGLE, _testTarget.GetFieldOrProperty("_currentShape"));

            _model.PressPointer(x3, y3);
            _model.MovePointer(x2, y2);
            _model.ReleasePointer(x1, y1);
            Assert.AreEqual(2, ((List<Shape>)_testTarget.GetFieldOrProperty("_shapes")).Count);
            Assert.AreEqual(Model.ShapeType.RECTANGLE, _testTarget.GetFieldOrProperty("_currentShape"));
        }

        //ut
        [TestMethod]
        public void PointerHexagonDrawTest()
        {
            _model.ChangeShape(Model.ShapeType.HEXAGON);

            _model.PressPointer(x1, y1);
            _model.MovePointer(x2, y2);
            _model.ReleasePointer(x3, y3);
            Assert.AreEqual(1, ((List<Shape>)_testTarget.GetFieldOrProperty("_shapes")).Count);
            Assert.AreEqual(Model.ShapeType.HEXAGON, _testTarget.GetFieldOrProperty("_currentShape"));

            _model.PressPointer(x3, y3);
            _model.MovePointer(x2, y2);
            _model.ReleasePointer(x1, y1);
            Assert.AreEqual(2, ((List<Shape>)_testTarget.GetFieldOrProperty("_shapes")).Count);
            Assert.AreEqual(Model.ShapeType.HEXAGON, _testTarget.GetFieldOrProperty("_currentShape"));
        }

        //ut
        [TestMethod]
        public void ClearTest()
        {
            _model.ChangeShape(Model.ShapeType.RECTANGLE);

            _model.PressPointer(x1, y1);
            _model.MovePointer(x2, y2);
            _model.ReleasePointer(x3, y3);
            Assert.AreEqual(1, ((List<Shape>)_testTarget.GetFieldOrProperty("_shapes")).Count);

            _model.ExecuteClear();

            Assert.IsFalse((bool)_testTarget.GetFieldOrProperty("_isPressed"));
            Assert.IsNull(_testTarget.GetFieldOrProperty("_hint"));
            Assert.IsNull(_testTarget.GetFieldOrProperty("_selected"));
            Assert.AreEqual(0, ((List<Shape>)_testTarget.GetFieldOrProperty("_shapes")).Count);
        }

        //ut
        [TestMethod]
        public void ShapeClickTest()
        {
            _model.ChangeShape(Model.ShapeType.RECTANGLE);

            _model.PressPointer(x1, y1);
            _model.MovePointer(x2, y2);
            _model.ReleasePointer(x3, y3);
            Assert.IsNull(_testTarget.GetFieldOrProperty("_selected"));

            _model.PressPointer(x2, y2);
            Assert.IsNotNull(_testTarget.GetFieldOrProperty("_selected"));

            _model.PressPointer(400, 400);
            Assert.IsNull(_testTarget.GetFieldOrProperty("_selected"));
        }

        //ut
        [TestMethod]
        public void UndoTest()
        {
            _model.ChangeShape(Model.ShapeType.RECTANGLE);
            Assert.IsFalse(_model.IsUndoEnabled());
            _model.PressPointer(x1, y1);
            _model.MovePointer(x2, y2);
            _model.ReleasePointer(x3, y3);
            Assert.IsTrue(_model.IsUndoEnabled());
            _model.Undo();
            Assert.IsFalse(_model.IsUndoEnabled());
        }

        //ut
        [TestMethod]
        public void RedoTest()
        {
            _model.ChangeShape(Model.ShapeType.RECTANGLE);
            Assert.IsFalse(_model.IsRedoEnabled());
            _model.PressPointer(x1, y1);
            _model.MovePointer(x2, y2);
            _model.ReleasePointer(x3, y3);
            Assert.IsFalse(_model.IsRedoEnabled());
            _model.Undo();
            Assert.IsTrue(_model.IsRedoEnabled());
            _model.Redo();
            Assert.IsFalse(_model.IsRedoEnabled());
        }

        //event
        private void TestEvent()
        {
            _model.Draw(new TestGraphicsAdaptor());
        }

        //event
        private void ShapeSelectTestEvent(string shapeInfo)
        {
            Assert.IsTrue(true);
        }
    }
}
