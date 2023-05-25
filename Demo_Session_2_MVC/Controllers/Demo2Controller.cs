using Demo_Session_2_MVC.Models;
using Demo_Session_2_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Demo_Session_2_MVC.Controllers;

[Route("demo2")]
public class Demo2Controller : Controller
{
    private ProductService productService;
    public Demo2Controller(ProductService productService)
    {
        this.productService = productService;
    }

    [Route("")]
    [Route("~/")]
    [Route("index")]
    public IActionResult Index()
    {
        HttpContext.Session.SetInt32("id", 123);
        HttpContext.Session.SetString("userName", "abc123");
        HttpContext.Session.Remove("userName");
        var proSer = productService.findById(1);
        string str = JsonConvert.SerializeObject(proSer);
        HttpContext.Session.SetString("json", str);
       var proFindAll = productService.findAll();
        var products = JsonConvert.SerializeObject(proFindAll);
        HttpContext.Session.SetString("products", products);
        return View("index");
    }
    [Route("index2")]
    public IActionResult Index2()
    {
        if(HttpContext.Session.GetInt32("id")!=null)
        {
            var id = HttpContext.Session.GetInt32("id");
            Debug.WriteLine("ID: " + id);
        }
        if (HttpContext.Session.GetString("userName") != null)
        {
            var user = HttpContext.Session.GetString("userName");
            Debug.WriteLine("userName: " + user);
        }
        if (HttpContext.Session.GetString("json") != null)
        {
            var product=JsonConvert.DeserializeObject<Product>(HttpContext.Session.GetString("json"));
            Debug.WriteLine("Product Infor: " + product.Id);
        }
        if (HttpContext.Session.GetString("products") != null)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(HttpContext.Session.GetString("products"));
            Debug.WriteLine("Product List: ");
            products.ForEach(p =>
            {
                Debug.WriteLine("ID: "+p.Id);
                Debug.WriteLine("Name: " + p.Name);
                Debug.WriteLine("---------------------------------");
            });
            
        }
        var hashPass = BCrypt.Net.BCrypt.HashPassword("123");
        Debug.WriteLine("123: " + hashPass);
        Debug.WriteLine("123: " + hashPass);
        Debug.WriteLine("123: " + hashPass);
        return RedirectToAction("index");
    }
}
