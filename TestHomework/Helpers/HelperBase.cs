using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestHomework;

public class HelperBase
{
    protected AppManager manager;
    protected IWebDriver driver;
    protected WebDriverWait wait;

    public HelperBase(AppManager manager)
    {
        this.manager = manager;
        driver = manager.Driver;
        wait = manager.Wait;
    }


    public IWebElement WaitForElement(By by)
    {
        return wait.Until(d => {
            var elements = d.FindElements(by);
            if (elements.Count > 0 && elements[0].Displayed && elements[0].Enabled) {
                return elements[0];
            }
            return null;
        });
    }

    public void ClearAndType(IWebElement element, string text)
    {
        element.SendKeys(Keys.Control + "a");
        element.SendKeys(Keys.Delete);
        element.Clear();
        element.SendKeys(text);
    }

    public void WaitForSpinnerToDisappear()
    {
        wait.Until(d => {
            var loaders = d.FindElements(By.CssSelector(".oxd-form-loader, .oxd-loading-spinner"));
            return loaders.Count == 0 || !loaders[0].Displayed;
        });
    }
}