using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.Mapping
{
    public interface ICommandMap
    {
        ICommand  GetCommand(int id);
    }
}
