using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class DrawState : IMouseState
    {
        Model _model;
        ShapeFactory _shapeFactory = new ShapeFactory();
        Shape _hint = null;
        bool _isPressed = false;

        public DrawState(Model model, Model.ShapeType type)
        {
            _model = model;
            _hint = _shapeFactory.CreateShape(type);
        }

        //PressPointer
        public void PressPointer(double x, double y)
        {
            if (x > 0 && y > 0 && _hint != null)
            {
                _hint.SetStartPoint(x, y);
                _isPressed = true;
                _model.SetHint(_hint);
            }
        }

        //PointerMoved
        public void MovePointer(double x, double y)
        {
            if (_isPressed && _hint != null)
            {
                _hint.OnDrag(x, y);
                _model.SetHint(_hint);
            }
        }

        //PointerReleased
        public void ReleasePointer(double x, double y)
        {
            if (_isPressed && _hint != null)
            {
                _hint.SetStopPoint(x, y);
                _model.FinishDraw(_hint);
            }
        }
    }
}
