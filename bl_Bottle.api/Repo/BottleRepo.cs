using FlaschenPostAPI.Util;
using FlaschenpostModels.Interfaces.Repositories;
using FlaschenpostModels.Models;

#nullable disable

namespace FlaschenPostAPI.Repo
{
    public class BottleRepo : IBottleRepo
    {
        private IBottleUtil BottleUtil { get; set; }
        public BottleRepo(IBottleUtil bottleUtil)
        {
            BottleUtil = bottleUtil;
        }

        public List<Beer> GetCheapestBeer()
        {
            return null;
        }
        public List<Beer> GetAllBeer()
        {
            return BottleUtil.GetBeerData();
        }
        
        public List<Beer> getBeersByExactPrice(double price)
        {
            List<Beer> ListofBeers = BottleUtil.GetBeerData();
            List<Beer> RtnList = new List<Beer>();

            foreach (var Beer in ListofBeers)
            {
                bool isExactPrice = false;
                foreach (var Article in Beer.Offers)
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
            List<Beer> ListofBeers = BottleUtil.GetBeerData();
            Article article = null;
            foreach (Beer Beer in ListofBeers)
            {
                foreach (Article BeerArticle in Beer.Offers)
                {
                    if (article == null)
                    {
                        article = BeerArticle;
                    }
                    else
                    {
                        double ThisArcticleBottles = BottleUtil.GetAmountBottles(article.pricePerUnitText);
                        double NextArticleBottles = BottleUtil.GetAmountBottles(BeerArticle.pricePerUnitText);

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
            List<Beer> ListofBeers = BottleUtil.GetBeerData();
            List<Beer> MostExpensiveBeer = new List<Beer>();
            MostExpensiveBeer.Add(ListofBeers[0]);

            foreach (var Beer in ListofBeers)
            {
                foreach (var Article in Beer.Offers)
                {

                }
            }
            return MostExpensiveBeer;
        }
        
        public Beer GetBestBeer()
        {
            return BottleUtil.GetBeerData().Where(Beer => Beer.Id == 70).FirstOrDefault();
        }
    }
}
