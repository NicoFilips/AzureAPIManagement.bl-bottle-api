using FlaschenPostAPI.Util;
using FlaschenpostModels.Interfaces.Repositories;
using FlaschenpostModels.Models;

#nullable disable

namespace FlaschenPostAPI.Repo
{
    public class BottleRepo : IBottleRepo
    {
        private IBottleUtil _bottleUtil { get; set; }
        public BottleRepo(IBottleUtil bottleUtil)
        {
            _bottleUtil = bottleUtil;
        }

        public List<Beer> GetCheapestBeer()
        {
            var listOfBeers = _bottleUtil.GetBeerData();

            // Finden des niedrigsten Preises in allen Angeboten
            var minPrice = listOfBeers
                .SelectMany(beer => beer.Offers)
                .Min(offer => offer.price);

            // Filtern der Biere, die Angebote mit dem niedrigsten Preis haben
            return listOfBeers
                .Where(beer => beer.Offers.Any(offer => offer.price == minPrice))
                .ToList();
        }
        
        public List<Beer> GetAllBeer()
        {
            return _bottleUtil.GetBeerData();
        }
        
        public List<Beer> GetBeersByExactPrice(double price)
        {
            var listOfBeers = _bottleUtil.GetBeerData();
            
            var beersWithExactPrice = listOfBeers
                .Where(beer => beer.Offers.Any(offer => offer.price == price))
                .ToList();

            return beersWithExactPrice;
        }

        public Article GetMostBottledBeer()
        {
            var listOfBeers = _bottleUtil.GetBeerData();
            
            return listOfBeers
                .SelectMany(beer => beer.Offers, (beer, offer) => new { Beer = beer, Offer = offer })
                .OrderByDescending(x => _bottleUtil.GetAmountBottles(x.Offer.pricePerUnitText))
                .Select(x => x.Offer)
                .FirstOrDefault();
        }
        
        public List<Beer> GetMostExpensiveBeer()
        {
            var listOfBeers = _bottleUtil.GetBeerData();
            
            var maxPrice = listOfBeers
                .SelectMany(beer => beer.Offers)
                .Max(offer => offer.price);
            
            return listOfBeers
                .Where(beer => beer.Offers.Any(offer => offer.price == maxPrice))
                .ToList();
        }
        
        public Beer GetBestBeer()
        {
            //Note: this is unbiased and objective (o^.^)o
            return _bottleUtil.GetBeerData().Where(Beer => Beer.Id == 70).FirstOrDefault();
        }
    }
}
