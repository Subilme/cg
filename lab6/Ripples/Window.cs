using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace Ripples
{
    [SuppressMessage("Interoperability", "CA1416:Проверка совместимости платформы")]
    public class Window : GameWindow
    {
        private const float ANIMATION_DURATION = 15.0f;

        private readonly Vector2 _resolution = new Vector2(1366, 768);
        private readonly Stopwatch _timer = new Stopwatch();

        private readonly float[] _vertices =
        {
            1.0f, 1.0f, 1.0f, 0.0f,
            1.0f, -1.0f, 1.0f, 1.0f,
            -1.0f, -1.0f, 0.0f, 1.0f,
            -1.0f, 1.0f, 0.0f, 0.0f,
        };

        private readonly uint[] _indices =
        {
            0, 1, 3,
            1, 2, 3
        };

        private int _vertexBufferObject;
        private int _vertexArrayObject;
        private int _elementBufferObject;

        private Shader _shader;
        private Texture _texture1;
        private Texture _texture2;

        private int _projectionLocation;

        public Window(NativeWindowSettings nws)
            : base(GameWindowSettings.Default, nws)
        {
            _shader = new Shader(@"../../../shader.vert", @"../../../shader.frag");

            #region Textures

            _texture1 = new Texture(@"../../../image1.jpg");
            _texture2 = new Texture(@"../../../image2.jpg");

            float imageAspectRatio = _resolution.X / _resolution.Y;

            if (imageAspectRatio > 1.0)
            {
                _vertices[1] /= imageAspectRatio;
                _vertices[5] /= imageAspectRatio;
                _vertices[9] /= imageAspectRatio;
                _vertices[13] /= imageAspectRatio;
            }
            else
            {
                _vertices[0] *= imageAspectRatio;
                _vertices[4] *= imageAspectRatio;
                _vertices[8] *= imageAspectRatio;
                _vertices[12] *= imageAspectRatio;
            }

            _shader.Use();

            _texture1.Use(TextureUnit.Texture0);
            _texture2.Use(TextureUnit.Texture1);

            _shader.SetUniform1("texture0", 0);
            _shader.SetUniform1("texture1", 1);

            _shader.Off();

            #endregion

            #region Vertex Objects

            _vertexBufferObject = GL.GenBuffer();
            _vertexArrayObject = GL.GenVertexArray();

            GL.BindVertexArray(_vertexArrayObject);

            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float),
                _vertices, BufferUsageHint.StaticDraw);

            var vertexLocation = _shader.GetAttribLocation("aPosition");
            GL.VertexAttribPointer(vertexLocation, 2, VertexAttribPointerType.Float,
                false, 4 * sizeof(float), 0);

            var texCoordLocation = _shader.GetAttribLocation("aTexCoord");
            GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float,
                false, 4 * sizeof(float), 2 * sizeof(float));

            #endregion

            #region Element Buffer Object

            _elementBufferObject = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length * sizeof(uint),
                _indices, BufferUsageHint.StaticDraw);

            #endregion
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(Color.White);

            _shader.Use();

            _projectionLocation = _shader.GetUniformLocation("projection");
            _shader.SetUniform2("resolution", _resolution);

            _shader.Off();

            _timer.Start();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            KeyboardState input = KeyboardState;
            if (input.IsKeyDown(Keys.Escape))
            {
                Close();
            }

            float elapsedSeconds = (float)_timer.ElapsedMilliseconds / 1000;

            _shader.Use();
            _shader.SetUniform1("time", elapsedSeconds);
            _shader.Off();

            if (elapsedSeconds >= ANIMATION_DURATION)
            {
                _timer.Reset();

                TextureUnit unit1 = _texture1.Unit;
                TextureUnit unit2 = _texture2.Unit;
                _texture1.Use(unit2);
                _texture2.Use(unit1);

                _timer.Start();
            }
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            Draw();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, e.Width, e.Height);
            Draw();
        }

        private void Draw()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            SetupLandscapeProjectionMatrix(Size.X, Size.Y, _projectionLocation, 16.0f / 9.0f);

            _shader.Use();

            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);

            GL.BindVertexArray(_vertexArrayObject);
            GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);

            GL.DisableVertexAttribArray(1);
            GL.DisableVertexAttribArray(0);

            _shader.Off();

            SwapBuffers();
        }

        public void SetupLandscapeProjectionMatrix(float width, float height,
            int projectionLocation, float landscapeRatio)
        {
            _shader.Use();

            float aspectRatio = width / height;
            float w = 2.0f;
            float h = 2.0f;

            if (aspectRatio > landscapeRatio)
            {
                w *= (aspectRatio / landscapeRatio);
                h /= landscapeRatio;
            }
            else
            {
                h /= aspectRatio;
            }

            Matrix4 ortho = Matrix4.CreateOrthographic(w, h, -1.0f, 1.0f);
            GL.UniformMatrix4(projectionLocation, true, ref ortho);

            _shader.Off();
        }
    }
}
