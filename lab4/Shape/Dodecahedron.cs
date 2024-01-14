using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace Shape
{
    public class Dodecahedron
    {
        // TODO: В структуру
        private readonly List<List<float>> _vertices;
        private readonly List<List<int>> _points;
        private readonly List<List<float>> _colors;

        public Dodecahedron()
        {
            float phi = (float)((1 + Math.Sqrt(5)) / 2);

            _vertices = new List<List<float>>
            {
                new List<float>{ 1.0f, 1.0f, 1.0f },
                new List<float>{ -1.0f, 1.0f, 1.0f },
                new List<float>{ 1.0f, -1.0f, 1.0f },
                new List<float>{ -1.0f, -1.0f, 1.0f },
                new List<float>{ 1.0f, 1.0f, -1.0f },
                new List<float>{ -1.0f, 1.0f, -1.0f },
                new List<float>{ 1.0f, -1.0f, -1.0f },
                new List<float>{ -1.0f, -1.0f, -1.0f },
                new List<float>{ 0.0f, 1 / phi, phi },
                new List<float>{ 0.0f, -1 / phi, phi },
                new List<float>{ 0.0f, 1 / phi, -phi },
                new List<float>{ 0.0f, -1 / phi, -phi },
                new List<float>{ 1 / phi, phi, 0.0f },
                new List<float>{ -1 / phi, phi, 0.0f },
                new List<float>{ 1 / phi, -phi, 0.0f },
                new List<float>{ -1 / phi, -phi, 0.0f },
                new List<float>{ phi, 0.0f, 1 / phi },
                new List<float>{ -phi, 0.0f, 1 / phi },
                new List<float>{ phi, 0.0f, -1 / phi },
                new List<float>{ -phi, 0.0f, -1 / phi },
            };

            _points = new List<List<int>>
            {
                new List<int>{ 4, 12, 0, 16, 18 },
                new List<int>{ 2, 9, 8, 0, 16 },
                new List<int>{ 3, 9, 2, 14, 15 },
                new List<int>{ 1, 8, 9, 3, 17 },
                new List<int>{ 1, 8, 0, 12, 13 },
                new List<int>{ 5, 10, 11, 7, 19 },
                new List<int>{ 6, 11,  10, 4, 18 },
                new List<int>{ 6, 14,  15, 7, 11 },
                new List<int>{ 12, 13, 5, 10, 4 },
                new List<int>{ 14, 2, 16, 18, 6 },
                new List<int>{ 5, 19, 17, 1,  13 },
                new List<int>{ 19, 7, 15, 3, 17 },
            };

            _colors = new List<List<float>>
            {
                new List<float> { 1.0f, 0.42f, 0.43f },
                new List<float> { 0.0f, 0.11f, 0.23f },
                new List<float> { 0.65f, 0.15f, 0.93f },
                new List<float> { 0.12f, 0.53f, 0.21f },
                new List<float> { 0.35f, 0.11f, 0.43f },
                new List<float> { 0.18f, 0.11f, 0.75f },
                new List<float> { 0.26f, 0.15f, 0.45f },
                new List<float> { 0.86f, 0.37f, 0.34f },
                new List<float> { 0.14f, 0.23f, 0.36f },
                new List<float> { 0.83f, 0.97f, 0.69f },
                new List<float> { 0.73f, 0.85f, 0.21f },
                new List<float> { 0.52f, 0.68f, 0.95f }
            };
        }

        public void Draw()
        {
            for (int i = 0; i < _points.Count; i++)
            {
                GL.Begin(PrimitiveType.Polygon);
                GL.Color3(_colors[i].ToArray());
                
                foreach (var item in _points[i])
                {
                    GL.Vertex3(_vertices[item].ToArray());
                }

                GL.End();

                GL.Begin(PrimitiveType.LineLoop);
                GL.Color3(0, 0, 0);

                foreach (var item in _points[i])
                {
                    GL.Vertex3(_vertices[item].ToArray());
                }

                GL.End();
            }
        }
    }
}
