using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ContraModels.StageModels.Entities.Heroes;
using System.Numerics;
using ContraModels.StageModels.Physics;

namespace ContraModels.StageModels.Stages
{
    public class Stage1_Jungle : Stage
    {
        public Stage1_Jungle()
            : base()
        {
            OnLoadStage();
            Hero.State = Hero.JumpingState;
            Hero.Position = new Vector2(55, 0);
        }
        
        protected override void OnLoadStage()
        {
            dynamic stageDescription = JObject.Parse(File.ReadAllText("Assets/Jungle.json"));
            Collision = CreateStageCollision(stageDescription);
            WaterZones = CreateStageWaterZones(stageDescription);

            StageBackground = Image.FromFile((string)stageDescription.Image);
            Width = (float)stageDescription.Width;
            Height = (float)stageDescription.Height;
        }

    }
}
