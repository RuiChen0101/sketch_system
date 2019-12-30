using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class PointerState : IMouseState
    {
        Model _model;
        double _x1;
        double _y1;
        bool _isResize = false;
        public PointerState(Model model)
        {
            _model = model;
        }

        //PressPointer
        public void PressPointer(double x, double y)
        {
            if (_model.Selected != null)
            {
                if (_model.Selected.IsShapeResizeClick(x, y))
                {
                    _isResize = true;
                    _x1 = x;
                    _y1 = y;
                    _model.Selected.SetResizePoint(x, y);
                }
                else
                {
                    _model.CheckShapeClick(x, y);
                }
            }
            else
            {
                _model.CheckShapeClick(x, y);
            }
        }

        //PointerMoved
        public void MovePointer(double x, double y)
        {
            if (_model.Selected != null && _isResize)
            {
                _model.Selected.SetResizePoint(x,y);
            }

        }

        //PointerReleased
        public void ReleasePointer(double x, double y)
        {
            if (_model.Selected != null && _isResize)
            {
                _model.FinishResize(_x1, _y1, x, y);
                _isResize = false;
            }
        }
    }
}
