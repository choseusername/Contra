using ContraViewers.MenuRender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContraControllers.MenuControllers
{
    public class WindowsFormsMenuController : MenuController
    {
        private Control _control;

        public WindowsFormsMenuController(Control control, ContraModels.MenuModels.Menu menu, IMenuRender menuRender) : base(menu, menuRender)
        {
            _control = control;
        }
    }
}
