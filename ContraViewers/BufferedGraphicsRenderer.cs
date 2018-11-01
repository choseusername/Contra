using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ContraViewers
{
    public class BufferedGraphicsRenderer : IDisposable
    {
        protected BufferedGraphicsContext _bufferedGraphicsContext;
        protected BufferedGraphics _bufferedGraphics;
        protected Graphics _graphics;
        protected Control _control;

        public BufferedGraphicsRenderer(Control control)
        {
            _control = control;
            _control.SizeChanged += _control_SizeChanged;
            CreateBufferedGraphics();
        }

        private void _control_SizeChanged(object sender, EventArgs e)
        {
            Dispose();
            CreateBufferedGraphics();
        }

        private void CreateBufferedGraphics()
        {
            _graphics = _control.CreateGraphics();
            _bufferedGraphicsContext = BufferedGraphicsManager.Current;
            _bufferedGraphicsContext.MaximumBuffer = new Size(_control.Width, _control.Height);
            _bufferedGraphics = _bufferedGraphicsContext.Allocate(_graphics, new Rectangle(0, 0, _control.Width, _control.Height));
            _bufferedGraphics.Graphics.SmoothingMode = SmoothingMode.Default;
            _bufferedGraphics.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            _bufferedGraphics.Graphics.PixelOffsetMode = PixelOffsetMode.Default;
        }

        public void Dispose()
        {
            _bufferedGraphics?.Dispose();
            _graphics?.Dispose();
        }
    }
}
