using Cabify.Data.Contracts;
using Cabify.Models;
using Cabify.ModelsDto;
using Cabify.ModelsDto.Contracts;
using Cabify.Services;
using Cabify.Services.Contracts;

using System.Web.Mvc;

namespace Cabify.WebClient.Controllers
{
    [Authorize]
    public class MyPurchasesController : Controller
    {
        private IShoppingBasketService shoppingBasketService;
        private IShoppingBasketDto shoppingBasketDto;

        public MyPurchasesController(IShoppingBasketService shoppingBasketService, IShoppingBasketDto shoppingBasketDto)
        {
            this.shoppingBasketService = shoppingBasketService;
            this.shoppingBasketDto = shoppingBasketDto;
        }

        // GET: MyPurchases
        public ActionResult Index()
        {
            double quantityVoucher = (double)this.HttpContext.Cache["quantityVoucher"];
            double quantityTshirt = (double)this.HttpContext.Cache["quantityTshirt"];
            double quantityMug = (double)this.HttpContext.Cache["quantityMug"];
            this.HttpContext.Cache.Remove("quantityVoucher");
            this.HttpContext.Cache.Remove("quantityTshirt");
            this.HttpContext.Cache.Remove("quantityMug");

            this.shoppingBasketDto.PopulateShoppingBasket(quantityVoucher, quantityTshirt, quantityMug);

            this.shoppingBasketService.AddShoppingBasket();

            return this.View(this.shoppingBasketDto);
        }
    }
}