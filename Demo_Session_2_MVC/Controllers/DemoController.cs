using Demo_Session_2_MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Session_2_MVC.Controllers;
[Route("demo")]
public class DemoController : Controller
{
    private DemoService demoService;
    private RectangService rectangService;
    public DemoController(DemoService _demoService, RectangService _rectangService) {
        demoService = _demoService;
        rectangService = _rectangService;

    }

    [Route("")]
    //[Route("~/")]    
    public IActionResult Index()
    {
        ViewBag.msg = demoService.Hello();
        ViewBag.msg = demoService.Hi("BCBAJJS");
        ViewBag.chuvi = rectangService.chuVi(3, 4);
        ViewBag.dientich = rectangService.dientich(3, 4);
        return View("index");
    }
}
