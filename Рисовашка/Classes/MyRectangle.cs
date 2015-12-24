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
    public abstract class MyRectangle
    {

        public abstract void Create(Canvas canvas, Point Start, Point Now);
    }

    public class DottedRectangle : MyRectangle
    {
        public override void Create(Canvas canvas, Point Start, Point Now)
        {
            Rectangle rect = new Rectangle();
            rect.Stroke = Brushes.Blue;
            rect.Width = Start.X - Now.X;
            rect.Height = Start.Y - Now.Y;

            Canvas.SetLeft(rect, Start.X);
            Canvas.SetTop(rect, Start.Y);
        }
    }

    public class SolidRectangle : MyRectangle
    {
        public override void Create(Canvas canvas, Point Start, Point Now)
        {
            if (Now.X < Start.X)
            {
                double temp = Start.X;
                Start.X = Now.X;
                Now.X = temp;
            }
            if (Now.Y < Start.Y)
            {
                double temp = Start.Y;
                Start.Y = Now.Y;
                Now.Y = temp;
            }

            Rectangle rect = new Rectangle();
            rect.Stroke = Brushes.BlueViolet;

            rect.Width = (int)(Now.X - Start.X);
            rect.Height = (int)(Now.Y - Start.Y);
            rect.SetValue(Canvas.LeftProperty, (rect.Width / 2));
            rect.SetValue(Canvas.TopProperty, Start.Y);

            canvas.Children.Add(rect);
        }
    }
        
}
