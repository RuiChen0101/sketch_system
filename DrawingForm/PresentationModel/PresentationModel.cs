using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DrawingModel;
using System.Windows.Forms;

namespace DrawingForm.PresentationModel
{
    public class PresentationModel
    {
        Model _model;
        public PresentationModel(Model model, Control canvas)
        {
            this._model = model;
        }

        //Draw
        public void Draw(Graphics graphics)
        {
            _model.Draw(new WindowsFormsGraphicsAdaptor(graphics));
        }
    }
}
