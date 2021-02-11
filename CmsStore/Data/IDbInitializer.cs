using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsStore.Data
{
    public interface IDbInitializer
    {
        void Initialize();
    }
}
