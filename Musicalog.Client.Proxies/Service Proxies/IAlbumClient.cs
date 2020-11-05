using Musicalog.Client.Contracts;
using Musicalog.Client.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Musicalog.Client.Proxies
{
    [Export(typeof(IAlbumService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class IAlbumClient : ClientBase<IAlbumService>, IAlbumService
    {
        public void DeleteAlbum(int albumId)
        {
            Channel.DeleteAlbum(albumId);
        }

        public Album GetAlbum(int albumId)
        {
            return Channel.GetAlbum(albumId);
        }

        public Album[] GetAllAlbum()
        {
            return Channel.GetAllAlbum();
        }

        public Album UpdateAlbum(Album album)
        {
            return Channel.UpdateAlbum(album);
        }
    }
}
