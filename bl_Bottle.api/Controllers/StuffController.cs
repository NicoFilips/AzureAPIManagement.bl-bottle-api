using FlaschenPostAPI.Repo;
using Microsoft.AspNetCore.Mvc;

namespace FlaschenPostAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StuffController : Controller
    {
            [HttpGet(Name = "GetStuff")]
            public List<Beer> GetStuff()
            {
                BottleRepo Repo = BottleRepo.Instance;
                return Repo.GetMostExpensiveBeer();
            }
    }
}
