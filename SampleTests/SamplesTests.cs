using System;
using System.Net;
using System.Threading.Tasks;
using Common.DataContracts.v1;
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

        [Test]
        public async Task CallingPostReturnsCreated()
        {
            // Arrange
            var uri = new Uri("http://localhost:36146/v1/Samples");
            var content = new PostItem();

            // Act
            var result = await RestCall.CallPostAsync(uri, content);

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Test]
        public async Task CallingPutReturnsOk()
        {
            // Arrange
            var uri = new Uri("http://localhost:36146/v1/Samples/1");
            var content = new PutItem();

            // Act
            var result = await RestCall.CallPutAsync(uri, content);

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
