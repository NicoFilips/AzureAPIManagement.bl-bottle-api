using FlaschenPostAPI.Repo;
using Microsoft.AspNetCore.Mvc;

namespace FlaschenPostAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StuffController : Controller
    {
        private BottleRepo _bottleRepo { get; set; }

        public StuffController(BottleRepo bottleRepo)
        {
            _bottleRepo = bottleRepo;
        }

        [HttpGet(Name = "GetStuff")]
        public List<Beer> GetStuff()
        {
            return _bottleRepo.GetMostExpensiveBeer();
        }
    }
}