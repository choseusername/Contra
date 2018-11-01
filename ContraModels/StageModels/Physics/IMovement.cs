using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ContraModels.StageModels.Physics
{
    public interface IMovement
    {
        Vector2 Velocity { get; set; }
    }
}
