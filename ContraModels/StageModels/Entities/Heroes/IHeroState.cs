using ContraModels.StageModels.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContraModels.StageModels.Entities.Heroes
{
    public interface IHeroState
    {
        void Entry();
        void Update(float dt);
        void Left(bool pressed);
        void Right(bool pressed);
        void Up(bool pressed);
        void Down(bool pressed);
        void Fire(bool pressed);
        void Jump(bool pressed);
        void OnCollision(AABB box);
        string Animation { get; }
        void OnEnterWater(AABB box);
    }
}
