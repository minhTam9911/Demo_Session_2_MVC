namespace Demo_Session_2_MVC.Services;

public class DemoServiceImpl : DemoService
{
    public string Hello()
    {
        return "Hello World";
    }
    public string Hi(string name) {
        return name;
    }
}
