using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing.Drawing2D;
using System.Drawing;
using MathExtensions;

namespace ContraViewers.StageRender
{
    public class Camera
    {
        public Matrix Transform { get; }
        public Vector2 Position { get; set; }
        public Vector2 Viewport { get; set; }
        public Vector2 FocusAt { get; set; }
        public RectangleF Bounds { get; set; }
        public float Scale { get; set; }

        public void Update(float dt)
        {
            Position = (FocusAt - new Vector2(Viewport.X / 2.0f, Viewport.Y / 2.0f));

            // Clamp bounds
            Position = new Vector2(
                (int)Position.X.Clamp(Bounds.X, Bounds.Width),
                (int)Position.Y.Clamp(Bounds.Y, Bounds.Height));

            Transform.Reset();
            Transform.Scale(Scale, Scale);
            Transform.Translate(-Position.X, -Position.Y);
        }

        public Camera()
        {
            Transform = new Matrix();
            Scale = 1.0f;
            Position = Vector2.Zero;
        }
    }
}
