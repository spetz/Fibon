using System.Threading.Tasks;
using Fibon.Messages;
using Fibon.Messages.Commands;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace Fibon.Api.Controllers
{
    [Route("[controller]")]
    public class FibonacciController : Controller
    {
        private readonly IBusClient _client;
        private readonly IRepository _repository;

        public FibonacciController(IBusClient client,
            IRepository repository)
        {
            _client = client;
            _repository = repository;
        }

        [HttpGet("{number}")]
        public IActionResult Get(int number)
        {
            int? result = _repository.Get(number);
            if (result.HasValue)
            {
                return Content(result.ToString());
            }

            return Content("Not ready...");
        }

        [HttpPost("{number}")]
        public async Task<IActionResult> Post(int number)
        {
            int? result = _repository.Get(number);
            if (!result.HasValue)
            {
                await _client.PublishAsync(new CalculateValue
                {
                    Number = number
                });
            }

            return Accepted($"fibonacci/{number}", null);
        }
    }
}
