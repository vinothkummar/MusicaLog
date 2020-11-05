using Core.Common.Contracts;
using Core.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musicalog.Data
{
    public abstract class GeneriRepositoryBase<T> : GenericRepositoryBase<T, MusicalogContext>
        where T : class, IIdentifiableEntity, new()
    {
    }
}
