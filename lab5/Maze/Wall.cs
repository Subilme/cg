using OpenTK.Graphics;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Maze
{
    internal class Wall
    {
        private Texture _texture;

        private float x1, y1, z1, x2, y2, z2;

        // TODO: Переделать на Point
        public Wall(float x1, float z1, float x2, float z2, float y1, float y2, Texture texture)
        {
            this.x1 = x1;
            this.z1 = z1;
            this.x2 = x2;
            this.z2 = z2;
            this.y1 = y1;
            this.y2 = y2;
            _texture = texture;
        }

        public void Draw()
        {
            GL.PushMatrix();

            GL.Color4(Color4.White);
            _texture.Bind();

            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 0.0f);
            GL.Vertex3(x2, y1, z1);
            GL.TexCoord2(1.0f, 0.0f);
            GL.Vertex3(x2, y1, z2);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(x1, y1, z2);
            GL.TexCoord2(0.0f, 1.0f);
            GL.Vertex3(x1, y1, z1);
            GL.End();

            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 1.0f);
            GL.Vertex3(x1, y1, z2);
            GL.TexCoord2(0.0f, 0.0f);
            GL.Vertex3(x1, y2, z2);
            GL.TexCoord2(1.0f, 0.0f);
            GL.Vertex3(x1, y2, z1);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(x1, y1, z1);
            GL.End();

            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(x2, y1, z2);
            GL.TexCoord2(1.0f, 0.0f);
            GL.Vertex3(x2, y2, z2);
            GL.TexCoord2(0.0f, 0.0f);
            GL.Vertex3(x1, y2, z2);
            GL.TexCoord2(0.0f, 1.0f);
            GL.Vertex3(x1, y1, z2);
            GL.End();

            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 1.0f);
            GL.Vertex3(x2, y1, z1);
            GL.TexCoord2(0.0f, 0.0f);
            GL.Vertex3(x2, y2, z1);
            GL.TexCoord2(1.0f, 0.0f);
            GL.Vertex3(x2, y2, z2);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(x2, y1, z2);
            GL.End();

            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 1.0f);
            GL.Vertex3(x1, y1, z1);
            GL.TexCoord2(0.0f, 0.0f);
            GL.Vertex3(x1, y2, z1);
            GL.TexCoord2(1.0f, 0.0f);
            GL.Vertex3(x2, y2, z1);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(x2, y1, z1);
            GL.End();

            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 0.0f);
            GL.Vertex3(x1, y2, z1);
            GL.TexCoord2(0.0f, 1.0f);
            GL.Vertex3(x1, y2, z2);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(x2, y2, z2);
            GL.TexCoord2(1.0f, 0.0f);
            GL.Vertex3(x2, y2, z1);
            GL.End();

            _texture.Unbind();
            GL.PopMatrix();
        }

        public bool CheckCollision(Vector3 obj, float objWidth, float objHeight)
        {
            return obj.X >= x1 - objWidth && obj.Y > y1 - 0.05f && obj.Z <= z2 + objWidth &&
                 obj.X <= x2 + objWidth && obj.Y < y2 + objHeight && obj.Z >= z1 - objWidth;
        }
    }
}
