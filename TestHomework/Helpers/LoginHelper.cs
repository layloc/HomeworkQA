using OpenQA.Selenium;
using TestHomework.Models;

namespace TestHomework.Helpers;

public class LoginHelper : HelperBase
{
    public LoginHelper(AppManager manager) : base(manager) { }

    public void Login(AccountData user)
    {
        // Если мы уже внутри (на дашборде или в профиле), логиниться не нужно
        if (driver.Url.Contains("dashboard") || driver.Url.Contains("viewPersonalDetails")) return;

        WaitForElement(By.Name("username")).SendKeys(user.Username);
        WaitForElement(By.Name("password")).SendKeys(user.Password);
        WaitForElement(By.CssSelector("button[type='submit']")).Click();
        WaitForSpinnerToDisappear();
    }

    public bool IsLoggedIn()
    {
        wait.Until(d => d.Url.Contains("dashboard"));
        return WaitForElement(By.XPath("//h6[text()='Dashboard']")) != null;
    }
}