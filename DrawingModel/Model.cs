using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        public event ShapeSelectEventHandler _shapeSelect;
        public delegate void ShapeSelectEventHandler(string shapeInfo);

        public enum ShapeType
        {
            IDLE,
            LINE,
            RECTANGLE,
            HEXAGON
        };

        CommandManager _commandManager = new CommandManager();
        IMouseState _mouseState = null;
        List<Shape> _shapes = new List<Shape>();
        Shape _hint = null;
        Shape _selected = null;

        public Model()
        {
            this.SetPointerState();
        }

        //ChangeShape
        public void ChangeShape(ShapeType type)
        {
            SetDrawState(type);
        }

        //PointerPressed
        public void PressPointer(double x, double y)
        {
            _mouseState.PressPointer(x, y);
            this._modelChanged();
        }

        //PointerMoved
        public void MovePointer(double x, double y)
        {
            _mouseState.MovePointer(x, y);
            this._modelChanged();
        }

        //PointerReleased
        public void ReleasePointer(double x, double y)
        {
            _mouseState.ReleasePointer(x, y);
            this._modelChanged();
        }

        //WriteBackHint
        public void SetHint(Shape hint)
        {
            _hint = hint;
        }

        //Selected
        public Shape Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }

        //FinishDraw
        public void FinishDraw(Shape hint)
        {
            _commandManager.Execute(new DrawCommand(this, hint.Clone()));
            _hint = null;
            SetPointerState();
        }

        //FinishResize
        public void FinishResize(double x1, double y1, double x2, double y2)
        {
            _commandManager.Execute(new ResizeCommand(_selected, x1, y1, x2, y2));
            this._shapeSelect(_selected.GetShapeInfo());
        }

        //AddShape
        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        //DeleteLastShape
        public void DeleteLastShape()
        {
            _shapes.RemoveAt(_shapes.Count - 1);
        }

        //ClickCanvas
        public void CheckShapeClick(double x, double y)
        {
            for (int i = _shapes.Count - 1; i >= 0; i--)
            {
                if (_shapes[i].IsShapeClick(x, y))
                {
                    _selected = _shapes[i];
                    this._shapeSelect(_selected.GetShapeInfo());
                    this._modelChanged();
                    return;
                }
            }
            _selected = null;
            this._shapeSelect("");
            this._modelChanged();
        }

        //ExecuteClear
        public void ExecuteClear()
        {
            _commandManager.Execute(new CanvasClearCommand(this, new List<Shape>(_shapes)));
        }

        //SetDrawState
        public void SetDrawState(ShapeType type)
        {
            _mouseState = new DrawState(this, type);
            _selected = null;
            this._shapeSelect("");
        }

        //SetPointerState
        public void SetPointerState()
        {
            _mouseState = new PointerState(this);
        }

        //Clear
        public void Clear()
        {
            _selected = null;
            _hint = null;
            SetPointerState();
            _shapes.Clear();
            this._shapeSelect("");
            this._modelChanged();
        }

        //Draw
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (Shape aShape in _shapes)
                aShape.Draw(graphics);
            if (_hint != null)
                _hint.Draw(graphics);
            if (_selected != null)
                _selected.DrawBorder(graphics);
        }

        //Undo
        public void Undo()
        {
            _commandManager.Undo();
            _selected = null;
            this._modelChanged();
        }

        //Redo
        public void Redo()
        {
            _commandManager.Redo();
            _selected = null;
            this._modelChanged();
        }

        //IsRedoEnabled
        public bool IsRedoEnabled()
        {
            return _commandManager.IsRedoEnabled();
        }

        //IsUndoEnabled
        public bool IsUndoEnabled()
        {
            return _commandManager.IsUndoEnabled();
        }
    }
}
