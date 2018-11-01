using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContraModels.StageModels.Entities.Enemies.Bosses
{
    public class AlienHeart : Enemy
    {
        public AlienHeart()
        {
            dynamic description = JObject.Parse(File.ReadAllText("Assets/AlienHeart.json"));
            Sprite = new EntitySprite(description, "Dead", this);
        }
    }
}
