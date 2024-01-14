namespace Function
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (MainWindow window = new MainWindow(800, 600, "Mebius strip"))
            {
                window.Run();
            }
        }
    }
}
