﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Api.Controllers
{
    [ApiVersion("1")]
    [ApiVersion("2")]
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/v1/values
        [HttpGet(), MapToApiVersion("1")]
        public ActionResult<IEnumerable<string>> GetV1()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/v2/values
        [HttpGet(), MapToApiVersion("2")]
        public ActionResult<IEnumerable<string>> GetV2()
        {
            return new string[] { "value3", "value4" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
