using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ContraModels.StageModels.Physics;

namespace ContraModels.StageModels.Entities.Heroes
{
    public class NormalState : IHeroState
    {
        private Hero _hero;

        public NormalState(Hero hero)
        {
            _hero = hero;
            _animation = "Walking";
        }

        protected string _animation;
        public string Animation { get => _animation; }

        public void Down(bool pressed)
        {
            if (pressed)
            {
                _animation = "Laying_Down";

                _hero.Velocity = new Vector2(0.0f, _hero.Velocity.Y);
            }
            else
                _animation = "Standing";
        }

        public void Fire(bool pressed)
        {
            throw new NotImplementedException();
        }

        public void Jump(bool pressed)
        {
            _hero.State = _hero.JumpingState;
        }
        
        public void OnCollision(AABB box)
        {
            float deltay = 0;
            if (box.Min.Y < _hero.FootPhysicBox.Max.Y)
                deltay = _hero.FootPhysicBox.Max.Y - box.Min.Y;

            float deltax = 0;

            float deltax_right = box.Max.X - _hero.FootPhysicBox.Min.X;
            float deltax_left = box.Min.X - _hero.FootPhysicBox.Max.X;
            if (Math.Abs(deltax_left) < Math.Abs(deltax_right))
                deltax = deltax_left;
            else
                deltax = deltax_right;


            if (deltay < Math.Abs(deltax))
            {
                _hero.Position = new Vector2(_hero.Position.X, _hero.Position.Y - deltay);
                _hero.Velocity = new Vector2(_hero.Velocity.X, 0.0f);
            }
            else
            {
                _hero.Position = new Vector2(_hero.Position.X + deltax, _hero.Position.Y);
            }
        }

        public void Left(bool pressed)
        {
            if (pressed)
            {
                if (!_animation.Equals("Laying_Down"))
                {
                    _hero.Velocity = new Vector2(-1.0f * _hero.MaxSpeed.X, _hero.Velocity.Y);
                }
                _hero.Sprite.FlippedX = true;
            }
            else
            {
                _hero.Velocity = new Vector2(0.0f, _hero.Velocity.Y);
            }
        }

        public void Right(bool pressed)
        {
            if (pressed)
            {
                if (!_animation.Equals("Laying_Down"))
                {
                    _hero.Velocity = new Vector2(1.0f * _hero.MaxSpeed.X, _hero.Velocity.Y);
                }
                _hero.Sprite.FlippedX = false;
                
            }
            else
            {
                _hero.Velocity = new Vector2(0.0f, _hero.Velocity.Y);
            }
        }

        public void Up(bool pressed)
        {
            if (pressed)
                _animation = "Looking_Up_Angle";
            else
                _animation = "Walking";
        }

        public void Update(float dt)
        {
            if (!_animation.Equals("Laying_Down"))
            {
                if (Math.Abs(_hero.Velocity.X) < float.Epsilon)
                    _animation = "Standing";
                else if (_animation.Equals("Standing"))
                    _animation = "Walking";
            }
        }

        public void Entry()
        {
            _animation = "Walking";
        }

        public void OnEnterWater(AABB box)
        {
            _hero.State = _hero.SwimmingState;
        }
    }
}
