using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace DrawingApp
{
    public sealed partial class MainPage : Page
    {
        DrawingModel.Model _model;
        PresentationModel.PresentationModel _presentationModel;

        public MainPage()
        {
            this.InitializeComponent();
            _model = new DrawingModel.Model();
            _presentationModel = new PresentationModel.PresentationModel(_model,_canvas);
            _canvas.PointerPressed += HandleCanvasPressed;
            _canvas.PointerReleased += HandleCanvasReleased;
            _canvas.PointerMoved += HandleCanvasMoved;
            _clear.Click += HandleClearButtonClick;
            _model._modelChanged += HandleModelChanged;
            _model._shapeSelect += HandleShapeSelect;
        }

        //HandleRectangleButtonClick
        private void HandleRectangleButtonClick(object sender, RoutedEventArgs e)
        {
            _rectangle.IsEnabled = false;
            _line.IsEnabled = true;
            _hexagon.IsEnabled = true;
            _model.ChangeShape(DrawingModel.Model.ShapeType.RECTANGLE);
        }

        //HandleLineButtonClick
        public void HandleLineButtonClick(object sender, RoutedEventArgs e)
        {
            _rectangle.IsEnabled = true;
            _line.IsEnabled = false;
            _hexagon.IsEnabled = true;
            _model.ChangeShape(DrawingModel.Model.ShapeType.LINE);
        }

        //HandleHexagonButtonClick
        public void HandleHexagonButtonClick(object sender, RoutedEventArgs e)
        {
            _rectangle.IsEnabled = true;
            _line.IsEnabled = true;
            _hexagon.IsEnabled = false;
            _model.ChangeShape(DrawingModel.Model.ShapeType.HEXAGON);
        }

        //HandleClearButtonClick
        private void HandleClearButtonClick(object sender, RoutedEventArgs e)
        {
            _rectangle.IsEnabled = true;
            _line.IsEnabled = true;
            _hexagon.IsEnabled = true;
            _model.ExecuteClear();
        }

        //HandleCanvasPressed
        public void HandleCanvasPressed(object sender, PointerRoutedEventArgs e)
        {
            _model.PressPointer(e.GetCurrentPoint(_canvas).Position.X,e.GetCurrentPoint(_canvas).Position.Y);
        }

        //HandleCanvasReleased
        public void HandleCanvasReleased(object sender, PointerRoutedEventArgs e)
        {
            _model.ReleasePointer(e.GetCurrentPoint(_canvas).Position.X,e.GetCurrentPoint(_canvas).Position.Y);
            _rectangle.IsEnabled = true;
            _line.IsEnabled = true;
            _hexagon.IsEnabled = true;
        }

        //HandleCanvasMoved
        public void HandleCanvasMoved(object sender, PointerRoutedEventArgs e)
        {
            _model.MovePointer(e.GetCurrentPoint(_canvas).Position.X,e.GetCurrentPoint(_canvas).Position.Y);
        }

        //HandleModelChanged
        public void HandleModelChanged()
        {
            _presentationModel.Draw();
            _undo.IsEnabled = _model.IsUndoEnabled();
            _redo.IsEnabled = _model.IsRedoEnabled();
        }

        //HandleShapeSelect
        public void HandleShapeSelect(string shapeInfo)
        {
            _info.Text = shapeInfo;
        }

        //HandleUndo
        private void HandleUndo(object sender, RoutedEventArgs e)
        {
            _model.Undo();
        }

        //HandleRedo
        private void HandleRedo(object sender, RoutedEventArgs e)
        {
            _model.Redo();
        }
    }
}
