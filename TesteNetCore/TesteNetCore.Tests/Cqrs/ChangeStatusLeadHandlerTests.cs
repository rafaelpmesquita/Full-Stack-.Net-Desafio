﻿using Moq;
using NUnit.Framework;
using TesteNetCore.Application.Commands.ChangeStatus;
using TesteNetCore.Application.Mapper;
using TesteNetCore.Domain.Entities;
using TesteNetCore.Domain.Enum;
using TesteNetCore.Domain.Repository.Interface;

namespace TesteNetCore.Tests.Cqrs
{
    [TestFixture]
    public class ChangeStatusLeadHandlerTests
    {
        [Test]
        public async Task Handle_ValidCommand_UpdatesLeadStatus()
        {
            // Arrange
            Mock<ILeadRepository> leadRepositoryMock = new Mock<ILeadRepository>();
            Mock<IObjectConverter> mapperMock = new Mock<IObjectConverter>();

            ChangeStatusLeadHandler handler = new ChangeStatusLeadHandler(leadRepositoryMock.Object, mapperMock.Object);

            ChangeStatusLeadCommand request = new ChangeStatusLeadCommand("John", DateTime.Now, "Suburb", "Category", "Description", 600, 1);

            Lead lead = new Lead
            {   
                Id = 1,
                ContactFirstName = "John",
                DateCreated = DateTime.Now,
                Suburb = "Suburb",
                Category = "Category",
                Description = "Description",
                Price = 600,
                StatusLeadId = LeadStatus.Pending
            };

            leadRepositoryMock.Setup(repo => repo.GetLeads()).ReturnsAsync(new List<Lead> { lead });
            leadRepositoryMock.Setup(repo => repo.UpdateLead(It.IsAny<Lead>())).ReturnsAsync(1);

            // Act
            await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.AreEqual(LeadStatus.Accepted, lead.StatusLeadId);
            Assert.AreEqual(540, lead.Price);
        }

    }
}
