using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ContraModels.StageModels.Physics;

namespace ContraModels.StageModels.Entities.Heroes
{
    public class SwimmingState : IHeroState
    {
        private Hero _hero;
        private string _animation;

        public SwimmingState(Hero hero)
        {
            _hero = hero;
        }

        public string Animation { get => _animation; }

        public void Down(bool pressed)
        {
            if (pressed)
                _animation = "Swimming_Laying_Down";
            else
                _animation = "Swimming_Walking";
        }

        public void Fire(bool pressed)
        {
            throw new NotImplementedException();
        }

        public void Jump(bool pressed)
        {
            _hero.State = _hero.JumpingState;
        }

        public void Left(bool pressed)
        {
            if (pressed)
            {
                _hero.Velocity = new Vector2(-1.0f * _hero.MaxSpeed.X, _hero.Velocity.Y);
                _hero.Sprite.FlippedX = true;

                if (_animation.Equals("Swimming_Looking_Up"))
                    _animation = "Swimming_Looking_Up_Angle";
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
                _hero.Velocity = new Vector2(1.0f * _hero.MaxSpeed.X, _hero.Velocity.Y);
                _hero.Sprite.FlippedX = false;

                if (_animation.Equals("Swimming_Looking_Up"))
                    _animation = "Swimming_Looking_Up_Angle";
            }
            else
            {
                _hero.Velocity = new Vector2(0.0f, _hero.Velocity.Y);
            }
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


        public void Up(bool pressed)
        {
            if (pressed)
            {
                if (Math.Abs(_hero.Velocity.X) > 0.0f)
                    _animation = "Swimming_Looking_Up_Angle";
                else
                    _animation = "Swimming_Looking_Up";
            }
            else
            { 
                _animation = "Swimming_Walking";
            }
        }

        public void Update(float dt)
        {
        }

        public void Entry()
        {
            _animation = "Swimming_Walking";
        }

        public void OnEnterWater(AABB box)
        {
        }
    }
}
