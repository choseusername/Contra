using ContraModels.StageModels.Entities.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Windows.Forms;

namespace ContraControllers.GameControllers.HeroControllers
{
    public class HeroController
    {
        private Hero _hero;

        public HeroController(Hero hero)
        {
            _hero = hero;
        }

        public void Update(float dt)
        {
        }

        public void KeyHandler(Keys key, KeyAction action)
        {
            //if (key == Keys.Left)
            //{
            //    if (action == KeyAction.Pressed)
            //    {
            //        _hero.Velocity = new Vector2(-1.0f * _hero.MaxSpeed.X, _hero.Velocity.Y);
            //        _hero.Sprite.FlippedX = true;
            //    }
            //    else if (action == KeyAction.Released)
            //    {
            //        _hero.Velocity = new Vector2(0.0f, _hero.Velocity.Y);
            //    }
            //}
            //
            //if (key == Keys.Right)
            //{
            //    if (action == KeyAction.Pressed)
            //    {
            //        _hero.Velocity = new Vector2(_hero.MaxSpeed.X, _hero.Velocity.Y);
            //        _hero.Sprite.FlippedX = false;
            //    }
            //    else if (action == KeyAction.Released)
            //    {
            //        _hero.Velocity = new Vector2(0.0f, _hero.Velocity.Y);
            //    }
            //}

            if (key == Keys.Space)
            {
                _hero.Jump(action == KeyAction.Pressed);
            }

            if (key == Keys.Down)
            {
                _hero.Down(action == KeyAction.Pressed);
            }

            if (key == Keys.Up)
            {
                _hero.Up(action == KeyAction.Pressed);
            }

            if (key == Keys.Left)
            {
                _hero.Left(action == KeyAction.Pressed);
            }

            if (key == Keys.Right)
            {
                _hero.Right(action == KeyAction.Pressed);
            }
        }
    }
}
