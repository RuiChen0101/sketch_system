using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using DrawingModel;
using Windows.UI.Xaml;

namespace DrawingApp.PresentationModel
{
    class WindowsStoreGraphicsAdaptor : IGraphics
    {
        Canvas _canvas;
        public WindowsStoreGraphicsAdaptor(Canvas canvas)
        {
            this._canvas = canvas;
        }

        //ClearAll
        public void ClearAll()
        {
            _canvas.Children.Clear();
        }

        //DrawLine
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(line);
        }

        //DrawRectangle
        public void DrawRectangle(double x1, double y1, double width, double height)
        {
            Windows.UI.Xaml.Shapes.Rectangle rectangle = new Windows.UI.Xaml.Shapes.Rectangle();
            rectangle.Margin = new Thickness(x1, y1, 0, 0);
            rectangle.Width = width;
            rectangle.Height = height;
            rectangle.Stroke = new SolidColorBrush(Colors.Black);
            rectangle.Fill = new SolidColorBrush(Colors.Green);
            _canvas.Children.Add(rectangle);
        }

        //DrawHexagon
        public void DrawHexagon(Tuple<double, double>[] points)
        {
            Windows.UI.Xaml.Shapes.Polygon polygon = new Windows.UI.Xaml.Shapes.Polygon();
            PointCollection point = new PointCollection();
            foreach (Tuple<double, double> tuple in points)
            {
                point.Add(new Windows.Foundation.Point(tuple.Item1, tuple.Item2));
            }
            polygon.Points = point;
            polygon.Stroke = new SolidColorBrush(Colors.Black);
            polygon.Fill = new SolidColorBrush(Colors.RoyalBlue);
            _canvas.Children.Add(polygon);
        }

        //DrawDashBorder
        public void DrawDashBorder(double x1, double y1, double x2, double y2)
        {
            const int POINT_OFFSET = 5;
            const int CIRCLE_RADIUS = 10;
            const int DASH_GAP = 3;
            const int DASH_LENGTH = 5;
            const int PEN_WIDTH = 2;
            Windows.UI.Xaml.Shapes.Rectangle rectangle = new Windows.UI.Xaml.Shapes.Rectangle();
            rectangle.Margin = new Thickness(x1, y1, 0, 0);
            rectangle.Width = x2 - x1;
            rectangle.Height = y2 - y1;
            rectangle.Stroke = new SolidColorBrush(Colors.Black);
            rectangle.StrokeThickness = PEN_WIDTH;
            rectangle.StrokeDashArray = new DoubleCollection { DASH_GAP, DASH_LENGTH };
            Windows.UI.Xaml.Shapes.Ellipse ellipse1 = new Windows.UI.Xaml.Shapes.Ellipse();
            ellipse1.Margin = new Thickness(x1 - POINT_OFFSET, y1 - POINT_OFFSET, 0, 0);
            ellipse1.Width = CIRCLE_RADIUS;
            ellipse1.Height = CIRCLE_RADIUS;
            ellipse1.Stroke = new SolidColorBrush(Colors.Black);
            ellipse1.Fill = new SolidColorBrush(Colors.White);
            Windows.UI.Xaml.Shapes.Ellipse ellipse2 = new Windows.UI.Xaml.Shapes.Ellipse();
            ellipse2.Margin = new Thickness(x2 - POINT_OFFSET, y1 - POINT_OFFSET, 0, 0);
            ellipse2.Width = CIRCLE_RADIUS;
            ellipse2.Height = CIRCLE_RADIUS;
            ellipse2.Stroke = new SolidColorBrush(Colors.Black);
            ellipse2.Fill = new SolidColorBrush(Colors.White);
            Windows.UI.Xaml.Shapes.Ellipse ellipse3 = new Windows.UI.Xaml.Shapes.Ellipse();
            ellipse3.Margin = new Thickness(x1 - POINT_OFFSET, y2 - POINT_OFFSET, 0, 0);
            ellipse3.Width = CIRCLE_RADIUS;
            ellipse3.Height = CIRCLE_RADIUS;
            ellipse3.Stroke = new SolidColorBrush(Colors.Black);
            ellipse3.Fill = new SolidColorBrush(Colors.White);
            Windows.UI.Xaml.Shapes.Ellipse ellipse4 = new Windows.UI.Xaml.Shapes.Ellipse();
            ellipse4.Margin = new Thickness(x2 - POINT_OFFSET, y2 - POINT_OFFSET, 0, 0);
            ellipse4.Width = CIRCLE_RADIUS;
            ellipse4.Height = CIRCLE_RADIUS;
            ellipse4.Stroke = new SolidColorBrush(Colors.Black);
            ellipse4.Fill = new SolidColorBrush(Colors.White);
            _canvas.Children.Add(rectangle);
            _canvas.Children.Add(ellipse1);
            _canvas.Children.Add(ellipse2);
            _canvas.Children.Add(ellipse3);
            _canvas.Children.Add(ellipse4);
        }
    }
}
