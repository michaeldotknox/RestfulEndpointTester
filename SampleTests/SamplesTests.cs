using System;
using System.Threading.Tasks;
using FluentAssertions;
using TestSuite;
using TestSuite.Attributes;

namespace SampleTests
{
    [TestClass]
    public class SamplesTests
    {
        [Test]
        public async Task CallingGetAllEndpointReturnsOk()
        {
            // Arrange
            var uri = new Uri("http://localhost:36146/v1/Samples");

            // Act
            var result = await RestCall.CallGetAsync(uri);

            // Assert
            result.IsSuccessStatusCode.Should().BeTrue();
        }

        [Test]
        public async Task CallingGetAllEndPointReturnsOkButFailAnyway()
        {
            // Arrange
            var uri = new Uri("http://localhost:36146/v1/Samples");

            // Act
            var result = await RestCall.CallGetAsync(uri);

            // Assert
            result.IsSuccessStatusCode.Should().BeFalse();
        }
    }
}
