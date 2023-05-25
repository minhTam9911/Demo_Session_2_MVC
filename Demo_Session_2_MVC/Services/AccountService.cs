using Demo_Session_2_MVC.Models;

namespace Demo_Session_2_MVC.Services;

public interface AccountService
{
    Account find( string username);
    bool login(string username, string password); 
}
