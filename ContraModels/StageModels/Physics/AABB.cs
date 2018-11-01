using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ContraModels.StageModels.Physics
{
    public class AABB
    {
        public Vector2 Min;
        public Vector2 Max;

        public AABB(Vector2 min, Vector2 max)
        {
            Min = min;
            Max = max;
        }

        /// <summary>
        /// Проверка перекрытий.
        /// Если расстояние между центрами каждой оси меньше, чем сумма половинных размеров,
        /// то перекрывается.
        /// </summary>
        /// <param name="box"></param>
        /// <returns>Перекрывается?</returns>
        public bool Intersect(AABB box)
        {
            if (Max.X < box.Min.X) return false;
            if (Min.X > box.Max.X) return false;
            if (Max.Y < box.Min.Y) return false;
            if (Min.Y > box.Max.Y) return false;
            return true;
        }
    }
}
