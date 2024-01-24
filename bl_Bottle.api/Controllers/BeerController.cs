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
            BottleRepo Repo = new BottleRepo();
            //return Repo.GetMostExpensiveBeer();
            return Repo.GetAllBeer();
        }

        [HttpGet]
        [Route("BilligstesBier")]
        public List<Beer> GetBilligstesBier()
        {
            BottleRepo Repo = new BottleRepo();
            return Repo.GetCheapestBeer();
        }

        //Auf Parameter zwecks Requesthandling verzichtet
        [HttpGet]
        [Route("BeerWithPrice17_99")]
        public IEnumerable<Beer> GetBeersbyPrice()
        {
            BottleRepo Repo = new BottleRepo();
            return Repo.getBeersByExactPrice(17.99);
        }

        [HttpGet]
        [Route("MostBottledBeer")]
        public Article GetBeersWithMostBottles()
        {
            BottleRepo Repo = new BottleRepo();
            return Repo.GetMostbootledBeer();
        }
    }
}
