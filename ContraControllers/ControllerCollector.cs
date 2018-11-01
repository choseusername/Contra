using ContraControllers.GameControllers;
using ContraControllers.MenuControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContraControllers
{
    public class ControllerCollector : IController
    {
        private IController _menuController;
        private IController _gameController;

        private IController _currentController;

        public ControllerCollector(IController menuController, IController gameController)
        {
            _menuController = menuController;
            _gameController = gameController;
        }

        public void SetupMenuController()
        {
            _currentController = _menuController;
        }

        public void SetupGameController()
        {
            _currentController = _gameController;
        }

        public void Dispose()
        {
        }

        public void Update(float dt)
        {
            _currentController.Update(dt);
        }
    }
}
