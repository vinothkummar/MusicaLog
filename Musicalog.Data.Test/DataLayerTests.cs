using Core.Common.Contracts;
using Core.Common.Core;
using Core.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Musicalog.Business.Bootstrapper;
using Musicalog.Business.Entities;
using Musicalog.Data.Contracts;
using System.Collections.Generic;
using System.ComponentModel.Composition;


namespace Musicalog.Data.Test
{
    [TestClass]
    public class DataLayerTests
    {
        [TestInitialize]
        public void Initialize()
        {
            ObjectBase.Container = MEFLoader.Init();
        }

        [TestMethod]
        public void test_respository_factory_usage()
        {
            var factoryTest = new RepositoryFactoryTestClass();

            var albums = factoryTest.GetAlbums();

            Assert.IsTrue(albums != null);
        }


    }

    public class RepositoryTestClass
    {
        public RepositoryTestClass()
        {
            ObjectBase.Container.SatisfyImportsOnce(this);
        }


        [Import]
        IAlbumRepository _albumRepository;

        public RepositoryTestClass(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public IEnumerable<Album> GetAlbums()
        {
            IEnumerable<Album> albums = _albumRepository.Get();

            return albums;
        }

    }

    public class RepositoryFactoryTestClass
    {
        public RepositoryFactoryTestClass()
        {
            ObjectBase.Container.SatisfyImportsOnce(this);
        }

        [Import]
        IGenericRepositoryFactory _genericRepositoryFactory;

        public RepositoryFactoryTestClass(IGenericRepositoryFactory genericRepositoryFactory)
        {
            _genericRepositoryFactory = genericRepositoryFactory;    
        }
        
        public IEnumerable<Album> GetAlbums()
        {
            IAlbumRepository albumRepository = _genericRepositoryFactory.GetGenericRepository<IAlbumRepository>();

            return albumRepository.Get();
        }
    }
}
