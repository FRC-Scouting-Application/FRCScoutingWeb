using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dbo.Interfaces
{
    public interface IKey<TKey>
    {
        public abstract TKey? Id { get; set; }
    }
}
