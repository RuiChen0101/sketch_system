using System.Collections.Generic;
using DrawingModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrawingTest
{

    [TestClass]
    public class CommandTest
    {
        Model _model;
        CommandManager _commandManager;
        PrivateObject _privateCommandManager;
        PrivateObject _privateModel;
        //init
        [TestInitialize]
        public void TestInitialize()
        {
            _model = new Model();
            _commandManager = new CommandManager();
            _privateModel = new PrivateObject(_model);
            _privateCommandManager = new PrivateObject(_commandManager);
            _model._modelChanged += this.TestEvent;
            _model._shapeSelect += this.ShapeSelectTestEvent;
        }

        //ut
        [TestMethod]
        public void DrawCommandTest()
        {
            _commandManager.Execute(new DrawCommand(_model, new Shape()));
            Assert.AreEqual(1, ((List<Shape>)_privateModel.GetFieldOrProperty("_shapes")).Count);
            Assert.AreEqual(1, ((Stack<ICommand>)_privateCommandManager.GetFieldOrProperty("_undo")).Count);
            Assert.AreEqual(0, ((Stack<ICommand>)_privateCommandManager.GetFieldOrProperty("_redo")).Count);

            _commandManager.Undo();
            Assert.AreEqual(0, ((List<Shape>)_privateModel.GetFieldOrProperty("_shapes")).Count);
            Assert.AreEqual(0, ((Stack<ICommand>)_privateCommandManager.GetFieldOrProperty("_undo")).Count);
            Assert.AreEqual(1, ((Stack<ICommand>)_privateCommandManager.GetFieldOrProperty("_redo")).Count);

            _commandManager.Redo();
            Assert.AreEqual(1, ((List<Shape>)_privateModel.GetFieldOrProperty("_shapes")).Count);
            Assert.AreEqual(1, ((Stack<ICommand>)_privateCommandManager.GetFieldOrProperty("_undo")).Count);
            Assert.AreEqual(0, ((Stack<ICommand>)_privateCommandManager.GetFieldOrProperty("_redo")).Count);
        }

        //ut
        [TestMethod]
        public void CanvasClearCommandTest()
        {
            _commandManager.Execute(new DrawCommand(_model, new Shape()));
            _commandManager.Execute(new DrawCommand(_model, new Shape()));
            Assert.AreEqual(2, ((List<Shape>)_privateModel.GetFieldOrProperty("_shapes")).Count);

            _commandManager.Execute(new CanvasClearCommand(_model, new List<Shape>((List<Shape>)_privateModel.GetFieldOrProperty("_shapes"))));
            Assert.AreEqual(0, ((List<Shape>)_privateModel.GetFieldOrProperty("_shapes")).Count);
            Assert.AreEqual(3, ((Stack<ICommand>)_privateCommandManager.GetFieldOrProperty("_undo")).Count);

            _commandManager.Undo();
            Assert.AreEqual(2, ((List<Shape>)_privateModel.GetFieldOrProperty("_shapes")).Count);
            Assert.AreEqual(2, ((Stack<ICommand>)_privateCommandManager.GetFieldOrProperty("_undo")).Count);
            Assert.AreEqual(1, ((Stack<ICommand>)_privateCommandManager.GetFieldOrProperty("_redo")).Count);

            _commandManager.Redo();
            Assert.AreEqual(0, ((List<Shape>)_privateModel.GetFieldOrProperty("_shapes")).Count);
            Assert.AreEqual(3, ((Stack<ICommand>)_privateCommandManager.GetFieldOrProperty("_undo")).Count);
            Assert.AreEqual(0, ((Stack<ICommand>)_privateCommandManager.GetFieldOrProperty("_redo")).Count);
        }

        //ut
        [TestMethod]
        public void UndoEnableTest()
        {
            Assert.IsFalse(_commandManager.IsUndoEnabled());
            _commandManager.Execute(new DrawCommand(_model, new Shape()));
            Assert.IsTrue(_commandManager.IsUndoEnabled());
            _commandManager.Undo();
            Assert.IsFalse(_commandManager.IsUndoEnabled());
        }

        //ut
        [TestMethod]
        public void RedoEnableTest()
        {
            Assert.IsFalse(_commandManager.IsRedoEnabled());
            _commandManager.Execute(new DrawCommand(_model, new Shape()));
            Assert.IsFalse(_commandManager.IsRedoEnabled());
            _commandManager.Undo();
            Assert.IsTrue(_commandManager.IsRedoEnabled());
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
