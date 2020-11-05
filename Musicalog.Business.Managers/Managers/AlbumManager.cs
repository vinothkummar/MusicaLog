using Core.Common.Contracts;
using Core.Common.Core;
using Musicalog.Business.Contracts;
using System.ComponentModel.Composition;
using Musicalog.Business.Entities;
using Musicalog.Data.Contracts;
using Core.Common.Exceptions;
using System.ServiceModel;
using System;
using System.Linq;

namespace Musicalog.Business.Managers
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
                    ConcurrencyMode = ConcurrencyMode.Multiple,
                    ReleaseServiceInstanceOnTransactionComplete = false)]
    public class AlbumManager : ManagerBase, IAlbumService
    {
        public AlbumManager()
        {
            
        }

        public AlbumManager(IGenericRepositoryFactory genericRepositoryFactory)
        {
            _genericRepositoryFactory = genericRepositoryFactory;
        }

        [Import]
        IGenericRepositoryFactory _genericRepositoryFactory;

        public Album GetAlbum(int albumId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IAlbumRepository albumRepository = _genericRepositoryFactory.GetGenericRepository<IAlbumRepository>();

                Album albumEntity = albumRepository.Get(albumId).Result;

                if (albumEntity == null)
                {
                    NotFoundException ex
                        = new NotFoundException(string.Format("Album with Id of {0} is not in the database.", albumId));

                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                return albumEntity;
            });
        }

        public Album[] GetAllAlbum()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IAlbumRepository albumRepository = _genericRepositoryFactory.GetGenericRepository<IAlbumRepository>();

                return albumRepository.Get().ToArray();
            });

        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public Album UpdateAlbum(Album album)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IAlbumRepository albumRepository = _genericRepositoryFactory.GetGenericRepository<IAlbumRepository>();

                Album updatedEntity = null;

                if (album.AlbumId == 0)
                    updatedEntity = albumRepository.Create(album).Result;
                else
                    updatedEntity = albumRepository.Update(album).Result;

                return updatedEntity;

            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void DeleteAlbum(int albumId)
        {
            ExecuteFaultHandledOperation(() =>
            {
                IAlbumRepository albumRepository = _genericRepositoryFactory.GetGenericRepository<IAlbumRepository>();

                albumRepository.Delete(albumId);
            });
        }
    }
}
