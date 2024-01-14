using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace Ripples
{
    public class Shader
    {
        public int Program { get; private set; }

        public Shader(string vertPath, string fragPath)
        {
            var shaderSource = File.ReadAllText(vertPath);

            var vertexShader = GL.CreateShader(ShaderType.VertexShader);

            GL.ShaderSource(vertexShader, shaderSource);

            CompileShader(vertexShader);

            shaderSource = File.ReadAllText(fragPath);
            var fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, shaderSource);
            CompileShader(fragmentShader);

            Program = GL.CreateProgram();

            GL.AttachShader(Program, vertexShader);
            GL.AttachShader(Program, fragmentShader);

            LinkProgram();

            GL.DetachShader(Program, vertexShader);
            GL.DetachShader(Program, fragmentShader);
            GL.DeleteShader(fragmentShader);
            GL.DeleteShader(vertexShader);
        }

        private static void CompileShader(int shader)
        {
            GL.CompileShader(shader);

            GL.GetShader(shader, ShaderParameter.CompileStatus, out var code);
            if (code != (int)All.True)
            {
                var infoLog = GL.GetShaderInfoLog(shader);
                throw new Exception($"Error occurred whilst compiling Shader({shader}).\n\n{infoLog}");
            }
        }

        private void LinkProgram()
        {
            GL.LinkProgram(Program);

            GL.GetProgram(Program, GetProgramParameterName.LinkStatus, out var code);
            if (code != (int)All.True)
            {
                throw new Exception($"Error occurred whilst linking Program({Program})");
            }
        }

        public void Use()
        {
            GL.UseProgram(Program);
        }

        public void Off()
        {
            GL.UseProgram(0);
        }

        public int GetUniformLocation(string name)
        {
            return GL.GetUniformLocation(Program, name);
        }

        public int GetAttribLocation(string name)
        {
            return GL.GetAttribLocation(Program, name);
        }

        public void SetUniform1(string name, int value)
        {
            int location = GetUniformLocation(name);
            GL.Uniform1(location, value);
        }

        public void SetUniform1(string name, float value)
        {
            int location = GetUniformLocation(name);
            GL.Uniform1(location, value);
        }

        public void SetUniform2(string name, Vector2 value)
        {
            int location = GetUniformLocation(name);
            GL.Uniform2(location, value);
        }
    }
}
