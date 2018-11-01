using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContraModels.StageModels.Entities.PowerUps
{
    public enum FalconType
    {
        /// <summary>
        /// Machine Gun Falcon
        /// </summary>
        MachineGun,

        /// <summary>
        /// Laser Falcon
        /// </summary>
        Laser,

        /// <summary>
        /// Fire Ball Falcon
        /// </summary>
        FireBall,

        /// <summary>
        /// Rapid Fire Falcon
        /// </summary>
        RapidFire,

        /// <summary>
        /// Spread Gun Falcon
        /// </summary>
        SpreadGun,

        /// <summary>
        /// Force Field Flacon
        /// </summary>
        ForceField,

        /// <summary>
        /// Mass Destruction Falcon
        /// </summary>
        MassDestruction
    }

    public class PowerUp : Entity
    {
    }
}
