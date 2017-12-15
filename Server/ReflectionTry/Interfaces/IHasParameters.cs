using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTry.Interfaces
{
    public interface IHasParameters
    {
        IEnumerable<ParameterInfo> Parameters { get; }
    }
}
