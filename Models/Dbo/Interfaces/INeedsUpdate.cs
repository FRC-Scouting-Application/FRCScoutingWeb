using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dbo.Interfaces
{
    public interface INeedsUpdate<T>
    {
        bool NeedsUpdate(T obj);
    }
}
