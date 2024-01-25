using NUnit.Framework;
using Moq;
using TesteNetCore.Application.Queries.GetLeads;
using TesteNetCore.Domain.Entities;
using TesteNetCore.Domain.Enum;
using TesteNetCore.Domain.Repository.Interface;
using TesteNetCore.Application.Mapper;
namespace TesteNetCore.Tests.Handlers
{
    [TestFixture]
    public class GetLeadsQueryHandlerTests
    {
        [Test]
        public async Task Handle_ReturnsPendingLeads()
        {
            // Arrange
            Mock<ILeadRepository> repositoryMock = new Mock<ILeadRepository>();
            Mock<IObjectConverter> mapperMock = new Mock<IObjectConverter>();

            GetLeadsQueryHandler handler = new GetLeadsQueryHandler(repositoryMock.Object, mapperMock.Object);

            GetLeadsQuery request = new GetLeadsQuery();

            List<Lead> pendingLeads = new List<Lead>
            {
                new Lead { Id = 1, StatusLeadId = LeadStatus.Pending, },
                new Lead { Id = 2, StatusLeadId = LeadStatus.Pending,  }
            };

            repositoryMock.Setup(repo => repo.GetLeads()).ReturnsAsync(pendingLeads);
            mapperMock.Setup(mapper => mapper.Map<List<GetLeadsViewModel>>(It.IsAny<List<Lead>>())).Returns(new List<GetLeadsViewModel>
            {
                new GetLeadsViewModel { Id = 1, StatusLeadId = LeadStatus.Pending, },
                new GetLeadsViewModel { Id = 2, StatusLeadId = LeadStatus.Pending, }
            });

            // Act
            List<GetLeadsViewModel> result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

    }
}
