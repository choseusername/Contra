using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ContraModels.StageModels.Physics;

namespace ContraModels.StageModels.Entities.Heroes
{
    public class JumpingState : IHeroState
    {
        private Hero _hero;

        private string _animation;
        public string Animation { get => _animation; }

        public JumpingState(Hero hero)
        {
            _hero = hero;
            _animation = "Jumping";
        }

        public void Down(bool pressed)
        {
        }

        public void Fire(bool pressed)
        {
            throw new NotImplementedException();
        }

        public void Jump(bool pressed)
        {
        }

        public void Left(bool pressed)
        {
            if (pressed)
            {
                _hero.Velocity = new Vector2(-1.0f * _hero.MaxSpeed.X, _hero.Velocity.Y);
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
                _hero.Velocity = new Vector2(1.0f * _hero.MaxSpeed.X, _hero.Velocity.Y);
                _hero.Sprite.FlippedX = false;
            }
            else
            {
                _hero.Velocity = new Vector2(0.0f, _hero.Velocity.Y);
            }
        }

        public void OnCollision(AABB box)
        {
            //if (_hero.Velocity.Y > 0.0f)
            //{
            //    _hero.Position = new Vector2(_hero.Position.X, box.Min.Y);
            //    _hero.Velocity = new Vector2(_hero.Velocity.X, 0.0f);
            //
            //    _hero.State = _hero.Walking_State;
            //}

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
                if (_hero.Velocity.Y > 0.0f)
                {
                    _hero.Position = new Vector2(_hero.Position.X, _hero.Position.Y - deltay);
                    _hero.Velocity = new Vector2(_hero.Velocity.X, 0.0f);

                    _hero.State = _hero.NormalState;
                }
            }
            else
            {
                _hero.Position = new Vector2(_hero.Position.X + deltax, _hero.Position.Y);
            }
        }

        public void Up(bool pressed)
        {
        }

        public void Update(float dt)
        {
        }

        public void Entry()
        {
            _hero.Velocity = new Vector2(_hero.Velocity.X, _hero.MaxSpeed.Y);
        }

        public void OnEnterWater(AABB box)
        {
            if (_hero.Velocity.Y > 0.0f)
                _hero.State = _hero.SwimmingState;
        }
    }
}
