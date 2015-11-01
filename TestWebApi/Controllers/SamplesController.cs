using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Common.DataContracts.v1;

namespace TestWebApi.Controllers
{
    public class SamplesController : ApiController
    {
        [HttpOptions]
        [Route("v1/Samples")]
        public HttpResponseMessage Options()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Headers.Add("Access-Control-Allow_Methods", "GET, POST");

            return response;
        }

        [HttpOptions]
        [Route("v1/Samples/{id}")]
        public HttpResponseMessage OptionsById()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Headers.Add("Access-Control-Allow_Methods", "GET, PUT, DELETE");

            return response;
        }

        [HttpGet]
        [Route("v1/Samples")]
        public IHttpActionResult Get()
        {
            var samples = new List<GetItemList>
            {
                new GetItemList {Name = "Name1"},
                new GetItemList {Name = "Name2"}
            };
            return Ok(samples);
        }

        [HttpGet]
        [Route("v1/Samples/{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(new GetItem {Id=id, Name = "Name1"});
        }

        [HttpPost]
        [Route("v1/Samples")]
        public IHttpActionResult Post([FromBody] PostItem postItem)
        {
            return Created(new Uri("http://localhost:36146/v1/samples/1"), new GetItem {Id = 1, Name = "Name1"});
        }

        [HttpPut]
        [Route("v1/Samples/{id}")]
        public IHttpActionResult Put([FromBody] PutItem putItem, int id)
        {
            return Ok(new GetItem {Id = id, Name = "Name1"});
        }

        [HttpDelete]
        [Route("v1/Samples/{id}")]
        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
