using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContraModels.MenuModels;

namespace ContraViewers.MenuRender
{
    public class MenuGraphicsRender : BufferedGraphicsRenderer, IMenuRender
    {
        public MenuGraphicsRender(Control control)
               : base(control)
        {
        }

        public void Render(ContraModels.MenuModels.Menu menu)
        {
            Graphics graphics = _bufferedGraphics.Graphics;
            graphics.Clear(Color.Black);
            graphics.ResetTransform();
            float width = menu.Background.Width * ((float)_control.ClientRectangle.Height / menu.Background.Height);
            float height = menu.Background.Height;

            Rectangle srcRect = new Rectangle(0, 0, menu.Background.Width, menu.Background.Height);
            Rectangle dstRect = new Rectangle((_control.ClientRectangle.Width - (int)width) / 2, 0, (int)width, _control.ClientRectangle.Height);

            graphics.DrawImage(menu.Background, dstRect, srcRect, GraphicsUnit.Pixel);
            _bufferedGraphics.Render(_graphics);
        }
    }
}
