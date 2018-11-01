using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContraControllers
{
    public interface IController : IDisposable
    {
        void Update(float dt);
    }
}
