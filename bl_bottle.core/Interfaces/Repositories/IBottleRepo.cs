using FlaschenpostModels.Models;

namespace FlaschenpostModels.Interfaces.Repositories
{
    public interface IBottleRepo
    {
        /// <summary>
        /// returns the most expensive beer
        /// </summary>
        List<Beer> GetMostExpensiveBeer();
        
        /// <summary>
        /// returns the cheapest beer
        /// </summary>
        List<Beer> GetCheapestBeer();
        /// <summary>
        /// returns the beverages with the exact price
        /// </summary>
        List<Beer> getBeersByExactPrice(double Preis);
        
        /// <summary>
        /// Get Beverages with the most amount of bottles
        /// </summary>
        Article GetMostbootledBeer();

        /// <summary>
        /// Zwinkersmiley
        /// </summary>
        public Beer GetBestBeer();
    }
}
