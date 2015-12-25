using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Рисовашка
{
    public abstract class MyLine
    {
        public abstract void Create(Canvas canvas, Point Start, Point End);
    }

    public class MyDottedLine : MyLine
    {
        public override void Create(Canvas canvas, Point Start, Point End)
        {
            Line line = new Line();
            line.Stroke = Brushes.Black;
            line.StrokeThickness = 5;
            line.StrokeDashArray = new DoubleCollection(){2,2};
            line.X1 = Start.X;
            line.Y1 = Start.Y;
            line.X2 = End.X;
            line.Y2 = End.Y;
            canvas.Children.Add(line);
        }
    }

    public class MySolidLine : MyLine
    {
        public override void Create(Canvas canvas, Point Start, Point End)
        {
            Line line = new Line();
            line.Stroke = Brushes.Black;
            line.StrokeThickness = 5;
            line.X1 = Start.X;
            line.Y1 = Start.Y;
            line.X2 = End.X;
            line.Y2 = End.Y;
            canvas.Children.Add(line);
        }
    }
}
