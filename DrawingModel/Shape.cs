using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class Shape
    {
        protected double _x1;
        protected double _y1;
        protected double _x2;
        protected double _y2;

        //Draw
        public virtual void Draw(IGraphics graphics)
        {

        }

        public double x1
        {
            get
            {
                return _x1;
            }
            set
            {
                _x1 = value;
            }
        }

        public double x2
        {
            get
            {
                return _x2;
            }
            set
            {
                _x2 = value;
            }
        }

        public double y1
        {
            get
            {
                return _y1;
            }
            set
            {
                _y1 = value;
            }
        }

        public double y2
        {
            get
            {
                return _y2;
            }
            set
            {
                _y2 = value;
            }
        }
    }
}
