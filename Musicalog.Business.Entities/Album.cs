using Core.Common.Contracts;
using Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Musicalog.Business.Entities
{
    [DataContract]
    public class Album : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int AlbumId { get; set; }
        [DataMember]
        public string AlbumName { get; set; }
        [DataMember]
        public string Artist { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public int Stock { get; set; }
        [DataMember]
        public bool EditAlbumButton { get; set; }
        [DataMember]
        public bool RemoveCatalogButton { get; set; }
        public int EntityId {
            get { return AlbumId;} set { AlbumId = value; } 
        }
    }
}
