using OpenQA.Selenium;

namespace TestHomework;

public class LoginHelper : HelperBase
{
    public LoginHelper(AppManager manager) : base(manager)
    {
    }

    public void Login(AccountData user)
    {
        WaitForElement(By.Name("username")).SendKeys(user.Username);
        WaitForElement(By.Name("password")).SendKeys(user.Password);
        WaitForElement(By.CssSelector("button[type='submit']")).Click();
    }
        
    public bool IsLoggedIn()
    {
        wait.Until(d => d.Url.Contains("dashboard"));
        var dashboardHeader = WaitForElement(By.XPath("//h6[text()='Dashboard']"));
        return dashboardHeader != null;
    }
}