using Demo_Session_2_MVC.Models;

namespace Demo_Session_2_MVC.Services;

public interface ProductService
{
    List<Product> findAll();
     List<Product> searchByKeyWord(string keyword);
    List<Product> searchByPrice(double min, double max);
    List<Product> searchByDate(string from, string to);
    Product findById(int id);
}
