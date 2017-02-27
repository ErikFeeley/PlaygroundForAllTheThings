using System.Collections.Generic;
using System.Linq;
using EFTestTakeTwo.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EFTestTakeTwo.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IValueRepository _valueRepository;

        public ValuesController(IValueRepository valueRepository)
        {
            _valueRepository = valueRepository;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var myValues = _valueRepository.Get().ToList();

            return Ok(myValues);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
