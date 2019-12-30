using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public interface IMouseState
    {
        //PressPointer
        void PressPointer(double x, double y);

        //PointerMoved
        void MovePointer(double x, double y);

        //PointerReleased
        void ReleasePointer(double x, double y);
    }
}
