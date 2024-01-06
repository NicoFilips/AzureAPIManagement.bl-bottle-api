using Microsoft.AspNetCore.Mvc;
using FlaschenPostAPI.Repo;
using FlaschenpostModels.Models;

namespace FlaschenPostAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeerController : Controller
    {
        [HttpGet]
        [Route("TeuerstesBier")]
        public List<Beer> GetTeuerstesBier()
        {
            FlaschenpostGetRepo Repo = new FlaschenpostGetRepo();
            //return Repo.GetMostExpensiveBeer();
            return Repo.GetAllBeer();
        }

        [HttpGet]
        [Route("BilligstesBier")]
        public List<Beer> GetBilligstesBier()
        {
            FlaschenpostGetRepo Repo = new FlaschenpostGetRepo();
            return Repo.GetCheapestBeer();
        }

        //Auf Parameter zwecks Requesthandling verzichtet
        [HttpGet]
        [Route("BeerWithPrice17_99")]
        public IEnumerable<Beer> GetBeersbyPrice()
        {
            FlaschenpostGetRepo Repo = new FlaschenpostGetRepo();
            return Repo.GetBeersByPrice(17.99);
        }

        [HttpGet]
        [Route("MostBottledBeer")]
        public Article GetBeersWithMostBottles()
        {
            FlaschenpostGetRepo Repo = new FlaschenpostGetRepo();
            return Repo.GetMostbootledBeer();
        }
    }
}
