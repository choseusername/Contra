using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;
using ContraModels.StageModels.Entities;
using ContraModels.StageModels.Entities.Heroes;
using ContraModels.StageModels.Physics;
using ContraModels.StageModels.Entities.Enemies;

namespace ContraModels.StageModels.Stages
{
    public abstract class Stage : IDisposable
    {
        private Vector2 _gravity;

        public float Width { get; set; }
        public float Height { get; set; }

        public IList<AABB> Collision { get; set; }
        public IList<AABB> WaterZones { get; set; }
        public IList<AABB> DeathZones { get; set; }
        public IList<Entity> Objects { get; set; }

        public Image StageBackground { get; set; }
        public Hero Hero { get; set; }

        public Enemy Boss { get; set; }

        public Stage()
        {
            _gravity = new Vector2(0.0f, 500.0f);
            WaterZones = new List<AABB>();
            Collision = new List<AABB>();
            Objects = new List<Entity>();
            Hero = new Hero();
            Objects.Add(Hero);
        }

        protected virtual void OnLoadStage()
        {
        }

        public void FixedUpdate(float dt)
        {
            Hero.Velocity = Hero.Velocity + _gravity * dt;
            Hero.Position = Hero.Position + Hero.Velocity * dt;


            foreach (AABB box in Collision)
            {
                if (box.Intersect(Hero.FootPhysicBox))
                {
                    Hero.OnCollision(box);
                }
            }

            foreach (AABB box in WaterZones)
            {
                if (box.Intersect(Hero.FootPhysicBox))
                {
                    Hero.OnEnterWater(box);
                }
            }

            //foreach (AABB box in DeathZones)
            //{
            //    if (box.Intersect(Hero.FootPhysicBox))
            //    {
            //
            //    }
            //}
        }


        public void UpdatAllEntities(float dt)
        {
            foreach (Entity entity in Objects)
                entity.Update(dt);
        }

        private const float PHYSIC_FIXED_STEP = 0.0005f;

        public void Update(float dt)
        {
            float accumulator = dt;
            while (accumulator >= PHYSIC_FIXED_STEP)
            {
                FixedUpdate(PHYSIC_FIXED_STEP);
                accumulator -= PHYSIC_FIXED_STEP;
            }

            UpdatAllEntities(dt);
        }

        protected IList<AABB> CreateStageCollision(dynamic description)
        {
            IList<AABB> collision = new List<AABB>();
            foreach (dynamic box in description.Collision)
            {
                Vector2 min = new Vector2((float)box.Min.X, (float)box.Min.Y);
                Vector2 max = new Vector2((float)box.Max.X, (float)box.Max.Y);
                collision.Add(new AABB(min, max));
            }
            return collision;
        }

        protected IList<AABB> CreateStageWaterZones(dynamic description)
        {
            IList<AABB> waterZones = new List<AABB>();
            foreach (dynamic box in description.WaterZones)
            {
                Vector2 min = new Vector2((float)box.Min.X, (float)box.Min.Y);
                Vector2 max = new Vector2((float)box.Max.X, (float)box.Max.Y);
                waterZones.Add(new AABB(min, max));
            }
            return waterZones;
        }

        public void Dispose()
        {
            foreach(Entity e in Objects)
            {
                e.Sprite.Image.Dispose();
            }
            StageBackground.Dispose();
        }
    }
}
