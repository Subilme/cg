using OpenTK.Graphics;
using OpenTK;
using System;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Collections.Generic;

namespace Shape
{
    public class MainWindow : GameWindow
    {
        private readonly Dodecahedron _dodecahedron;

        public MainWindow(int width, int height, string title)
            : base(width, height, GraphicsMode.Default, title)
        {
            GL.Enable(EnableCap.DepthTest);

            _dodecahedron = new Dodecahedron();
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

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            Draw();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState input = new KeyboardState();

            if (input.IsKeyDown(Key.Escape))
            {
                Close();
            }
        }

        private void Draw()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.Rotate(0.5, 0, 1, 0);

            SetupProjectionMatrix(Width, Height);
            _dodecahedron.Draw();

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
