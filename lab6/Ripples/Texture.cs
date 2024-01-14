using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Versioning;
using OpenTK.Graphics.OpenGL4;

namespace Ripples
{
    [SupportedOSPlatform("windows")]
    public class Texture
    {
        private readonly int _handle;

        public TextureUnit Unit { get; private set; }

        public Texture(string path)
        {
            var bitmap = new Bitmap(path);

            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

            _handle = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, _handle);

            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL4.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

            bitmap.UnlockBits(data);
            GL.BindTexture(TextureTarget.Texture2D, 0);
        }

        public void Use(TextureUnit unit)
        {
            Unit = unit;
            GL.ActiveTexture(unit);
            GL.BindTexture(TextureTarget.Texture2D, _handle);
        }
    }
}
