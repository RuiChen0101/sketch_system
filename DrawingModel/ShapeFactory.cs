using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class ShapeFactory
    {
        //CreateShape
        public Shape CreateShape(Model.ShapeType type)
        {
            switch (type)
            {
                case Model.ShapeType.LINE:
                    return new Line();
                case Model.ShapeType.RECTANGLE:
                    return new Rectangle();
                case Model.ShapeType.HEXAGON:
                    return new Hexagon();
                default:
                    return null;
            }
        }
    }
}
