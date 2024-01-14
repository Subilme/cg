using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace Graph
{
    public class BezierCurve
    {
        private readonly List<Vector2> _points;
        
        public BezierCurve()
        {
            _points = new List<Vector2>
            {
                new Vector2(-0.8f, -0.5f), // P1
                new Vector2(-0.6f, 0.5f), // P2
                new Vector2(0.8f, 0.3f), // P3
                new Vector2(0.6f, -0.5f) // P4
            };
        }

        public void Draw()
        {
            DrawControlPoints();

            GL.Begin(PrimitiveType.LineStrip);
            GL.Color3(1.0, 0.0, 0.0);
            for (float t = 0.0f; t <= 1.0f; t += 0.01f)
            {
                Vector2 point = CalculatePoint(t);
                GL.Vertex2(point.X, point.Y);
            }
            GL.End();
        }

        private void DrawControlPoints()
        {
            // Контрольные точки
            GL.PointSize(10);
            GL.Begin(PrimitiveType.Points);
            GL.Color3(0.0, 0.0, 1.0);
            for (int i = 0; i < _points.Count; i++)
            {
                GL.Vertex2(_points[i]);
            }
            GL.End();

            // Линии между контрольными точками
            GL.Enable(EnableCap.LineStipple);
            GL.LineStipple(2, 0x00FF);
            GL.Begin(PrimitiveType.Lines);
            for (int i = 0; i < _points.Count - 1; i++)
            {
                GL.Vertex2(_points[i]);
                GL.Vertex2(_points[i + 1]);
            }
            GL.End();
            GL.Disable(EnableCap.LineStipple);
        }

        private Vector2 CalculatePoint(float t)
        {
            // B(t) = P1 * ( 1 — t )^3 + P2 * 3 * t * ( 1 — t )^2 + P3 * 3 * t^2 * ( 1 — t ) + P4 * t^3
            float cubicCoef = (float)Math.Pow(1 - t, 3);
            float sqrCoef = (float)Math.Pow(1 - t, 2);
            float coef = 1 - t;

            float x = _points[0].X * cubicCoef + _points[1].X * 3 * t * sqrCoef 
                + _points[2].X * 3 * t * t * coef + _points[3].X * t * t * t;
            float y = _points[0].Y * cubicCoef + _points[1].Y * 3 * t * sqrCoef 
                + _points[2].Y * 3 * t * t * coef + _points[3].Y * t * t * t;

            return new Vector2(x, y);
        }
    }
}
