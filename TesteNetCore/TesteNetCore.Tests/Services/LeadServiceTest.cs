using Moq;
using NUnit.Framework;
using TesteNetCore.API.Service;
using TesteNetCore.Application.Mapper;
using TesteNetCore.Domain.Entities;
using TesteNetCore.Domain.Enum;
using TesteNetCore.Domain.Repository.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TesteNetCore.Tests
{
    [TestFixture]
    public class LeadServiceTest
    {
        [Test]
        public async Task GetPendingLeads_ShouldReturnPendingLeads()
        {
            // Arrange
            var leadRepositoryMock = new Mock<ILeadRepository>();
            var objectConverterMock = new Mock<IObjectConverter>();

            var leadService = new LeadService(leadRepositoryMock.Object, objectConverterMock.Object);

            var leads = new List<Lead>
            {
                new Lead { Id = 1, StatusLeadId = LeadStatus.Pending },
                new Lead { Id = 2, StatusLeadId = LeadStatus.Accepted },
               
            };

            leadRepositoryMock.Setup(repo => repo.GetLeads()).ReturnsAsync(leads);
            objectConverterMock.Setup(converter => converter.Map<List<LeadIncompleteModel>>(It.IsAny<List<Lead>>()))
                .Returns((List<Lead> input) => input.Select(l => new LeadIncompleteModel { Id = l.Id }).ToList());

            // Act
            var result = await leadService.GetPendingLeads();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result[0].Id);
        }

        [Test]
        public async Task GetAcceptedLeads_ShouldReturnAcceptedLeads()
        {
            // Arrange
            var leadRepositoryMock = new Mock<ILeadRepository>();
            var objectConverterMock = new Mock<IObjectConverter>();

            var leadService = new LeadService(leadRepositoryMock.Object, objectConverterMock.Object);

            var leads = new List<Lead>
            {
                new Lead { Id = 1, StatusLeadId = LeadStatus.Pending },
                new Lead { Id = 2, StatusLeadId = LeadStatus.Accepted },
               
            };

            leadRepositoryMock.Setup(repo => repo.GetLeads()).ReturnsAsync(leads);

            // Act
            var result = await leadService.GetAcceptedLeads();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(2, result[0].Id);
        }

        [Test]
        public async Task ChangeLeadStatus_ShouldUpdateLeadStatus()
        {
            // Arrange
            var leadRepositoryMock = new Mock<ILeadRepository>();
            var objectConverterMock = new Mock<IObjectConverter>();

            var leadService = new LeadService(leadRepositoryMock.Object, objectConverterMock.Object);

            var lead = new Lead
            {
                Id = 1,
                StatusLeadId = LeadStatus.Pending,
                Price = 600 
            };

            var request = new LeadIncompleteModel
            {
                Id = 1,
                StatusLeadId = LeadStatus.Accepted
            };

            leadRepositoryMock.Setup(repo => repo.GetLeads()).ReturnsAsync(new List<Lead> { lead });
            leadRepositoryMock.Setup(repo => repo.UpdateLead(It.IsAny<Lead>())).ReturnsAsync(1);

            // Act
            var result = await leadService.ChangeLeadStatus(request);

            // Assert
            Assert.AreEqual(1, result);
            Assert.AreEqual(LeadStatus.Accepted, lead.StatusLeadId);
            Assert.AreEqual(540, lead.Price);
        }
    }
}
