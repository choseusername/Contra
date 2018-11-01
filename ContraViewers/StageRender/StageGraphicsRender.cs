using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Numerics;
using ContraModels;
using ContraModels.StageModels.Physics;
using ContraModels.StageModels.Entities;
using ContraModels.StageModels.Stages;

namespace ContraViewers.StageRender
{
    public class StageGraphicsRender : BufferedGraphicsRenderer, IStageReder
    {
        private Camera _camera;

        public StageGraphicsRender(Control control)
            : base(control)
        {
            _camera = new Camera();
        }

        protected void Update(Stage stage)
        {
            // Горизонтальный уровень
            float width = stage.Height * ((float)_control.ClientRectangle.Width / _control.ClientRectangle.Height);
            float height = stage.Height;
            _camera.Viewport = new Vector2(width, height);
            _camera.Scale = _control.ClientRectangle.Width / width;
            _camera.Bounds = new RectangleF(0.0f, 0.0f, stage.Width - width, 0.0f);
            _camera.FocusAt = stage.Hero.Position;
            _camera.Update(0.0f);
            
        }

        public void Render(Stage stage)
        {
            Update(stage);

            Graphics graphics = _bufferedGraphics.Graphics;
            graphics.Clear(SystemColors.Control);

            graphics.ResetTransform();
            graphics.DrawImage(stage.StageBackground, _control.ClientRectangle, new Rectangle((int)_camera.Position.X, (int)_camera.Position.Y, (int)_camera.Viewport.X, (int)_camera.Viewport.Y), GraphicsUnit.Pixel);

            graphics.Transform = _camera.Transform;
            //graphics.DrawRectangle(Pens.Yellow, stage.Hero.FootPhysicBox.Min.X, stage.Hero.FootPhysicBox.Min.Y, stage.Hero.FootPhysicBox.Max.X - stage.Hero.FootPhysicBox.Min.X, stage.Hero.FootPhysicBox.Max.Y - stage.Hero.FootPhysicBox.Min.Y);
            //foreach (AABB box in stage.WaterZones)
            //{
            //    graphics.DrawRectangle(Pens.Fuchsia, box.Min.X, box.Min.Y, box.Max.X - box.Min.X, box.Max.Y - box.Min.Y);
            //}
            //
            //foreach (AABB box in stage.Collision)
            //{
            //    graphics.DrawRectangle(Pens.Purple, box.Min.X, box.Min.Y, box.Max.X - box.Min.X, box.Max.Y - box.Min.Y);
            //}

            foreach (Entity entity in stage.Objects)
            {
                // transform = model * view * projection;
                graphics.ResetTransform(); // make transform identity
                graphics.MultiplyTransform(entity.Sprite.Transform, MatrixOrder.Append);
                graphics.MultiplyTransform(_camera.Transform, MatrixOrder.Append);
                graphics.DrawImage(entity.Sprite.Image, 0, 0, entity.Sprite.Rectangle, GraphicsUnit.Pixel);
            }

            _bufferedGraphics.Render(_graphics);
        }
    }
}
