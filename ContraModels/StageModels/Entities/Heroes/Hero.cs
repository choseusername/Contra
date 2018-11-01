using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using ContraModels.StageModels.Physics;

namespace ContraModels.StageModels.Entities.Heroes
{
    public class Hero : Entity
    {
        public IHeroState NormalState { get; set; }
        public IHeroState JumpingState { get; set; }
        public IHeroState SwimmingState { get; set; }
        public IHeroState PreviusState { get; set; }
        private IHeroState _state;
        public IHeroState State { get => _state; set { PreviusState = _state; _state = value; _state.Entry(); } }

        public Vector2 MaxSpeed { get; set; }

        public AABB FootPhysicBox
        {
            get
            {
                return new AABB(new Vector2(Position.X - 10, Position.Y - 4), new Vector2(Position.X + 10, Position.Y));
            }
        }


        public Hero()
        {
            dynamic description = JObject.Parse(File.ReadAllText("Assets/Lance.json"));
            MaxSpeed = new Vector2((float)description.MaxSpeed.X, (float)description.MaxSpeed.Y);
            Sprite = new EntitySprite(description, "Walking", this);

            NormalState = new NormalState(this);
            JumpingState = new JumpingState(this);
            SwimmingState = new SwimmingState(this);
            State = NormalState;
        }

        public void Left(bool pressed)
        {
            State.Left(pressed);
        }

        public void Right(bool pressed)
        {
            State.Right(pressed);
        }

        public void Up(bool pressed)
        {
            State.Up(pressed);
        }

        public void Down(bool pressed)
        {
            State.Down(pressed);
        }

        public void Fire(bool pressed)
        {
            State.Fire(pressed);
        }

        public void Jump(bool pressed)
        {
            State.Jump(pressed);
        }

        public void OnCollision(AABB boundingBox)
        {
            State.OnCollision(boundingBox);
        }

        public void OnEnterWater(AABB box)
        {
            State.OnEnterWater(box);
        }


        public override void Update(float dt)
        {
            State.Update(dt);
            Sprite.Animation = State.Animation;
            base.Update(dt);
        }
    }
}
