using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TestSuite
{
    public class RestCallContentResult<TContent> where TContent : class
    {
        public HttpStatusCode Status { get; set; }
        public HttpResponseHeaders Headers { get; set; }
        public TContent Content { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }
    }
}
