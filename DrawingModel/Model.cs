using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();

        const string LINE = "Line";
        const string RECTANGLE = "Rectangle";
        string _currentShape = LINE;
        bool _isPressed = false;
        List<Shape> _shapes = new List<Shape>();
        Shape _hint = new Line();

        //ChangeShape
        public void ChangeShape(string shape)
        {
            Console.WriteLine(shape);
            _currentShape = shape;
            switch (shape)
            {
                case LINE:
                    _hint = new Line();
                    break;
                case RECTANGLE:
                    _hint = new Rectangle();
                    break;
            }
        }

        //PointerPressed
        public void PressPointer(double x, double y)
        {
            if (x > 0 && y > 0)
            {
                _hint.x1 = x;
                _hint.y1 = y;
                _isPressed = true;
            }
        }

        //PointerMoved
        public void MovePointer(double x, double y)
        {
            if (_isPressed)
            {
                _hint.x2 = x;
                _hint.y2 = y;
                NotifyModelChanged();
            }
        }

        //PointerReleased
        public void ReleasePointer(double x, double y)
        {
            if (_isPressed)
            {
                _isPressed = false;
                _shapes.Add(_hint);
                ChangeShape(_currentShape);
                NotifyModelChanged();
            }
        }

        //Clear
        public void Clear()
        {
            _isPressed = false;
            _shapes.Clear();
            NotifyModelChanged();
        }

        //Draw
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (Shape aShape in _shapes)
                aShape.Draw(graphics);
            if (_isPressed)
                _hint.Draw(graphics);
        }

        //NotifyModelChanged
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
    }
}
