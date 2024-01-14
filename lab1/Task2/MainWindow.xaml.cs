using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MakeRoof();
            MakePipe();
            MakeHouse();
            MakeWindow();
            MakeDoor();
            MakeFence();
        }

        private void MakeRoof()
        {
            MainGrid.Children.Add(new Polygon
            {
                Fill = Brushes.DarkGray,
                Points = new PointCollection
                {
                    new Point(100, 200),
                    new Point(200, 100),
                    new Point(300, 200)
                }
            });
        }

        private void MakePipe()
        {
            MainGrid.Children.Add(new Polygon
            {
                Fill = Brushes.Gray,
                Points = new PointCollection
                {
                    new Point(130, 100),
                    new Point(130, 180),
                    new Point(160, 180),
                    new Point(160, 100)
                }
            });
        }

        private void MakeHouse()
        {
            MainGrid.Children.Add(new Polygon
            {
                Fill = Brushes.Gray,
                Points = new PointCollection
                {
                    new Point(100, 200),
                    new Point(100, 380),
                    new Point(300, 380),
                    new Point(300, 200)
                }
            });
        }

        private void MakeWindow()
        {
            MainGrid.Children.Add(new Polygon
            {
                Stroke = Brushes.SaddleBrown,
                StrokeThickness = 3,
                Fill = Brushes.White,
                Points = new PointCollection
                {
                    new Point(225, 265),
                    new Point(225, 320),
                    new Point(275, 320),
                    new Point(275, 265)
                }
            });
            MainGrid.Children.Add(new Line
            {
                Stroke = Brushes.SaddleBrown,
                StrokeThickness = 3,
                X1 = 250, Y1 = 265,
                X2 = 250, Y2 = 320
            });
        }

        private void MakeDoor()
        {
            MainGrid.Children.Add(new Polygon
            {
                Fill = Brushes.SandyBrown,
                Points = new PointCollection
                {
                    new Point(125, 230),
                    new Point(125, 380),
                    new Point(200, 380),
                    new Point(200, 230)
                }
            });
            MainGrid.Children.Add(new Polygon
            {
                Fill = Brushes.Black,
                Points = new PointCollection
                {
                    new Point(130, 310),
                    new Point(135, 310),
                    new Point(135, 315),
                    new Point(130, 315)
                }
            });
        }

        private void MakeFence()
        {
            MainGrid.Children.Add(new Polyline
            {
                Stroke = Brushes.Black,
                Fill = Brushes.SaddleBrown,
                Points = new PointCollection
                {
                    new Point(300, 380),
                    new Point(300, 250),
                    new Point(315, 230),
                    new Point(330, 250),
                    new Point(330, 380)
                }
            });
            MainGrid.Children.Add(new Polyline
            {
                Stroke = Brushes.Black,
                Fill = Brushes.SaddleBrown,
                Points = new PointCollection
                {
                    new Point(330, 380),
                    new Point(330, 250),
                    new Point(345, 230),
                    new Point(360, 250),
                    new Point(360, 380)
                }
            });
            MainGrid.Children.Add(new Polyline
            {
                Stroke = Brushes.Black,
                Fill = Brushes.SaddleBrown,
                Points = new PointCollection
                {
                    new Point(360, 380),
                    new Point(360, 250),
                    new Point(375, 230),
                    new Point(390, 250),
                    new Point(390, 380)
                }
            });
        }
    }
}
