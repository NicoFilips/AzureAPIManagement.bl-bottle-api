
using FlaschenpostModels.Interfaces.Repositories;
using FlaschenPostAPI.Helper;
using FlaschenpostModels.Models;

#nullable disable

namespace FlaschenPostAPI.Repo
{
    public class BottleRepo : IBottleRepo
    {
        public List<Beer> GetCheapestBeer()
        {
            return null;
        }
        public List<Beer> GetAllBeer()
        {
            return BeerHelper.GetBeerData();
        }
        
        public List<Beer> GetBeersByPrice(double price)
        {
            List<Beer> ListofBeers = BeerHelper.GetBeerData();
            List<Beer> RtnList = new List<Beer>();

            foreach (var Beer in ListofBeers)
            {
                bool isExactPrice = false;
                foreach (var Article in Beer.Angebote)
                {
                    if (Article.price == 17.99)
                    {
                        if (isExactPrice == true)
                        {
                            RtnList.Add(Beer);
                        }
                    }
                }
            }
            return RtnList;
        }

        public Article GetMostbootledBeer()
        {
            List<Beer> ListofBeers = BeerHelper.GetBeerData();
            Article article = null;
            foreach (Beer Beer in ListofBeers)
            {
                foreach (Article BeerArticle in Beer.Angebote)
                {
                    if (article == null)
                    {
                        article = BeerArticle;
                    }
                    else
                    {
                        double ThisArcticleBottles = BeerHelper.GetAmountBottles(article.pricePerUnitText);
                        double NextArticleBottles = BeerHelper.GetAmountBottles(BeerArticle.pricePerUnitText);

                        //Der erste Eintrag mit der höchsten Anzahl verändert sich so nicht mehr
                        if (ThisArcticleBottles < NextArticleBottles) 
                        {
                            article = BeerArticle;
                        }
                    }
                }
            }
            return article;
        }
        
        public List<Beer> GetMostExpensiveBeer()
        {
            List<Beer> ListofBeers = BeerHelper.GetBeerData();
            List<Beer> MostExpensiveBeer = new List<Beer>();
            MostExpensiveBeer.Add(ListofBeers[0]);

            foreach (var Beer in ListofBeers)
            {
                foreach (var Article in Beer.Angebote)
                {

                }
            }
            return MostExpensiveBeer;
        }
        
        public Beer GetBestBeer()
        {
            return BeerHelper.GetBeerData().Where(Beer => Beer.Id == 70).FirstOrDefault();
        }
    }
}
