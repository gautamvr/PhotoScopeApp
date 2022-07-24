using System.Collections.ObjectModel;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using PhotoFeed.Interfaces;
using PhotoScope.Core.DTOModels;
using Rhino.Mocks;

namespace PhotoFeed.BusinessLogic.UnitTests
{
    public class FeedModelProviderTests
    {
        private IFeedDtoPopulator _mockDtoPopulator;
        private IUnityContainer _container;

        [SetUp]
        public void Setup()
        {
            _container = new UnityContainer();
            _mockDtoPopulator = MockRepository.GenerateMock<IFeedDtoPopulator>();
            _container.RegisterInstance(_mockDtoPopulator, new ContainerControlledLifetimeManager());
        }

        [TearDown]
        public void TearDown()
        {
            _mockDtoPopulator = null;
            _container.Dispose();
            _container = null;
        }

        [Test]
        public void TestGetInitialModel_ReturnsTheInitialDtoModelFromPopulator()
        {
            var feedModelProvider = _container.Resolve<FeedModelProvider>();

            Feed initialModel = new Feed()
            {
                FeedItems = new ObservableCollection<FeedItem>()
            };

            _mockDtoPopulator.Expect(x=> x.GetDtoModel()).Return(initialModel);

            var actualModel = feedModelProvider.GetInitialModel();

            Assert.NotNull(feedModelProvider);
            Assert.AreEqual(initialModel,actualModel);
        }
    }
}
