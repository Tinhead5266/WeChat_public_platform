using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeChatPublicPlatform.Controllers
{
    /// <summary>
    /// 包含读写的api控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ReadWriteAPIController : ControllerBase
    {
        // GET: api/ReadWriteAPI
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ReadWriteAPI/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ReadWriteAPI
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ReadWriteAPI/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
