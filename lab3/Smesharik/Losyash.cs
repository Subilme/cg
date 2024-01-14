using OpenTK.Graphics.OpenGL;
using System;

namespace Smesharik
{
    public class Losyash
    {
        public void Draw()
        {
            DrawBody();
            DrawLegs();
            DrawArms();
            DrawHorns();
            DrawNose();
            DrawEyebrows();
            DrawEars();
            DrawMouth();
            DrawEyes();
        }

        private static void DrawBody()
        {
            double radius = 0.85;

            GL.Color3(0.945, 0.636, 0);

            GL.Begin(PrimitiveType.TriangleFan);

            GL.Vertex2(0, 0);
            for (int i = 0; i <= 360; i++)
            {
                double angle = i * Math.PI / 180;
                GL.Vertex2(radius * Math.Cos(angle), radius * Math.Sin(angle));
            }

            GL.End();
        }

        private void DrawEyes()
        {
            #region left eyelids

            #region upper eyelids
            GL.Color3(0.51, 0.14, 0.12);

            GL.Begin(PrimitiveType.Polygon);
            
            GL.Vertex2(-0.02, 0.35);
            GL.Vertex2(-0.14, 0.36);
            GL.Vertex2(-0.28, 0.35);
            GL.Vertex2(-0.4, 0.3);
            GL.Vertex2(-0.48, 0.25);
            GL.Vertex2(-0.49, 0.35);
            GL.Vertex2(-0.44, 0.45);
            GL.Vertex2(-0.38, 0.52);
            GL.Vertex2(-0.28, 0.56);
            GL.Vertex2(-0.19, 0.57);
            GL.Vertex2(-0.09, 0.53);
            GL.Vertex2(-0.02, 0.43);

            GL.End();
            #endregion

            #region lower eyelid
            GL.Color3(1.0, 1.0, 1.0);

            GL.Begin(PrimitiveType.Polygon);
            
            GL.Vertex2(-0.03, 0.34);
            GL.Vertex2(-0.12, 0.35);
            GL.Vertex2(-0.26, 0.34);
            GL.Vertex2(-0.38, 0.3);
            GL.Vertex2(-0.47, 0.25);
            GL.Vertex2(-0.46, 0.18);
            GL.Vertex2(-0.4, 0.12);
            GL.Vertex2(-0.33, 0.09);
            GL.Vertex2(-0.19, 0.11);
            GL.Vertex2(-0.12, 0.16);
            GL.Vertex2(-0.07, 0.19);
            GL.Vertex2(-0.04, 0.28);

            GL.End();
            #endregion

            #endregion

            #region right eyelids

            #region upper eyelid
            GL.Color3(0.51, 0.14, 0.12);

            GL.Begin(PrimitiveType.Polygon);
            
            GL.Vertex2(0.0, 0.34);
            GL.Vertex2(0.1, 0.37);
            GL.Vertex2(0.29, 0.33);
            GL.Vertex2(0.43, 0.27);
            GL.Vertex2(0.48, 0.24);
            GL.Vertex2(0.46, 0.38);
            GL.Vertex2(0.42, 0.45);
            GL.Vertex2(0.33, 0.52);
            GL.Vertex2(0.24, 0.57);
            GL.Vertex2(0.15, 0.57);
            GL.Vertex2(0.07, 0.52);
            GL.Vertex2(0.02, 0.44);

            GL.End();
            #endregion

            #region lower eyelid
            GL.Color3(1.0, 1.0, 1.0);

            GL.Begin(PrimitiveType.Polygon);
            
            GL.Vertex2(0.0, 0.33);
            GL.Vertex2(0.07, 0.35);
            GL.Vertex2(0.2, 0.34);
            GL.Vertex2(0.3, 0.32);
            GL.Vertex2(0.41, 0.28);
            GL.Vertex2(0.46, 0.24);
            GL.Vertex2(0.44, 0.17);
            GL.Vertex2(0.39, 0.12);
            GL.Vertex2(0.32, 0.09);
            GL.Vertex2(0.2, 0.1);
            GL.Vertex2(0.09, 0.26);
            GL.Vertex2(0.02, 0.26);

            GL.End();
            #endregion

            #endregion

            #region pupils
            double radius = 0.06;
            double centerX = -0.13;
            double centerY = 0.29;

            GL.Color3(0.0, 0.0, 0.0);

            GL.Begin(PrimitiveType.TriangleFan);

            GL.Vertex2(centerX, centerY);
            for (int i = 0; i <= 360; i++)
            {
                double angle = i * Math.PI / 180;
                GL.Vertex2(centerX + radius * Math.Cos(angle), centerY + radius * Math.Sin(angle));
            }

            GL.End();

            centerX = 0.11;
            centerY = 0.29;
            GL.Begin(PrimitiveType.TriangleFan);

            GL.Vertex2(centerX, centerY);
            for (int i = 0; i <= 360; i++)
            {
                double angle = i * Math.PI / 180;
                GL.Vertex2(centerX + radius * Math.Cos(angle), centerY + radius * Math.Sin(angle));
            }

            GL.End();
            #endregion
        }

        private void DrawLegs()
        {
            GL.Color3(0.945, 0.636, 0);

            #region left leg
            GL.Begin(PrimitiveType.Polygon);

            GL.Vertex2(-0.25, -0.84);
            GL.Vertex2(-0.33, -0.87);
            GL.Vertex2(-0.39, -1.14);
            GL.Vertex2(-0.32, -1.18);
            GL.Vertex2(-0.2, -1.22);
            GL.Vertex2(-0.08, -1.27);
            GL.Vertex2(-0.05, -1.08);
            GL.Vertex2(-0.16, -0.86);

            GL.End();
            #endregion

            #region right leg
            GL.Begin(PrimitiveType.Polygon);

            GL.Vertex2(0.26, -0.83);
            GL.Vertex2(0.17, -0.86);
            GL.Vertex2(0.08, -1.03);
            GL.Vertex2(0.06, -1.18);
            GL.Vertex2(0.09, -1.27);
            GL.Vertex2(0.21, -1.21);
            GL.Vertex2(0.32, -1.27);
            GL.Vertex2(0.41, -1.11);
            GL.Vertex2(0.34, -0.86);

            GL.End();
            #endregion
        }

        private void DrawArms()
        {
            GL.Color3(0.945, 0.636, 0);

            #region left arm
            GL.Begin(PrimitiveType.Polygon);

            GL.Vertex2(0.82, 0.01);
            GL.Vertex2(0.87, 0.01);
            GL.Vertex2(0.95, -0.09);
            GL.Vertex2(1.02, -0.32);
            GL.Vertex2(1.01, -0.53);
            GL.Vertex2(0.97, -0.66);
            GL.Vertex2(0.92, -0.68);
            GL.Vertex2(0.87, -0.61);
            GL.Vertex2(0.8, -0.64);
            GL.Vertex2(0.74, -0.62);
            GL.Vertex2(0.77, -0.54);
            GL.Vertex2(0.81, -0.44);
            GL.Vertex2(0.82, -0.26);
            GL.Vertex2(0.78, -0.1);
            GL.Vertex2(0.78, -0.02);

            GL.End();
            #endregion

            #region right arm
            GL.Begin(PrimitiveType.Polygon);

            GL.Vertex2(-0.83, 0.0);
            GL.Vertex2(-0.89, 0.01);
            GL.Vertex2(-0.98, -0.12);
            GL.Vertex2(-1.04, -0.31);
            GL.Vertex2(-1.03, -0.54);
            GL.Vertex2(-0.96, -0.67);
            GL.Vertex2(-0.91, -0.68);
            GL.Vertex2(-0.87, -0.61);
            GL.Vertex2(-0.8, -0.65);
            GL.Vertex2(-0.77, -0.58);
            GL.Vertex2(-0.85, -0.38);
            GL.Vertex2(-0.8, -0.2);
            GL.Vertex2(-0.79, -0.04);

            GL.End();
            #endregion
        }

        // TODO: Правильно нарисовать
        private void DrawHorns()
        {
            GL.Color3(0.51, 0.14, 0.12);

            #region left horn
            GL.Begin(PrimitiveType.Polygon);

            GL.Vertex2(-0.14, 0.82);
            GL.Vertex2(-0.16, 0.94);
            GL.Vertex2(-0.25, 0.99);
            GL.Vertex2(-0.31, 1.04);
            GL.Vertex2(-0.31, 1.13);
            GL.Vertex2(-0.26, 1.21);
            GL.Vertex2(-0.3, 1.28);
            GL.Vertex2(-0.39, 1.28);
            GL.Vertex2(-0.45, 1.21);
            GL.Vertex2(-0.48, 1.1);
            GL.Vertex2(-0.47, 1.02);
            GL.Vertex2(-0.54, 1.04);
            GL.Vertex2(-0.58, 1.14);
            GL.Vertex2(-0.54, 1.28);
            GL.Vertex2(-0.56, 1.38);
            GL.Vertex2(-0.65, 1.39);
            GL.Vertex2(-0.7, 1.34);
            GL.Vertex2(-0.74, 1.24);
            GL.Vertex2(-0.74, 1.16);
            GL.Vertex2(- 0.72, 1.08);
            GL.Vertex2(-0.8, 1.14);
            GL.Vertex2(-0.84, 1.26);
            GL.Vertex2(-0.79, 1.35);
            GL.Vertex2(-0.75, 1.43);
            GL.Vertex2(-0.79, 1.35);
            GL.Vertex2(-0.75, 1.43);
            GL.Vertex2(-0.79, 1.49);
            GL.Vertex2(-0.87, 1.49);
            GL.Vertex2(-0.96, 1.39);
            GL.Vertex2(-0.99, 1.31);
            GL.Vertex2(-1.01, 1.23);
            GL.Vertex2(-1.01, 1.11);
            GL.Vertex2(-0.97, 0.96);
            GL.Vertex2(-0.86, 0.82);
            GL.Vertex2(-0.66, 0.78);
            GL.Vertex2(-0.45, 0.81);
            GL.Vertex2(-0.35, 0.83);
            GL.Vertex2(-0.31, 0.77);

            GL.End();
            #endregion

            #region right horn
            GL.Begin(PrimitiveType.Polygon);

            GL.Vertex2(0.11, 0.82);
            GL.Vertex2(0.13, 0.92);
            GL.Vertex2(0.18, 0.97);
            GL.Vertex2(0.26, 1);
            GL.Vertex2(0.29, 1.08);
            GL.Vertex2(0.27, 1.14);
            GL.Vertex2(0.24, 1.17);
            GL.Vertex2(0.23, 1.24);
            GL.Vertex2(0.28, 1.28);
            GL.Vertex2(0.37, 1.27);
            GL.Vertex2(0.4, 1.23);
            GL.Vertex2(0.43, 1.17);
            GL.Vertex2(0.44, 1.1);
            GL.Vertex2(0.44, 1.01);
            GL.Vertex2(0.47, 1.01);
            GL.Vertex2(0.52, 1.04);
            GL.Vertex2(0.54, 1.11);
            GL.Vertex2(0.54, 1.16);
            GL.Vertex2(0.53, 1.21);
            GL.Vertex2(0.51, 1.26);
            GL.Vertex2(0.51, 1.33);
            GL.Vertex2(0.56, 1.37);
            GL.Vertex2(0.61, 1.37);
            GL.Vertex2(0.67, 1.33);
            GL.Vertex2(0.7, 1.26);
            GL.Vertex2(0.71, 1.2);
            GL.Vertex2(0.71, 1.15);
            GL.Vertex2(0.69, 1.07);
            GL.Vertex2(0.75, 1.09);
            GL.Vertex2(0.79, 1.15);
            GL.Vertex2(0.79, 1.22);
            GL.Vertex2(0.78, 1.29);
            GL.Vertex2(0.75, 1.35);
            GL.Vertex2(0.72, 1.4);
            GL.Vertex2(0.73, 1.46);
            GL.Vertex2(0.77, 1.49);
            GL.Vertex2(0.82, 1.47);
            GL.Vertex2(0.87, 1.45);
            GL.Vertex2(0.92, 1.38);
            GL.Vertex2(0.95, 1.31);
            GL.Vertex2(0.97, 1.23);
            GL.Vertex2(0.97, 1.11);
            GL.Vertex2(0.96, 1.02);
            GL.Vertex2(0.91, 0.92);
            GL.Vertex2(0.85, 0.85);
            GL.Vertex2(0.76, 0.81);
            GL.Vertex2(0.67, 0.79);
            GL.Vertex2(0.56, 0.8);
            GL.Vertex2(0.43, 0.82);
            GL.Vertex2(0.32, 0.83);
            GL.Vertex2(0.28, 0.78);

            GL.End();
            #endregion
        }

        private void DrawNose()
        {
            GL.Color3(0.785, 0.32, 0.1);

            GL.Begin(PrimitiveType.Polygon);
            
            GL.Vertex2(-0.01, 0.33);
            GL.Vertex2(-0.04, 0.22);
            GL.Vertex2(-0.11, 0.15);
            GL.Vertex2(-0.27, 0.06);
            GL.Vertex2(-0.33, -0.03);
            GL.Vertex2(-0.33, -0.16);
            GL.Vertex2(-0.26, -0.27);
            GL.Vertex2(-0.13, -0.3);
            GL.Vertex2(0.0, -0.3);
            GL.Vertex2(0.17, -0.28);
            GL.Vertex2(0.29, -0.2);
            GL.Vertex2(0.32, -0.11);
            GL.Vertex2(0.29, 0.01);
            GL.Vertex2(0.2, 0.08);
            GL.Vertex2(0.08, 0.16);
            GL.Vertex2(0.03, 0.25);

            GL.End();
        }

        private void DrawEars()
        {
            GL.Color3(0.91, 0.539, 0.11);

            #region left ear
            GL.Begin(PrimitiveType.Polygon);
            
            GL.Vertex2(0.46, 0.64);
            GL.Vertex2(0.55, 0.65);
            GL.Vertex2(0.65, 0.65);
            GL.Vertex2(0.72, 0.62);
            GL.Vertex2(0.77, 0.53);
            GL.Vertex2(0.78, 0.44);
            GL.Vertex2(0.7, 0.42);
            GL.Vertex2(0.59, 0.44);
            GL.Vertex2(0.52, 0.5);

            GL.End();
            #endregion

            #region right ear
            GL.Begin(PrimitiveType.Polygon);
            
            GL.Vertex2(-0.48, 0.64);
            GL.Vertex2(-0.57, 0.65);
            GL.Vertex2(-0.69, 0.64);
            GL.Vertex2(-0.77, 0.59);
            GL.Vertex2(-0.79, 0.53);
            GL.Vertex2(-0.8, 0.45);
            GL.Vertex2(-0.75, 0.43);
            GL.Vertex2(-0.67, 0.43);
            GL.Vertex2(-0.58, 0.46);
            GL.Vertex2(-0.53, 0.5);

            GL.End();
            #endregion
        }

        private void DrawMouth()
        {
            GL.Color3(0.51, 0.14, 0.12);
            GL.LineWidth(5);

            GL.Begin(PrimitiveType.LineStrip);

            GL.Vertex2(0.44, 0.04);
            GL.Vertex2(0.44, 0.03);
            GL.Vertex2(0.43, 0.01);
            GL.Vertex2(0.43, -0.01);
            GL.Vertex2(0.43, -0.04);
            GL.Vertex2(0.43, -0.05);
            GL.Vertex2(0.43, -0.06);
            GL.Vertex2(0.43, -0.07);
            GL.Vertex2(0.44, -0.09);
            GL.Vertex2(0.44, -0.1);
            GL.Vertex2(0.45, -0.12);
            GL.Vertex2(0.46, -0.14);
            GL.Vertex2(0.46, -0.15);
            GL.Vertex2(0.47, -0.15);
            GL.Vertex2(0.48, -0.15);

            GL.End();

            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(0.32, -0.11);

            GL.Vertex2(0.43, -0.06);
            GL.End();
        }

        private void DrawEyebrows()
        {
            GL.Color3(0.51, 0.14, 0.12);

            #region left eyebrow
            GL.Begin(PrimitiveType.Polygon);

            GL.Vertex2(-0.34, 0.68);
            GL.Vertex2(-0.33, 0.61);
            GL.Vertex2(-0.11, 0.64);
            GL.Vertex2(-0.11, 0.7);
            GL.Vertex2(-0.14, 0.75);

            GL.End();
            #endregion

            #region right eyebrow
            GL.Begin(PrimitiveType.Polygon);

            GL.Vertex2(0.11, 0.75);
            GL.Vertex2(0.31, 0.68);
            GL.Vertex2(0.32, 0.64);
            GL.Vertex2(0.3, 0.6);
            GL.Vertex2(0.09, 0.63);
            GL.Vertex2(0.08, 0.7);

            GL.End();
            #endregion
        }
    }
}