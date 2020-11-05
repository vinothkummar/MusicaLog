using Core.Common.Contracts;
using Core.Common.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musicalog.Data
{
    [Export(typeof(IGenericRepositoryFactory))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GenericRepositoryFactory : IGenericRepositoryFactory
    {
        public T GetGenericRepository<T>() where T : IGenericRepository
        {
            return ObjectBase.Container.GetExportedValue<T>();
        }
    }
}
