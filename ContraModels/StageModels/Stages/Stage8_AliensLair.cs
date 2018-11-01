using ContraModels.StageModels.Entities.Enemies.Bosses;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ContraModels.StageModels.Stages
{
    public class Stage8_AliensLair : Stage
    {
        public Stage8_AliensLair()
               : base()
        {
            OnLoadStage();
        }

        protected override void OnLoadStage()
        {
            dynamic stageDescription = JObject.Parse(File.ReadAllText("Assets/AliensLair.json"));
            Collision = CreateStageCollision(stageDescription);

            StageBackground = Image.FromFile((string)stageDescription.Image);
            Width = (float)stageDescription.Width;
            Height = (float)stageDescription.Height;

            Hero.State = Hero.JumpingState;
            Hero.Position = new Vector2(2000, 0);

            Boss = new AlienHeart();
            Boss.Position = new Vector2(2711, 221);
            Objects.Insert(0, Boss);
        }
    }
}
