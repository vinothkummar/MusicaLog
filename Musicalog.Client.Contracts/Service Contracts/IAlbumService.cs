using Core.Common.Contracts;
using Core.Common.Exceptions;
using Musicalog.Client.Entities;
using System.ServiceModel;

namespace Musicalog.Client.Contracts
{
    [ServiceContract]
    public interface IAlbumService : IServiceContract
    {
        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        Album GetAlbum(int albumId);

        [OperationContract]
        Album[] GetAllAlbum();

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Album UpdateAlbum(Album album);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteAlbum(int albumId);
    }
}
