using System;
using System.Collections.Generic;
using System.Web.Http;
using TestWebApi.DataContracts.v1;

namespace TestWebApi.Controllers
{
    public class SamplesController : ApiController
    {
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
            return Created(new Uri("v1/samples/1"), new GetItem {Id = 1, Name = "Name1"});
        }

        [HttpPut]
        [Route("v1/Samples/{id}")]
        public IHttpActionResult Put([FromBody] PutItem putItem)
        {
            return Ok(new GetItem {Id = 1, Name = "Name1"});
        }
    }
}
