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
        public const string CANVAS_ACCESS = "canvas";

        DrawingModel.Model _model;
        PresentationModel.PresentationModel _presentationModel;
        Panel _canvas = new DoubleBufferedPanel();

        public MainWindow()
        {
            InitializeComponent();
            _canvas.IsAccessible = true;
            _canvas.AccessibleName = CANVAS_ACCESS;
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
            _model._shapeSelect += HandleShapeSelect;
        }

        //HandleRectangleButtonClick
        private void HandleRectangleButtonClick(object sender, EventArgs e)
        {
            _rectangle.Enabled = false;
            _hexagon.Enabled = true;
            _line.Enabled = true;
            _model.ChangeShape(DrawingModel.Model.ShapeType.RECTANGLE);
        }

        //HandleLineButtonClick
        public void HandleLineButtonClick(object sender, EventArgs e)
        {
            _rectangle.Enabled = true;
            _hexagon.Enabled = true;
            _line.Enabled = false;
            _model.ChangeShape(DrawingModel.Model.ShapeType.LINE);
        }

        //HandleHexagonButtonClick
        private void HandleHexagonButtonClick(object sender, EventArgs e)
        {
            _rectangle.Enabled = true;
            _hexagon.Enabled = false;
            _line.Enabled = true;
            _model.ChangeShape(DrawingModel.Model.ShapeType.HEXAGON);
        }

        //HandleClearButtonClick
        public void HandleClearButtonClick(object sender, EventArgs e)
        {
            _rectangle.Enabled = true;
            _line.Enabled = true;
            _hexagon.Enabled = true;
            _model.ExecuteClear();
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
            _rectangle.Enabled = true;
            _line.Enabled = true;
            _hexagon.Enabled = true;
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

        //HandleUndo
        private void HandleUndo(object sender, EventArgs e)
        {
            _model.Undo();
        }

        //HandleRedo
        private void HandleRedo(object sender, EventArgs e)
        {
            _model.Redo();
        }

        //HandleModelChanged
        public void HandleModelChanged()
        {
            Invalidate(true);
            _undo.Enabled = _model.IsUndoEnabled();
            _redo.Enabled = _model.IsRedoEnabled();
        }

        //HandleShapeSelect
        public void HandleShapeSelect(string shapeInfo)
        {
            _info.Text = shapeInfo;
        }

        //HandleSaveClick
        private void HandleSaveClick(object sender, EventArgs e)
        {

        }

        //HandleLoadClick
        private void HandleLoadClick(object sender, EventArgs e)
        {

        }
    }
}
