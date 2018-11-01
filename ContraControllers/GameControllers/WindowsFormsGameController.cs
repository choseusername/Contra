using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContraModels.StageModels.Stages;
using ContraViewers;
using ContraViewers.StageRender;

namespace ContraControllers.GameControllers
{
    public class WindowsFormsGameController : GameController
    {
        private Control _control;

        public WindowsFormsGameController(Control control, Stage stage, IStageReder stageRender) : base(stage, stageRender)
        {
            _control = control;
            _control.KeyDown += _control_KeyDown;
            _control.KeyUp += _control_KeyUp;
        }

        private void _control_KeyUp(object sender, KeyEventArgs e)
        {
            KeyHandler(e.KeyCode, KeyAction.Released);
        }

        private void _control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                LoadStage(new Stage7_Hangar());
            }

            if (e.KeyCode == Keys.F6)
            {
                LoadStage(new Stage1_Jungle());
            }

            if (e.KeyCode == Keys.F7)
            {
                LoadStage(new Stage8_AliensLair());
            }

            KeyHandler(e.KeyCode, KeyAction.Pressed);
        }
    }
}
