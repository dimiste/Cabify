using Cabify.Common.Enum;
using Cabify.Data;
using Cabify.Data.EfDbSetWrapper;
using Cabify.Models;
using Cabify.ModelsDto;
using Cabify.ModelsDto.Contracts;
using Cabify.Services;
using Cabify.Services.Contracts;
using Cabify.WebClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Cabify.WebClient.Controllers
{
    public class HomeController : Controller
    {
        private IShoppingBasketService shoppingBasketService;
        private IShoppingBasketDto shoppingBasketDto;

        public HomeController(IShoppingBasketService shoppingBasketService, IShoppingBasketDto shoppingBasketDto)
        {
            this.shoppingBasketService = shoppingBasketService;
            this.shoppingBasketDto = shoppingBasketDto;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string CalculateTotal(double quantityVoucher = 0, double quantityTshirt = 0, double quantityMug = 0)
        {

            this.shoppingBasketDto.PopulateShoppingBasket(quantityVoucher, quantityTshirt, quantityMug);

            var totalWithDiscounts = this.shoppingBasketService.GetTotalPrice()-this.shoppingBasketService.ApplyDiscountVoucher() - this.shoppingBasketService.ApplyDiscountTshirt();
            var totalDiscount = shoppingBasketService.GetTotalPrice() - totalWithDiscounts;

            // For shows the gif
            Thread.Sleep(1000);

            string result = totalWithDiscounts + " € <div>Saving:  " + totalDiscount + "</div>";

            this.HttpContext.Cache["quantityVoucher"] = quantityVoucher;
            this.HttpContext.Cache["quantityTshirt"] = quantityTshirt;
            this.HttpContext.Cache["quantityMug"] = quantityMug;

            return result;
        }
    }
}