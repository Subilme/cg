using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK;
using System;
using OpenTK.Graphics.OpenGL;

namespace Maze
{
    internal class Window : GameWindow
    {
        // TODO: Скорость движения не должна не зависеть от FPS
        private const float CameraSpeed = 0.02f;
        private const float Sensitivity = 0.15f;

        private const float CameraWidth = 0.02f;
        private const float CameraHeight = 0.5f;

        private readonly Maze _maze;

        private Camera _camera;

        public float AspectRatio => (float)Width / Height;

        public Window(int width, int height, string title)
            : base(width, height, GraphicsMode.Default, title)
        {
            _maze = new Maze();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);
            GL.FrontFace(FrontFaceDirection.Ccw);
            GL.Enable(EnableCap.DepthTest);

            GL.Enable(EnableCap.Fog);

            _camera = new Camera(new Vector3(-7.5f, 0.5f, 1.0f), Width / Height);
            MouseMove += Window_MouseMove;
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            
            if (!Focused)
            {
                return;
            }

            HandleKeyboardInput();

            Draw();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            _camera.AspectRatio = AspectRatio;
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            Matrix4 projection = _camera.GetProjectionMatrix();
            GL.LoadMatrix(ref projection);
            GL.MatrixMode(MatrixMode.Modelview);
            
            Draw();
        }

        protected virtual void Draw()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 view = _camera.GetViewMatrix();
            GL.LoadMatrix(ref view);

            _maze.Draw();

            SwapBuffers();
        }

        private void Window_MouseMove(object sender, MouseMoveEventArgs e)
        {
            if (e.Mouse.LeftButton == ButtonState.Pressed)
            {
                _camera.Yaw += e.XDelta * Sensitivity;
                _camera.Pitch -= e.YDelta * Sensitivity;
            }
        }

        private void HandleKeyboardInput()
        {
            KeyboardState input = Keyboard.GetState();

            if (input.IsKeyDown(Key.Escape))
            {
                Close();
            }

            if (input.IsKeyDown(Key.W))
            {
                Vector3 newPosition = new Vector3(
                    _camera.Position.X + _camera.Front.X * CameraSpeed,
                    _camera.Position.Y,
                    _camera.Position.Z + _camera.Front.Z * CameraSpeed);
                TryToMoveCamera(newPosition);
            }

            if (input.IsKeyDown(Key.S))
            {
                Vector3 newPosition = new Vector3(
                    _camera.Position.X - _camera.Front.X * CameraSpeed,
                    _camera.Position.Y,
                    _camera.Position.Z - _camera.Front.Z * CameraSpeed);
                TryToMoveCamera(newPosition);
            }

            if (input.IsKeyDown(Key.A))
            {
                TryToMoveCamera(_camera.Position - _camera.Right * CameraSpeed);
            }

            if (input.IsKeyDown(Key.D))
            {
                TryToMoveCamera(_camera.Position + _camera.Right * CameraSpeed);
            }
        }

        private void TryToMoveCamera(Vector3 point)
        {
            if (!_maze.CheckCollision(point, CameraWidth, CameraHeight))
            {
                _camera.Position = point;
            }
        }
    }
}
