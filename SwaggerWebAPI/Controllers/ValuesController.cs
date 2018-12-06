using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SwaggerWebAPI.Models;

namespace SwaggerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// Gets values from the ValuesController
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// <code>GET api/values</code>
        /// </remarks>
        /// <returns>A list of string values</returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Gets an Item object
        /// <remarks>
        /// Sample request:
        /// <code>GET api/values/5</code>
        /// </remarks>
        /// </summary>
        /// <param name="id">An integer value</param>
        /// <returns>An Item with the entered integer value</returns>
        /// <response code="200">If the entered value is ok</response>
        /// <response code="400">If the entered value is negative</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<Item> Get(int id)
        {
            if (0 > id)
            {
                return BadRequest();
            }
            else
            {
                var item = new Item { Id = id, Name = $"Item {id}" };
                return item;
            }            
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
