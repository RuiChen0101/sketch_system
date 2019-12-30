using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class ResizeCommand : ICommand
    {
        Shape _shape;
        double _x1;
        double _y1;
        double _x2;
        double _y2;
        public ResizeCommand(Shape shape, double x1, double y1, double x2, double y2)
        {
            _shape = shape;
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
        }

        //Execute
        public void Execute()
        {
            _shape.SetResizePoint(_x2, _y2);
            _shape.SetStopPoint(_x2, _y2);
        }

        //UnExecute
        public void ReverseExecute()
        {
            _shape.SetResizePoint(_x1, _y1);
            _shape.SetStopPoint(_x1, _y1);
        }
    }
}
