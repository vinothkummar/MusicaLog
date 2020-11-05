using Core.Common.Exceptions;
using Musicalog.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Musicalog.Business.Contracts
{
    [ServiceContract]
    public interface IAlbumService
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
