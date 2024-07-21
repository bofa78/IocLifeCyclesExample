using FluentAssertions;
using IocLifeCyclesExample.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;

namespace IocLifeCyclesExample.Tests
{
    public class IIocLifeCyclesExampleServiceTests
    {
        [Test]
        public void GetGuids_ShouldReturnCorrectGuids()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<Services.IocLifeCyclesExampleService>>();

            var scopedServiceAMock = new Mock<ILifeCycleService>();
            var scopedServiceBMock = new Mock<ILifeCycleService>();
            var singletonServiceAMock = new Mock<ILifeCycleService>();
            var singletonServiceBMock = new Mock<ILifeCycleService>();
            var transientServiceAMock = new Mock<ILifeCycleService>();
            var transientServiceBMock = new Mock<ILifeCycleService>();

            var guidScoped = Guid.NewGuid();
            var guidSigleton = Guid.NewGuid();
            var guidTransientA = Guid.NewGuid();
            var guidTransientB = Guid.NewGuid();

            scopedServiceAMock.Setup(s => s.GetGuid()).Returns(guidScoped);
            scopedServiceBMock.Setup(s => s.GetGuid()).Returns(guidScoped);
            singletonServiceAMock.Setup(s => s.GetGuid()).Returns(guidSigleton);
            singletonServiceBMock.Setup(s => s.GetGuid()).Returns(guidSigleton);
            transientServiceAMock.Setup(s => s.GetGuid()).Returns(guidTransientA);
            transientServiceBMock.Setup(s => s.GetGuid()).Returns(guidTransientB);

            var service = new Services.IocLifeCyclesExampleService(
                loggerMock.Object,
                scopedServiceAMock.Object,
                scopedServiceBMock.Object,
                singletonServiceAMock.Object,
                singletonServiceBMock.Object,
                transientServiceAMock.Object,
                transientServiceBMock.Object);

            // Act
            var result = service.GetGuids();

            // Assert
            var expectedServices = new Dictionary<string, Guid>
            {
                { "scopedServiceA", guidScoped },
                { "scopedServiceB", guidScoped },
                { "singletonServiceA",guidSigleton },
                { "singletonServiceB", guidSigleton },
                { "transientServiceA", guidTransientA },
                { "transientServiceB", guidTransientB }
            };
            result.Services.Count().Should().Be(expectedServices.Count());
            result.Services.Should().BeEquivalentTo(expectedServices);

            foreach (var expectedService in expectedServices)
            {
                result.Services.ContainsKey(expectedService.Key).Should().BeTrue();
                result.Services[expectedService.Key].Should().Be(expectedService.Value);
            }
        }
    }
}