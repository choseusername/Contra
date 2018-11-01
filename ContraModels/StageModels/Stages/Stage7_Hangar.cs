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
    public class Stage7_Hangar: Stage
    {
        public Stage7_Hangar()
            : base()
        {
            OnLoadStage();
            Hero.State = Hero.JumpingState;
            Hero.Position = new Vector2(55, 0);
        }


        protected override void OnLoadStage()
        {
            dynamic stageDescription = JObject.Parse(File.ReadAllText("Assets/Hangar.json"));
            Collision = CreateStageCollision(stageDescription);

            StageBackground = Image.FromFile((string)stageDescription.Image);
            Width = (float)stageDescription.Width;
            Height = (float)stageDescription.Height;

        }
    }
}
