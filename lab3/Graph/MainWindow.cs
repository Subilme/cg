using OpenTK.Graphics;
using OpenTK;
using System;
using OpenTK.Graphics.OpenGL;

namespace Graph
{
    public class MainWindow : GameWindow
    {
        private readonly BezierCurve _bezierCurve;

        public MainWindow(int width, int height, string title)
            : base(width, height, GraphicsMode.Default, title)
        {
            _bezierCurve = new BezierCurve();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color4.White);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);
            Draw();
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            Draw();
        }

        private void Draw()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            SetupProjectionMatrix(Width, Height);
            DrawAxes();
            _bezierCurve.Draw();

            SwapBuffers();
        }

        private static void DrawAxes()
        {
            Axes.DrawXAxis();
            Axes.DrawYAxis();
        }

        private void SetupProjectionMatrix(int width, int height)
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            double aspectRatio = (double)width / height;

            if (aspectRatio > 1.0)
            {
                GL.Ortho(-1.0 * aspectRatio, 1.0 * aspectRatio, -1.0, 1.0, -1.0, 1.0);
            }
            else
            {
                GL.Ortho(-1.0, 1.0, -1.0 / aspectRatio, 1.0 / aspectRatio, -1.0, 1.0);
            }

            GL.MatrixMode(MatrixMode.Modelview);
        }
    }
}
