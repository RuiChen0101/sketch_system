using System;
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
    }
}
