using Cabify.Data;
using Cabify.Data.EfDbSetWrapper;
using Cabify.Models;
using Cabify.ModelsDto;
using Cabify.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace Cabify.BBD
{
    [Binding]
    public class DiscountApplicationSteps
    {
        private double result;
        private ShoppingBasketDto shoppingBasketDto;
        private MapperService mapperService;
        private EfDbContext efDbContext;
        private EfDbSetWrapper<ShoppingBasket> efDbSetWrapper;
        private ShoppingBasketService shoppingBasketService;

        public DiscountApplicationSteps()
        {
            this.shoppingBasketDto = new ShoppingBasketDto();
            this.mapperService = new MapperService();
            this.efDbContext = new EfDbContext();
            this.efDbSetWrapper = new EfDbSetWrapper<ShoppingBasket>(efDbContext);

            this.shoppingBasketService = new ShoppingBasketService(shoppingBasketDto, mapperService, efDbSetWrapper, efDbContext);
        }
        [Given(@"I have entered (.*), (.*) and (.*)  into the application")]
        public void GivenIHaveEnteredAndIntoTheApplication(int p0, int p1, int p2)
        {
            this.shoppingBasketDto.PopulateShoppingBasket(p0, p1, p2);
        }

        [When(@"I press calculate price")]
        public void WhenIPressCalculatePrice()
        {
            this.result = this.shoppingBasketService.GetTotalPrice() - this.shoppingBasketService.ApplyDiscountVoucher() - this.shoppingBasketService.ApplyDiscountTshirt();
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(double p0)
        {
            Assert.AreEqual(this.result, p0);
        }
    }
}
