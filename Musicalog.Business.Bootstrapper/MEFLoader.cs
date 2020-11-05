using Musicalog.Data;
using System.ComponentModel.Composition.Hosting;

namespace Musicalog.Business.Bootstrapper
{
    
    public static class MEFLoader
    {
        public static CompositionContainer Init()
        {
            AggregateCatalog catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(AlbumRepository).Assembly));
          

            CompositionContainer container = new CompositionContainer(catalog);

            return container;
        }

    }
}
