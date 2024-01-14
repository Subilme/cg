using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CreateLastName();
            CreateFirstName();
            CreateSurname();

            //Jump(LastName);
            //Jump(FirstName);
            //Jump(Surname);
        }

        private void CreateLastName()
        {
            LastName.Children.Add(new Polygon
            {
                Stroke = Brushes.DarkGreen,
                Fill = Brushes.DarkGreen,
                Points = new PointCollection
                {
                    new Point(50, 300),
                    new Point(120, 100),
                    new Point(135, 100),
                    new Point(210, 300),
                    new Point(195, 300),
                    new Point(127.5, 120),
                    new Point(65, 300)
                }
            });
        }

        private void CreateFirstName()
        {
            FirstName.Children.Add(new Polygon
            {
                Stroke = Brushes.Purple,
                Fill = Brushes.Purple,
                Points = new PointCollection
                {
                    new Point(230, 300),
                    new Point(230, 100),
                    new Point(245, 100),
                    new Point(312.5, 205),
                    new Point(380, 100),
                    new Point(395, 100),
                    new Point(395, 300),
                    new Point(380, 300),
                    new Point(380, 120),
                    new Point(320, 220),
                    new Point(305, 220),
                    new Point(245, 120),
                    new Point(245, 300)
                }
            });
        }

        private void CreateSurname()
        {
            Surname.Children.Add(new Polygon
            {
                Stroke = Brushes.Blue,
                Fill = Brushes.Blue,
                Points = new PointCollection
                {
                    new Point(415, 100),
                    new Point(430, 100),
                    new Point(430, 200),
                    new Point(470, 200),
                    new Point(470, 215),
                    new Point(430, 215),
                    new Point(430, 300),
                    new Point(415, 300)
                }
            });
            Surname.Children.Add(new Ellipse
            {
                Stroke = Brushes.Blue,
                StrokeThickness = 15,
                Width = 100,
                Height = 210,
                Margin = new Thickness(250, 0, 0, 5)
            });
        }

        private void Jump(Grid grid)
        {
            TranslateTransform trans = new TranslateTransform();
            grid.RenderTransform = trans;
            DoubleAnimation animUp = new DoubleAnimation(-50, TimeSpan.FromSeconds(1));
            animUp.AutoReverse = true;
            animUp.RepeatBehavior = RepeatBehavior.Forever;
            trans.BeginAnimation(TranslateTransform.YProperty, animUp);
        }
    }
}
