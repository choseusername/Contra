using ContraControllers;
using ContraControllers.GameControllers;
using ContraControllers.MenuControllers;
using ContraModels;
using ContraModels.StageModels.Stages;
using ContraViewers;
using ContraViewers.MenuRender;
using ContraViewers.StageRender;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContraApplication
{
    public partial class ContraApplication : Form
    {
        private DateTime _prev;
        private DateTime _now;

        private ControllerCollector _controllerCollector;

        private void HandleApplicationIdle(object sender, EventArgs e)
        {
            while (Native.PeekMessage(out Native.MSG message, IntPtr.Zero, 0, 0, 0) == 0)
            {
                _now = DateTime.UtcNow;

                float dt = (float)(_now - _prev).TotalSeconds;
                _prev = _now;

                _controllerCollector.Update(dt);
            }
        }

        private IController CreateMenuController()
        {
            ContraModels.MenuModels.Menu menu = new ContraModels.MenuModels.MainMenu();
            IMenuRender menuRender = new MenuGraphicsRender(this);
            return new WindowsFormsMenuController(this, menu, menuRender);
        }

        private IController CreateGameController()
        {
            Stage stage = new Stage1_Jungle();
            IStageReder stageRender = new StageGraphicsRender(this);
            return new WindowsFormsGameController(this, stage, stageRender);
        }

        public ContraApplication()
        {
            InitializeComponent();

            IController gameController = CreateGameController();
            IController menuController = CreateMenuController();

            _controllerCollector = new ControllerCollector(menuController, gameController);
            _controllerCollector.SetupGameController();

            _prev = DateTime.UtcNow;
            Application.Idle += HandleApplicationIdle;
        }
    }
}
