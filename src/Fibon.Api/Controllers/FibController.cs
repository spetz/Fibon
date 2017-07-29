using System.Threading.Tasks;
using Fibon.Messages;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace Fibon.Api.Controllers
{
    [Route("[controller]")]
    public class FibController : Controller
    {
        private readonly IBusClient _client;
        private readonly IRepository _repo;

        public FibController(IBusClient client,
            IRepository repo)
        {
            _client = client;
            _repo = repo;
        }

        [HttpGet("{number}")]
        public IActionResult Get(int number)
        {
            int? result = _repo.Get(number);
            if (result.HasValue)
            {
                return Content(result.ToString());
            }

            return Content("Not ready...");
        }

        [HttpPost("{number}")]
        public async Task<IActionResult> Post(int number)
        {
            int? result = _repo.Get(number);
            if (!result.HasValue)
            {
                await _client.PublishAsync(
                    new CalculateValueCommand
                    {
                        Number = number
                    });
            }

            return Accepted($"fib/{number}", null);
        }
    }
}
