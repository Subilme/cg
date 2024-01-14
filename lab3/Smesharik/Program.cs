using System;

namespace Smesharik
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (MainWindow window = new MainWindow(800, 600, "Smeshariki"))
            {
                window.Run();
            }
        }
    }
}
