namespace Maze
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var window = new Window(1280, 720, "Maze"))
            {
                window.Run();
            }
        }
    }
}
