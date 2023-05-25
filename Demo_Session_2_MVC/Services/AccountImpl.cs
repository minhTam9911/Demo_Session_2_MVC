using Demo_Session_2_MVC.Models;

namespace Demo_Session_2_MVC.Services;

public class AccountImpl : AccountService
{
    private List<Account> accounts;
        public AccountImpl()
    {
        accounts = new List<Account>() {
        new Account
        {
            UserName = "Test",
            Password = "$2a$11$jut511RWDtQUW6xjgZZt6.YyL65u.XdkkuQGF08YxbzYn.CHzoFAW",
            FullName="Admin 1"
        },
        new Account
           {
            UserName = "Test2",
            Password = "$2a$11$kOGGSnbggitOyiFiU6vTruuP6ezAsrdgjVkBJ94fGTpa4HJcvugIK",
            FullName = "Admin 2"
            }
        };
    }
    public Account find(string username)
    {
        return accounts.SingleOrDefault(acc => acc.UserName == username);
    }
    public bool login(string username, string password) {

        var account = accounts.SingleOrDefault(a => a.UserName == username);
        if (account != null)
        {
            return BCrypt.Net.BCrypt.Verify(password, account.Password);
        }
        return false;
    }
}
