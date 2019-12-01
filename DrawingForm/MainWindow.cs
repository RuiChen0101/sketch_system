using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingForm
{
    public partial class MainWindow : Form
    {
        DrawingModel.Model _model;
        PresentationModel.PresentationModel _presentationModel;
        Panel _canvas = new DoubleBufferedPanel();
        List<Button> _shapesButton = new List<Button>();

        public MainWindow()
        {
            InitializeComponent();
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = Color.LightYellow;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            Controls.Add(_canvas);
            _model = new DrawingModel.Model();
            _presentationModel = new PresentationModel.PresentationModel(_model,_canvas);
            _model._modelChanged += HandleModelChanged;
            this.InitialButtonList();
        }

        //InitialButtonList
        private void InitialButtonList()
        {
            _shapesButton.Add(this._line);
            _shapesButton.Add(this._rectangle);
        }

        //HandleShapeButtonClick
        public void HandleShapeButtonClick(object sender, EventArgs e)
        {
            foreach (Button button in _shapesButton)
            {
                button.Enabled = true;
            }
            Button source = (Button)sender;
            source.Enabled = false;
            _model.ChangeShape(source.Text);
        }

        //HandleClearButtonClick
        public void HandleClearButtonClick(object sender, EventArgs e)
        {
            _model.Clear();
        }

        //HandleCanvasPressed
        public void HandleCanvasPressed(object sender, MouseEventArgs e)
        {
            _model.PressPointer(e.X, e.Y);
        }

        //HandleCanvasReleased
        public void HandleCanvasReleased(object sender, MouseEventArgs e)
        {
            _model.ReleasePointer(e.X, e.Y);
        }

        //HandleCanvasMoved
        public void HandleCanvasMoved(object sender, MouseEventArgs e)
        {
            _model.MovePointer(e.X, e.Y);
        }

        //HandleCanvasPaint
        public void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        //HandleModelChanged
        public void HandleModelChanged()
        {
            Invalidate(true);
        }
    }
}
