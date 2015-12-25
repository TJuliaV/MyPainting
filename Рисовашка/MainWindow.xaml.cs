using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Рисовашка
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDrawn;
        private bool isDrawnNow;
        private Point Start;
        private Point End;
        private string Figure;
        private string Line;

        public MainWindow()
        {
            InitializeComponent();
            isDrawn = true;
            Figure = "Прямоугольник";
            Line = "Сплошная";
            RectRadioButton.IsChecked = true;
            SolidLineRadioButton.IsChecked = true;
        }

        private void BtnClear_OnClick(object sender, RoutedEventArgs e)
        {
            MyCanvas.Children.Clear();
        }

        private void MyCanvas_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            isDrawnNow = true;
            Start = new Point(e.GetPosition(this).X, e.GetPosition(this).Y);
        }

        private void MyCanvas_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            End = new Point(e.GetPosition(this).X, e.GetPosition(this).Y);

            if (isDrawn & isDrawnNow)
            {
                if (Figure == "Прямоугольник")
                {
                    if (Line == "Сплошная")
                    {
                        MySolidRectangle temp = new MySolidRectangle();
                        temp.Create(MyCanvas, Start, End);
                        return;
                    }
                    if (Line == "Пунктирная")
                    {
                        MyDottedRectangle temp = new MyDottedRectangle();
                        temp.Create(MyCanvas, Start, End);
                        return;
                    }
                }
                if (Figure == "Линия")
                {
                    if (Line == "Сплошная")
                    {
                        MySolidLine temp = new MySolidLine();
                        temp.Create(MyCanvas, Start, End);
                        return;
                    }
                    if (Line == "Пунктирная")
                    {
                        MyDottedLine temp = new MyDottedLine();
                        temp.Create(MyCanvas, Start, End);
                        return;
                    }
                }
            }
            isDrawnNow = false;
            MessageBox.Show("Выберите фигуру");



        }

        private void MyCanvas_OnMouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void BtnBrush_OnClick(object sender, RoutedEventArgs e)
        {
            isDrawn = true;
        }

        private void BtnHand_OnClick(object sender, RoutedEventArgs e)
        {
            isDrawn = false;
        }

        private void RectRadioButton_OnClick(object sender, RoutedEventArgs e)
        {
            Figure = "Прямоугольник";
        }

        private void LineRadioButton_OnClick(object sender, RoutedEventArgs e)
        {
            Figure = "Линия";
        }

        private void SolidLineRadioButton_OnClick(object sender, RoutedEventArgs e)
        {
            Line = "Сплошная";
        }

        private void DottedLineRadioButton_OnClick(object sender, RoutedEventArgs e)
        {
            Line ="Пунктирная";
        }
    }
}
