using FlaschenPostAPI.Repo;
using FlaschenPostAPI.Util;
using FlaschenpostModels;
using FlaschenpostModels.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace bl_Bottle.test;

[TestFixture]
public class BottleRepoTests
{
    private Mock<IBottleUtil> _mockBottleUtil;
    private BottleRepo _bottleRepo;

    [SetUp]
    public void Setup()
    {
        _mockBottleUtil = new Mock<IBottleUtil>();
        _bottleRepo = new BottleRepo(_mockBottleUtil.Object);
    }
    [Test]
    public void GetCheapestBeer_ShouldReturn_CheapestBeer()
    {
        // Arrange
        var fakeBeers = new List<Beer>
        {
            new Beer { Id = 1, BrandName = "Brand A", Name = "Beer A", Offers = new List<Article> { new Article { price = 3.50 } } },
            new Beer { Id = 2, BrandName = "Brand B", Name = "Beer B", Offers = new List<Article> { new Article { price = 2.99 } } } 
        };

        _mockBottleUtil.Setup(m => m.GetBeerData()).Returns(fakeBeers);

        // Act
        var result = _bottleRepo.GetCheapestBeer();

        // Assert
        result.Should().HaveCount(1);
        result.First().Should().BeEquivalentTo(fakeBeers[1]);
    }
    
    [Test]
    public void GetCheapestBeer_ShouldReturnEmptyList_WhenNoBeers()
    {
        // Arrange
        _mockBottleUtil.Setup(m => m.GetBeerData()).Returns(new List<Beer>());

        // Act
        var result = _bottleRepo.GetCheapestBeer();

        // Assert
        result.Should().BeEmpty();
    }
    
    [Test]
    public void GetAllBeer_ShouldReturnAllBeers()
    {
        // Arrange
        var fakeBeers = new List<Beer>
        {
            new Beer { Id = 1, BrandName = "Brand A", Name = "Beer A", Offers = new List<Article> { new Article { price = 3.50 } } },
            new Beer { Id = 2, BrandName = "Brand B", Name = "Beer B", Offers = new List<Article> { new Article { price = 2.99 } } }
        };

        _mockBottleUtil.Setup(m => m.GetBeerData()).Returns(fakeBeers);

        // Act
        var result = _bottleRepo.GetAllBeer();

        // Assert
        result.Should().HaveCount(fakeBeers.Count); 
        result.Should().BeEquivalentTo(fakeBeers); 
    }
    
    [Test]
    public void GetAllBeer_ShouldReturnEmptyListWhenNoBeers()
    {
        // Arrange
        _mockBottleUtil.Setup(m => m.GetBeerData()).Returns(new List<Beer>());

        // Act
        var result = _bottleRepo.GetAllBeer();

        // Assert
        result.Should().BeEmpty();
    }
    
    [Test]
    public void GetBeersByExactPrice_ShouldReturnBeersWithExactPrice()
    {
        // Arrange
        var targetPrice = 3.50;
        var fakeBeers = new List<Beer>
        {
            new Beer { Id = 1, BrandName = "Brand A", Name = "Beer A", Offers = new List<Article> { new Article { price = 3.50 } } }, 
            new Beer { Id = 2, BrandName = "Brand B", Name = "Beer B", Offers = new List<Article> { new Article { price = 2.99 } } } 
        };

        _mockBottleUtil.Setup(m => m.GetBeerData()).Returns(fakeBeers);

        // Act
        var result = _bottleRepo.GetBeersByExactPrice(targetPrice);

        // Assert
        result.Should().ContainSingle();
        result.First().Offers.Any(offer => offer.price == targetPrice).Should().BeTrue();
    }
    
    [Test]
    public void GetBeersByExactPrice_ShouldReturnEmptyListWhenNoBeersWithExactPrice()
    {
        // Arrange
        var targetPrice = 4.00;
        _mockBottleUtil.Setup(m => m.GetBeerData()).Returns(new List<Beer>());

        // Act
        var result = _bottleRepo.GetBeersByExactPrice(targetPrice);

        // Assert
        result.Should().BeEmpty();
    }
  
    [Test]
    public void GetMostBottledBeer_ShouldReturnNullWhenNoArticles()
    {
        // Arrange
        _mockBottleUtil.Setup(m => m.GetBeerData()).Returns(new List<Beer>());

        // Act
        var result = _bottleRepo.GetMostBottledBeer();

        // Assert
        result.Should().BeNull();
    }
    [Test]
    public void GetMostExpensiveBeer_ShouldReturnMostExpensiveBeer()
    {
        // Arrange
        var fakeBeers = new List<Beer>
        {
            new Beer { Id = 1, Offers = new List<Article> { new Article { price = 3.50 } } },
            new Beer { Id = 2, Offers = new List<Article> { new Article { price = 4.99 } } } // Teuerstes Bier
        };

        _mockBottleUtil.Setup(m => m.GetBeerData()).Returns(fakeBeers);

        // Act
        var result = _bottleRepo.GetMostExpensiveBeer();

        // Assert
        result.Should().ContainSingle(); // Sollte nur ein Bier zurückgeben
        result.First().Should().BeEquivalentTo(fakeBeers[1]); // Überprüfen, ob das teuerste Bier zurückgegeben wird
    }
    [Test]
    public void GetMostExpensiveBeer_ShouldReturnEmptyListWhenNoBeers()
    {
        // Arrange
        _mockBottleUtil.Setup(m => m.GetBeerData()).Returns(new List<Beer>());

        // Act
        var result = _bottleRepo.GetMostExpensiveBeer();

        // Assert
        result.Should().BeEmpty(); // Die zurückgegebene Liste sollte leer sein
    }
    [Test]
    public void GetBestBeer_ShouldReturnBeerWithId70()
    {
        // Arrange
        var fakeBeers = new List<Beer>
        {
            new Beer { Id = 69, BrandName = "Brand A" },
            new Beer { Id = 70, BrandName = "Best Beer" }, // Das "beste" Bier
            new Beer { Id = 71, BrandName = "Brand C" }
        };

        _mockBottleUtil.Setup(m => m.GetBeerData()).Returns(fakeBeers);

        // Act
        var result = _bottleRepo.GetBestBeer();

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(70);
    }
    [Test]
    public void GetBestBeer_ShouldReturnNullWhenNoBeerWithId70()
    {
        // Arrange
        var fakeBeers = new List<Beer>
        {
            new Beer { Id = 69, BrandName = "Brand A" },
            new Beer { Id = 71, BrandName = "Brand C" }
        };

        _mockBottleUtil.Setup(m => m.GetBeerData()).Returns(fakeBeers);

        // Act
        var result = _bottleRepo.GetBestBeer();

        // Assert
        result.Should().BeNull();
    }

}