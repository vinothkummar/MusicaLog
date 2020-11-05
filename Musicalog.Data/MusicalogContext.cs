using Core.Common.Contracts;
using Musicalog.Business.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Musicalog.Data
{
    public class MusicalogContext : DbContext
    {
        public MusicalogContext() : base("MusicalogContext")
        {

        }
        
        public DbSet<Album> AlbumSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Ignore<PropertyChangedEventHandler>();
            modelBuilder.Ignore<ExtensionDataObject>();
            modelBuilder.Ignore<IIdentifiableEntity>();

            
            modelBuilder.Entity<Album>().HasKey<int>(e => e.AlbumId).Ignore(e => e.EntityId);
           
        }
    }
}
