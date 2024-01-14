using OpenTK.Windowing.Desktop;

namespace Ripples
{
    public class Program
    {
        static void Main(string[] args)
        {
            var nws = new NativeWindowSettings()
            {
                Size = (1280, 720),
                Title = "Ripples",
            };

            using (var window = new Window(nws))
            {
                window.Run();
            }
        }
    }
}