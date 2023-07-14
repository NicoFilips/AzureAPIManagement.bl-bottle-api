using FlaschenpostModels.Models;

namespace FlaschenpostModels.Interfaces.Repositories
{
    public interface IBierGetRepo
    {
        List<Beer> GetMostExpensiveBeer();
        List<Beer> GetCheapestBeer();
        List<Beer> GetBeersByPrice(double Preis);
        Article GetMostbootledBeer();
    }
}
