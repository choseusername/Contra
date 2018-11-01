using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ContraModels.StageModels.Entities
{
    public class EntitySprite
    {
        private Image _image;
        private dynamic _description;
        private string _animation;
        private int _frame;
        private float _time;
        private float _swapTime;
        private Entity _entity;
        private Rectangle _srcRect;
        private bool _flippedX;

        public bool FlippedX
        {
            get => _flippedX;
            set => _flippedX = value;
        }


        public Rectangle Rectangle
        {
            get => _srcRect;
        }

        public Image Image
        {
            get => _image;
            set => _image = value;
        }

        public string Animation
        {
            get => _animation;
            set => _animation = value;
        }

        public EntitySprite(dynamic description, string animation, Entity entity)
        {
            _image = Image.FromFile((string)description.Image);
            _description = description;
            _swapTime = (float)_description.SwapTime;
            _animation = animation;
            _frame = 0;
            _time = 0.0f;
            _flippedX = false;
            _entity = entity;
        }

        public Matrix Transform
        {
            get
            {
                Matrix transform = new Matrix();
                if (_flippedX)
                {
                    transform.Scale(-1.0f, 1.0f, MatrixOrder.Append);
                    transform.Translate(_entity.Position.X + _srcRect.Width / 2.0f, _entity.Position.Y - _srcRect.Height, MatrixOrder.Append);
                }
                else
                {
                    transform.Translate(_entity.Position.X - _srcRect.Width / 2.0f, _entity.Position.Y - _srcRect.Height, MatrixOrder.Append);
                }
                return transform;
            }
        }

        public void Update(float dt)
        {
            _time += dt;
            if (_time > _swapTime)
            {
                _time = 0.0f;
                _frame++;
            }
            _frame = _frame % _description.Animations[_animation].Count;

            _srcRect = new Rectangle(
                (int)_description.Animations[_animation][_frame].x,
                (int)_description.Animations[_animation][_frame].y,
                (int)_description.Animations[_animation][_frame].width,
                (int)_description.Animations[_animation][_frame].height);
        }
    }
}
