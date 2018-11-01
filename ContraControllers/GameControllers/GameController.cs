using ContraControllers.GameControllers.HeroControllers;
using ContraModels.StageModels.Stages;
using ContraViewers;
using ContraViewers.StageRender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContraControllers.GameControllers
{
    public abstract class GameController : IController
    {
        private Stage _stage;
        private IStageReder _stageRender;
        private HeroController _heroController;

        public GameController(Stage stage, IStageReder stageRender)
        {
            LoadStage(stage);
            _stageRender = stageRender;
        }

        public void LoadStage(Stage stage)
        {
            _stage?.Dispose();
            GC.Collect();
            _stage = stage;
            _heroController = new HeroController(_stage.Hero);
        }

        public void Update(float dt)
        {
            _heroController.Update(dt);
            _stage.Update(dt);
            _stageRender.Render(_stage);
        }

        public void KeyHandler(Keys key, KeyAction action)
        {
            _heroController.KeyHandler(key, action);
        }

        public void Dispose()
        {
        }
    }
}
