using ContraModels.StageModels.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ContraModels.StageModels.Entities
{
    public class Entity : IMovement, IFocusable
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public EntitySprite Sprite { get; set; }

        public Entity()
        {
        }

        public virtual void Update(float dt)
        {
            Sprite.Update(dt);
        }
    }
}
