using Demo_Session_2_MVC.Models;
using System.Globalization;

namespace Demo_Session_2_MVC.Services;

public class ProductServiceImpl : ProductService
{
    private List<Product> products;

    public ProductServiceImpl()
    {
        products = new List<Product>()
        {
            new Product
            {
                Id= 1,
                Name="ipad",
                Description ="phongA.jpg",
                Price=2,
                Created=DateTime.ParseExact("20/10/2023","dd/MM/yyyy",CultureInfo.InvariantCulture),
            },

            new Product
            {
                Id= 2,
                Name="oppo",
                Description ="phongA.jpg",
                Price=1.2,
                Created=DateTime.ParseExact("30/07/2022","dd/MM/yyyy",CultureInfo.InvariantCulture),
            },
             new Product
            {
                Id= 3,
                Name="xiaomi",
                Description ="phongA.jpg",
                Price=0.8,
                Created=DateTime.ParseExact("04/08/2023","dd/MM/yyyy",CultureInfo.InvariantCulture),
            },
              new Product
            {
                Id= 4,
                Name="samsung",
                Description ="phongA.jpg",
                Price=3.3,
                Created=DateTime.ParseExact("12/06/2023","dd/MM/yyyy",CultureInfo.InvariantCulture),
            },
               new Product
            {
                Id= 5,
                Name="realme",
                Description ="phongA.jpg",
                Price=2.9,
               Created=DateTime.ParseExact("01/02/2023","dd/MM/yyyy",CultureInfo.InvariantCulture),
            }
        };
    }


    public List<Product> findAll() { return products; }
    public List<Product> searchByKeyWord(string keyword) {
       return products.Where(pro => pro.Name.Contains(keyword)).ToList();
    }

    public List<Product> searchByPrice(double min, double max)
    {
        return products.Where(pro => pro.Price>=min && pro.Price<=max).ToList();
    }
    public List<Product> searchByDate(string from, string to)
    {
        var star = DateTime.ParseExact(from, "MM/dd/yyyy",CultureInfo.InvariantCulture);
        var end = DateTime.ParseExact(to, "MM/dd/yyyy", CultureInfo.InvariantCulture);
        return products.Where(pro=>pro.Created>=star && pro.Created <= end).ToList();
    }
    public Product findById(int id)
    {
        return products.SingleOrDefault(pro => pro.Id == id);
    }
}
