using AutoFixture;
using FluentAssertions;
using InfoCollectorAPI.BSONModels;
using InfoCollectorAPI.Controllers;
using InfoCollectorAPI.Models;
using InfoCollectorAPI.MongoDB;
using Moq;
using Moq.AutoMock;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace InfoCollectorApi.Tests
{
    public class ComputerControllerTests
    {

        private readonly Fixture _fixture;
        private readonly AutoMocker _autoMocker;

        private readonly ComputersController _computersController;


        public ComputerControllerTests()
        {
            _fixture = new Fixture();
            _autoMocker = new AutoMocker(MockBehavior.Strict);

            _computersController = _autoMocker.CreateInstance<ComputersController>();
        }

        [Fact]
        public void ComputersController_GetAllComputers_ReturnsResult()
        {
            // Arrange

            var computers = _fixture.Build<Computer>()
                .Without(_ => _.Id)
                .CreateMany(5)
                .ToList();

            var models = computers.Select(computer => new ComputerModel
            {
                Id = computer.Id.ToString(),
                Hostname = computer.Hostname,
                MACAddress = computer.MACAddress,
                MACAddressWiFi = computer.MACAddressWiFi,
                LastChange = computer.LastChange,
                LastMassage = computer.LastMassage,
            });

            _autoMocker.GetMock<IMongoRepository<Computer>>()
                .Setup(_ => _.FilterBy(x => true))
                .Returns(computers);

            // Act
            var result = _computersController.GetAllComputers();

            //Assert
            result.Should().BeEquivalentTo(models);

        }
    }
}
