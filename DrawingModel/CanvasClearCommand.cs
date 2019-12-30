using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class CanvasClearCommand : ICommand
    {
        List<Shape> _shapes;
        Model _model;
        public CanvasClearCommand(Model model, List<Shape> shapes)
        {
            _shapes = shapes;
            _model = model;
        }

        //Execute
        public void Execute()
        {
            _model.Clear();
        }

        //UnExecute
        public void ReverseExecute()
        {
            foreach (Shape shape in _shapes)
            {
                _model.AddShape(shape);
            }
        }
    }
}