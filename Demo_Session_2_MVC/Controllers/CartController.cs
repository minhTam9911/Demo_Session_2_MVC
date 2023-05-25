using Demo_Session_2_MVC.Models;
using Demo_Session_2_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Demo_Session_2_MVC.Controllers;
[Route("cart")]
public class CartController : Controller
{
    private ProductService productService;
    private IConfiguration configuration;
    public CartController(ProductService _productService, IConfiguration configuration)
    {
        productService = _productService;
        this.configuration = configuration;
    }
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("cart") != null)
        {
            var cart = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(c => c.Product.Price * c.Quantity);
        }
        //ViewBag.cart = productService.findAll();
        ViewBag.PostUrl = configuration["Paypal:PostUrl"];
		ViewBag.ReturnUrl = configuration["Paypal:ReturnUrl"];
        ViewBag.Business = configuration["Paypal:Business"];
        return View("index");
    }
    [Route("buy")]
    public IActionResult Buy(int id)
    {
        // lay san pham ra
        var product = productService.findById(id);
        if (HttpContext.Session.GetString("cart") == null)
        {
            var cart = new List<Item>();
            cart.Add(new Item
            {
                Product = product,
                Quantity = 1,

            });
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
        }
        else
        {
            var cart = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
            cart.Add(new Item
            {
                Product = product,
                Quantity = 1,

            });
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
        }
        return RedirectToAction("index");
    }

    [Route("remove/{id}")]
    public IActionResult Remove(int id)
    {
        var cart = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
        var index = Exists(id, cart);
        cart.RemoveAt(index);
        HttpContext.Session.SetString("cart",JsonConvert.SerializeObject(cart));
        
        return RedirectToAction("index");
    }

    [Route("update")]
	public IActionResult Update(int[] quatities)
	{
		var cart = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
        for(var i = 0; i < cart.Count; i++)
        {
            cart[i].Quantity= quatities[i];
        }
        HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
		return View("index");
	}

	private int Exists(int i, List<Item> cart)
    {
        for(int a = 0; a < cart.Count; a++)
        {
            if (cart[a].Product.Id ==i)
            {
                return a;
            }
        }
        return -1;
    }

	[Route("success")]
	public IActionResult Success(string payer_email, string first_name, string last_name, string address_street)
	{

        Debug.WriteLine("-----------Payer Email: "+payer_email);
        Debug.WriteLine("-----------First Name " + first_name);
        Debug.WriteLine("-----------Last Name: " + last_name);
        Debug.WriteLine("-----------Address: " + address_street);

        return View("success");
	}
}
