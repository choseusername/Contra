using ContraModels.MenuModels;
using ContraViewers.MenuRender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContraControllers.MenuControllers
{
    public abstract class MenuController : IController
    {
        private Menu _menu;
        private IMenuRender _menuRender;

        public MenuController(Menu menu, IMenuRender menuRender)
        {
            _menu = menu;
            _menuRender = menuRender;
        }

        public void Dispose()
        {
        }

        public void Update(float dt)
        {
            _menuRender.Render(_menu);
        }
    }
}
