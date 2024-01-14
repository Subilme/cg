using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;

namespace Function
{
    public class MainWindow : GameWindow
    {
        private readonly MobiusStrip _mobiusStrip;

        public MainWindow(int width, int height, string title)
            : base(width, height, GraphicsMode.Default, title)
        {
            GL.Enable(EnableCap.DepthTest);

            GL.Rotate(110, 1, 0, 0);

            _mobiusStrip = new MobiusStrip();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);
            Draw();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            Draw();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState input = Keyboard.GetState();

            if (input.IsKeyDown(Key.Escape))
            {
                Exit();
            }
        }

        private void Draw()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.Rotate(0.5, 0, 0, 1);

            SetupProjectionMatrix(Width, Height);
            _mobiusStrip.Draw();

            SwapBuffers();
        }

        private void SetupProjectionMatrix(int width, int height)
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            double aspectRatio = (double)width / height;

            if (aspectRatio > 1.0)
            {
                GL.Ortho(-2.0 * aspectRatio, 2.0 * aspectRatio, -2.0, 2.0, -2.0, 2.0);
            }
            else
            {
                GL.Ortho(-2.0, 2.0, -2.0 / aspectRatio, 2.0 / aspectRatio, -2.0, 2.0);
            }

            GL.MatrixMode(MatrixMode.Modelview);
        }
    }
}
