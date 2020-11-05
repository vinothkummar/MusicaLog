using Musicalog.Business.Entities;
using Musicalog.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musicalog.Data
{
    [Export(typeof(IAlbumRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AlbumRepository : GeneriRepositoryBase<Album>, IAlbumRepository
    {
        protected override Album AddEntity(MusicalogContext entityContext, Album entity)
        {
            return entityContext.AlbumSet.Add(entity);
        }

        protected override IQueryable<Album> GetEntities(MusicalogContext entityContext)
        {
            return entityContext.AlbumSet;
        }

        protected override Album GetEntity(MusicalogContext entityContext, int id)
        {
            return entityContext.AlbumSet.FirstOrDefault(cn => cn.AlbumId == id);
        }

        protected override Album UpdateEntity(MusicalogContext entityContext, Album entity)
        {
            return entityContext.AlbumSet.FirstOrDefault(cn => cn.AlbumId == entity.AlbumId);
        }
    }
}
