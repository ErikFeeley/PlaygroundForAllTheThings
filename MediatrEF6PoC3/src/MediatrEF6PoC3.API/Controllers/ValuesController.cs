using System.Threading.Tasks;
using MediatrEF6PoC3.Messages.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediatrEF6PoC3.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(IMediator mediator, ILogger<ValuesController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var myValues = await _mediator.Send(new GetMyValuesQuery());
            var moreValues = await _mediator.Send(new GetMyValuesQuery());
            var someOtherValues = await _mediator.Send(new GetMyValuesQuery());
            var theseAreActuallyAllTheSameValues = await _mediator.Send(new GetMyValuesQuery());

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
