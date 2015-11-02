﻿using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TestSuite
{
    public class RestCallNoContentResult
    {
        public HttpStatusCode Status { get; set; }
        public HttpResponseHeaders Headers { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }
    }
}
