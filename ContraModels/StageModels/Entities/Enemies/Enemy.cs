using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ContraModels.StageModels.Entities.Enemies
{
    public class Enemy : Entity
    {
        public Vector2 ViewDirection { get; set; }
        public float ViewFov { get; set; }
        public float ViewDistance { get; set; }

        public Enemy()
        {

        }
    }
}
