using NUnit.Framework;
using Moq;
using TesteNetCore.Application.Queries.GetLeads;
using TesteNetCore.Domain.Entities;
using TesteNetCore.Domain.Enum;
using TesteNetCore.Domain.Repository.Interface;
using TesteNetCore.Application.Mapper;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TesteNetCore.Tests.Handlers
{
    [TestFixture]
    public class GetAcceptedLeadsQueryHandlerTests
    {
        [Test]
        public async Task Handle_ReturnsAcceptedLeads()
        {
            // Arrange
            var repositoryMock = new Mock<ILeadRepository>();
            var mapperMock = new Mock<IObjectConverter>();

            var handler = new GetAcceptedLeadsQueryHandler(repositoryMock.Object, mapperMock.Object);

            var request = new GetAcceptedLeadsQuery();

            var acceptedLeads = new List<Lead>
            {
                new Lead { Id = 1, StatusLeadId = LeadStatus.Accepted,},
                new Lead { Id = 2, StatusLeadId = LeadStatus.Accepted,}
            };

            repositoryMock.Setup(repo => repo.GetLeads()).ReturnsAsync(acceptedLeads);
            mapperMock.Setup(mapper => mapper.Map<List<GetAcceptedLeadsViewModel>>(It.IsAny<List<Lead>>())).Returns(new List<GetAcceptedLeadsViewModel>
            {
                new GetAcceptedLeadsViewModel { Id = 1, StatusLeadId = LeadStatus.Accepted, },
                new GetAcceptedLeadsViewModel { Id = 2, StatusLeadId = LeadStatus.Accepted,}
            });

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

    }
}
