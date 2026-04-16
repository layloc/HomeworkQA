using OpenQA.Selenium;

namespace TestHomework;

public class NavigationHelper : HelperBase
{
    private string baseURL;

    public NavigationHelper(AppManager manager, string baseURL) : base(manager)
    {
        this.baseURL = baseURL;
    }

    public void GoToHomePage()
    {
        driver.Navigate().GoToUrl(baseURL + "/auth/login");
    }

    public void GoToPimPage()
    {
        WaitForElement(By.XPath("//span[text()='PIM']")).Click();
        WaitForSpinnerToDisappear();
    }
}