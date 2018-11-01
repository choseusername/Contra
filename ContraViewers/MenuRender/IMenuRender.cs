using ContraModels.MenuModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContraViewers.MenuRender
{
    public interface IMenuRender
    {
        void Render(Menu menu);
    }
}
