using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcher.Model.Repositorys
{
    public interface IErrorReopsitory
    {
        void Creat();
    }

    public class ErrorReopsitory : IErrorReopsitory
    {
        public void Creat()
        {
            throw new NotImplementedException();
        }
    }
}
