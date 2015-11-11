using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Transactions;
using Common.DataContracts.v1;
using FluentAssertions;
using RestfulEndpoints;
using TestSuite;
using TestSuite.Attributes;

namespace SampleTests
{
    [TestClass]
    public class SamplesTests
    {
        private TransactionScope _scope;

        [Test]
        public async Task CallingGetAllEndpointReturnsOk()
        {
            // Arrange
            var uri = new Uri("http://localhost:36146/v1/Samples");

            // Act
            var result = await RestCall.CallGetAsync<IEnumerable<GetItemList>>(uri);

            // Assert
            result.Status.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public async Task CallingGetAllEndPointReturnsOkButFailAnyway()
        {
            // Arrange
            const string uri = "${server}/v1/Samples";

            // Act
            var result = await RestCall.CallGetAsync<IEnumerable<GetItemList>>(uri);

            // Assert
            result.Status.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public async Task CallingBySingleEndpointReturnsOk()
        {
            // Arrange
            var uri = new Uri("http://localhost:36146/v1/Samples/1");

            // Act
            var result = await RestCall.CallGetAsync<GetItem>(uri);

            // Assert
            result.Status.Should().Be(HttpStatusCode.OK);
        }
        
        [Test]
        public async Task CallingPostReturnsCreated()
        {
            // Arrange
            var uri = new Uri("http://localhost:36146/v1/Samples");
            var content = new PostItem();

            // Act
            var result = await RestCall.CallPostAsync<GetItem, PostItem>(uri, content);

            // Assert
            result.Status.Should().Be(HttpStatusCode.Created);
        }

        [Test]
        public async Task CallingPutReturnsOk()
        {
            // Arrange
            var uri = new Uri("http://localhost:36146/v1/Samples/1");
            var content = new PutItem();

            // Act
            var result = await RestCall.CallPutAsync<GetItem, PutItem>(uri, content);

            // Assert
            result.Status.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public async Task CallingDeleteReturnsOk()
        {
            // Arrange
            var uri = new Uri("http://localhost:36146/v1/Samples/1");

            // Act
            var result = await RestCall.CallDeleteAsync(uri);

            // Assert
            result.Status.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public async Task CallingOptionsReturnsOk()
        {
            // Arrange
            var uri = new Uri("http://localhost:36146/v1/Samples");

            // Act
            var result = await RestCall.CallOptionsAsync(uri);

            // Assert
            result.Status.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public async Task CallingOptionsByIdReturnsOk()
        {
            // Arrange
            var uri = new Uri("http://localhost:36146/v1/Samples/1");

            // Act
            var result = await RestCall.CallOptionsAsync(uri);

            // Assert
            result.Status.Should().Be(HttpStatusCode.OK);
        }

        [PreTest]
        public async Task PreTestActions()
        {
            _scope = new TransactionScope();
        }

        [PostTest]
        public async Task PostTestActions()
        {
            _scope.Dispose();
        }
    }
}
