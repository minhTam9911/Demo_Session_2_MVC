using Demo_Session_2_MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Session_2_MVC.Controllers;
[Route("product")]
public class ProductController : Controller
{
    private ProductService productService;
    public ProductController(ProductService _productService){
        productService= _productService;
    }
    [Route("")]
    //[Route("~/")]
    public IActionResult Index()
    {
        ViewBag.products= productService.findAll();
        return View("Index");
    }
    [Route("searchByKeyWord")]
    public IActionResult searchByKeyWord(string keyword)
    {
        ViewBag.products = productService.searchByKeyWord(keyword);
        return View("index");
    }
    [Route("searchByPrice")]
    public IActionResult searchByPrice(double min, double max)
    {
        ViewBag.products = productService.searchByPrice(min, max);
        return View("index");
    }
    [Route("searchByDate")]
    public IActionResult searchByDate(string from, string to)
    {
        ViewBag.products = productService.searchByDate(from,to);
        return View("index");
    }
}
