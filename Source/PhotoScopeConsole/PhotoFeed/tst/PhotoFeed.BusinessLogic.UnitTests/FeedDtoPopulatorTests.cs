using System.Collections.Generic;
using NUnit.Framework;
using PhotoScope.Core.DTOModels;

namespace PhotoFeed.BusinessLogic.UnitTests
{
    public class FeedDtoPopulatorTests
    {
        private static IEnumerable<TestCaseData> AddToFeedTestData
        {
            get
            {
                yield return new TestCaseData(1, new List<FeedItem>{new FeedItem{ItemId = "FeedItem1"}});
                yield return new TestCaseData(2, new List<FeedItem>
                {
                        new FeedItem  {ItemId = "FeedItem1"}, 
                        new FeedItem { ItemId = "FeedItem2" }
                });

                yield return new TestCaseData(3, new List<FeedItem>
                {
                    new FeedItem { ItemId = "FeedItem1" },
                    new FeedItem { ItemId = "FeedItem2" },
                    new FeedItem { ItemId = "FeedItem3" }
                });
                yield return new TestCaseData(0,new List<FeedItem>
                {
                    null,null,null
                });
                yield return new TestCaseData(5, new List<FeedItem>
                {
                    new FeedItem { ItemId = "FeedItem1" },
                    new FeedItem { ItemId = "FeedItem2" },
                    new FeedItem { ItemId = "FeedItem3" },
                    new FeedItem { ItemId = "FeedItem5" },
                    new FeedItem { ItemId = "FeedItem4" }
                });
                yield return new TestCaseData(0, null);
            }
        }

        [Test]
        public void TestInitialFeedDtoProperty()
        {
            //Arrange & Act
            var feedDtoPopulator = new FeedDtoPopulator();

            //Assert
            Assert.IsNotNull(feedDtoPopulator.FeedDto);
            Assert.IsNotNull(feedDtoPopulator.FeedDto.FeedItems);
        }


        [Test]
        public void TestGetDtoModel()
        {
            //Arrange
            var feedDtoPopulator = new FeedDtoPopulator();
            
            feedDtoPopulator.FeedDto.FeedItems.Add(new FeedItem{ ItemId = "Test"});

            //Act
            var actualModel = feedDtoPopulator.GetDtoModel();

            //Assert
            Assert.IsNotNull(actualModel);
            Assert.AreEqual(1, actualModel.FeedItems.Count);
            Assert.AreEqual("Test", actualModel.FeedItems[0].ItemId);
        }

        [Test]
        public void TestClearFeed()
        {
            //Arrange
            var feedDtoPopulator = new FeedDtoPopulator();
            
            feedDtoPopulator.FeedDto.FeedItems.Add(new FeedItem { ItemId = "Test" });
            feedDtoPopulator.FeedDto.FeedItems.Add(new FeedItem { ItemId = "Test1" });
            feedDtoPopulator.FeedDto.FeedItems.Add(new FeedItem { ItemId = "Test2" });

            var actualModel = feedDtoPopulator.FeedDto;

            Assert.IsNotNull(actualModel);
            Assert.AreEqual(3, actualModel.FeedItems.Count);

            //Act
            feedDtoPopulator.ClearFeed();

            actualModel = feedDtoPopulator.FeedDto;

            //Assert
            Assert.IsNotNull(actualModel);
            Assert.AreEqual(0,actualModel.FeedItems.Count);
        }

        [TestCaseSource(nameof(AddToFeedTestData))]
        public void TestAddToFeed(int expectedCount,IList<FeedItem> expectedFeedItems)
        {
            //Arrange
            var feedDtoPopulator = new FeedDtoPopulator();

            //Act
            feedDtoPopulator.AddToFeed(expectedFeedItems);
            var actualModel = feedDtoPopulator.FeedDto;
            var actualCount = actualModel.FeedItems.Count;

            //Assert
            Assert.AreEqual(expectedCount,actualCount);

            for (int i = 0; i < actualCount; i++)
            {
                Assert.AreEqual(expectedFeedItems[i].ItemId, actualModel.FeedItems[i].ItemId);
            }

        }
    }
}
