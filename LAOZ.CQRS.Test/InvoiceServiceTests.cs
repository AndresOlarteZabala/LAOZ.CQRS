using LAOZ.CQRS.Commands;
using LAOZ.CQRS.Queries;
using LAOZ.CQRS.Repositories.Interfaces;
using LAOZ.CQRS.Services;
using Moq;
using NUnit.Framework;

namespace LAOZ.CQRS.Test
{
    [TestFixture]
    public class InvoiceServiceTests
    {
        private Mock<IQueryRepository<GetInvoiceQuery>>? _mockQueryRepository;
        private Mock<ICommandRepository<CreateInvoiceCommand>>? _mockCommandRepository;
        private IInvoiceService? _invoiceService;

        [SetUp]
        public void SetUp()
        {
            _mockQueryRepository = new Mock<IQueryRepository<GetInvoiceQuery>>();
            _mockCommandRepository = new Mock<ICommandRepository<CreateInvoiceCommand>>();
            _invoiceService = new Services.InvoiceService(_mockQueryRepository.Object, _mockCommandRepository.Object);
        }

        [Test]
        public void CreateInvoice_ShouldCreateInvoiceAndReturnIt()
        {
            // Arrange
            var customerName = "Test Customer";
            var totalAmount = 50.00m;

            var createdInvoiceId = Guid.NewGuid();
            _mockQueryRepository
                .Setup(repo => 
                    repo.GetById(createdInvoiceId))
                .Returns(
                    new GetInvoiceQuery { 
                        InvoiceId = createdInvoiceId, 
                        CustomerName = customerName, 
                        TotalAmount = totalAmount });

            // Act
            var createdInvoice = _invoiceService.CreateInvoice(customerName, totalAmount);

            // Assert
            Assert.That(createdInvoice == null);
            Assert.That(customerName == createdInvoice.CustomerName);
            Assert.That(totalAmount == createdInvoice.TotalAmount);
        }

        [Test]
        public void GetInvoice_ShouldRetrieveInvoiceById()
        {
            // Arrange
            var invoiceId = Guid.NewGuid();
            var expectedInvoice = new GetInvoiceQuery { InvoiceId = invoiceId, CustomerName = "Test Customer", TotalAmount = 75.50m };

            _mockQueryRepository.Setup(repo => repo.GetById(invoiceId)).Returns(expectedInvoice);

            // Act
            var retrievedInvoice = _invoiceService.GetInvoice(invoiceId);

            // Assert
            Assert.That(retrievedInvoice == null);
            Assert.That(expectedInvoice.InvoiceId == retrievedInvoice.InvoiceId);
            Assert.That(expectedInvoice.CustomerName == retrievedInvoice.CustomerName);
            Assert.That(expectedInvoice.TotalAmount == retrievedInvoice.TotalAmount);
        }
    }

}
