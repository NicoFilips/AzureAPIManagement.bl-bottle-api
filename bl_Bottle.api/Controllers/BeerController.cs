using Microsoft.AspNetCore.Mvc;
using FlaschenPostAPI.Repo;
using FlaschenpostModels.Interfaces.Repositories;
using FlaschenpostModels.Models;

namespace FlaschenPostAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeerController : Controller
    {
        private IBottleRepo _bottleRepo { get; set; }
        public BeerController(IBottleRepo bottleRepo)
        {
            _bottleRepo = bottleRepo;
        }
        
        [HttpGet]
        [Route("TeuerstesBier")]
        public List<Beer> GetTeuerstesBier()
        {
            return _bottleRepo.GetMostExpensiveBeer();
        }

        [HttpGet]
        [Route("BilligstesBier")]
        public List<Beer> GetBilligstesBier()
        {
            return _bottleRepo.GetCheapestBeer();
        }

        //Auf Parameter zwecks Requesthandling verzichtet
        [HttpGet]
        [Route("BeerWithPrice17_99")]
        public IEnumerable<Beer> GetBeersbyPrice()
        {
            return _bottleRepo.getBeersByExactPrice(17.99);
        }

        [HttpGet]
        [Route("MostBottledBeer")]
        public Article GetBeersWithMostBottles()
        {
            return _bottleRepo.GetMostbootledBeer();
        }
    }
}
