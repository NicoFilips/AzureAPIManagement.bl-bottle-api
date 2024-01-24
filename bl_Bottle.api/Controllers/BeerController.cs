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
        [Route("MostExpensiveBeverage")]
        public List<Beer> GetMostExpensiveBeverage()
        {
            return _bottleRepo.GetMostExpensiveBeer();
        }

        [HttpGet]
        [Route("CheapestBeverage")]
        public List<Beer> GetCheapestBeverage()
        {
            return _bottleRepo.GetCheapestBeer();
        }
        
        [HttpGet]
        [Route("BeverageByPrice/{price}")]
        public IEnumerable<Beer> GetBeersbyPrice(double price)
        {
            return _bottleRepo.GetBeersByExactPrice(price);
        }

        [HttpGet]
        [Route("MostBottledBeverage")]
        public Article GetBeersWithMostBottles()
        {
            return _bottleRepo.GetMostBottledBeer();
        }
        
        [HttpGet]
        [Route("GetBestBeverage")]
        public Beer GetBestBeverage()
        {
            return _bottleRepo.GetBestBeer();
        }
    }
}
