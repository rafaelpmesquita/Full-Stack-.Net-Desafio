using NUnit.Framework;
using Moq;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TesteNetCore.Application.Queries.GetLeads;
using TesteNetCore.Domain.Entities;
using TesteNetCore.Domain.Enum;
using TesteNetCore.Domain.Repository.Interface;
using TesteNetCore.Application.Mapper;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TesteNetCore.Tests.Handlers
{
    [TestFixture]
    public class GetLeadsQueryHandlerTests
    {
        [Test]
        public async Task Handle_ReturnsPendingLeads()
        {
            // Arrange
            var repositoryMock = new Mock<ILeadRepository>();
            var mapperMock = new Mock<IObjectConverter>();

            var handler = new GetLeadsQueryHandler(repositoryMock.Object, mapperMock.Object);

            var request = new GetLeadsQuery();

            var pendingLeads = new List<Lead>
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
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

    }
}
