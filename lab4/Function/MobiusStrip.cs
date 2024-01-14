using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace Function
{
    public class MobiusStrip
    {
        private const int steps = 700;
        private readonly List<List<float>> _gradient;

        public MobiusStrip()
        {
            List<float> startColor = new List<float> { 0.0f, 0.0f, 1.0f };
            List<float> endColor = new List<float> { 1.0f, 0.0f, 0.0f };

            _gradient = new List<List<float>> { startColor };

            for (int i = 0; i < steps; i++)
            {
                _gradient.Add(new List<float>
                {
                    startColor[0] + i * ((endColor[0] - startColor[0]) / steps),
                    startColor[1] + i * ((endColor[1] - startColor[1]) / steps),
                    startColor[2] + i * ((endColor[2] - startColor[2]) / steps),
                });
            }
        }

        public void Draw()
        {
            GL.Begin(PrimitiveType.QuadStrip);

            for (int i = 0; i < steps; i++)
            {
                GL.Color3(_gradient[i].ToArray());

                for (int j = 0; j <= 360; j += 5)
                {
                    double u = (float)j / 180 * Math.PI;
                    double v = (float)i / steps - 0.5;
                    double x = (1 + v / 2 * Math.Cos(u / 2)) * Math.Cos(u);
                    double y = (1 + v / 2 * Math.Cos(u / 2)) * Math.Sin(u);
                    double z = v / 2 * Math.Sin(u / 2);
                    GL.Vertex3(x, y, z);
                }
            }

            GL.End();
        }
    }
}
