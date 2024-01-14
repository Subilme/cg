using OpenTK.Graphics.OpenGL;

namespace Graph
{
    public static class Axes
    {
        public static void DrawXAxis()
        {
            GL.Color3(0, 0, 0);

            GL.Begin(PrimitiveType.Lines);

            // X axis
            GL.Vertex2(-1, 0);
            GL.Vertex2(1, 0);

            // Axis marks
            for (double i = 0; i < 1; i += 0.1)
            {
                GL.Vertex2(i, 0.02);
                GL.Vertex2(i, -0.02);

                GL.Vertex2(-i, 0.02);
                GL.Vertex2(-i, -0.02);
            }

            GL.End();

            // Axis arrow
            GL.Begin(PrimitiveType.Triangles);

            GL.Vertex2(0.98, 0.02);
            GL.Vertex2(0.98, -0.02);
            GL.Vertex2(1, 0);

            GL.End();
        }

        public static void DrawYAxis()
        {
            GL.Color3(0, 0, 0);

            GL.Begin(PrimitiveType.Lines);

            // Y axis
            GL.Vertex2(0, -1);
            GL.Vertex2(0, 1);

            // Axis marks
            for (double i = 0; i < 1; i += 0.1)
            {
                GL.Vertex2(0.02, i);
                GL.Vertex2(-0.02, i);

                GL.Vertex2(0.02, -i);
                GL.Vertex2(-0.02, -i);
            }

            GL.End();

            // Axis arrows
            GL.Begin(PrimitiveType.Triangles);

            GL.Vertex2(0.02, 0.98);
            GL.Vertex2(-0.02, 0.98);
            GL.Vertex2(0, 1);

            GL.End();
        }
    }
}
