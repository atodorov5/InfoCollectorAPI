using AutoFixture;
using FluentAssertions;
using InfoCollectorAPI.BSONModels;
using InfoCollectorAPI.Controllers;
using InfoCollectorAPI.Models;
using InfoCollectorAPI.MongoDB;
using MongoDB.Bson;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InfoCollectorApi.Tests
{
    public class HistoryControllerTests
    {
        private readonly Fixture _fixture;
        private readonly AutoMocker _autoMocker;

        private readonly HistoryController _historyController;


        public HistoryControllerTests()
        {
            _fixture = new Fixture();
            _autoMocker = new AutoMocker(MockBehavior.Strict);

            _historyController = _autoMocker.CreateInstance<HistoryController>();
        }

        [Fact]
        public void ComputersController_GetAllComputers_ReturnsResult()
        {
            // Arrange
            var computer = "63a0761de93091e26d9969e2";
            ObjectId computerId = ObjectId.Parse(computer);

            var history = _fixture.Build<History>()
                .Without(_ => _.Id)
                .With(_ => _.ComputerId, computerId)
                .CreateMany(2)
                .ToList();

            var historyList = new List<HistoryView>
            {
                history.First().ToModel(),
                history.ToList().ElementAt(1).ToModel(),
            };

            _autoMocker.GetMock<IMongoRepository<History>>()
                .Setup(_ => _.FilterBy(x => x.ComputerId == computerId))
                .Returns(history);

            // Act
            var result = _historyController.GetCurrentAndLastHistory(computer);

            //Assert
            result.Should().BeEquivalentTo(historyList);

        }
    }
}

