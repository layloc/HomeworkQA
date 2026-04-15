using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace TestHomework;

public class TestBase
{
protected IWebDriver driver;
    protected WebDriverWait wait;

    [SetUp]
    public void SetUp()
    {
        var options = new FirefoxOptions();
        options.BinaryLocation = @"D:\FirefoxPortable\App\Firefox64\firefox.exe";
        driver = new FirefoxDriver(@"D:\thirdcourse\TestHomework\TestHomework\geckodriver.exe", options);
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        driver.Manage().Window.Maximize();
    }

    [TearDown]
    protected void TearDown()
    {
        driver.Quit();
        driver.Dispose();
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
    
    public void GoToHomePage()
    {
        driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
    }
    
    public void Login(AccountData user)
    {
        WaitForElement(By.Name("username")).SendKeys(user.Username);
        WaitForElement(By.Name("password")).SendKeys(user.Password);
        WaitForElement(By.CssSelector("button[type='submit']")).Click();
    }


    public void GoToPimPage()
    {
        WaitForElement(By.XPath("//span[text()='PIM']")).Click();
    }

    public void CreateNewEmployee(EmployeeData employee)
    {
        WaitForElement(By.XPath("//a[text()='Add Employee']")).Click();
    
        WaitForSpinnerToDisappear();

        WaitForElement(By.Name("firstName")).SendKeys(employee.FirstName);
        WaitForElement(By.Name("lastName")).SendKeys(employee.LastName);

        if (employee.EmployeeId != null)
        {
            IWebElement empIdInput = WaitForElement(By.XPath("//label[text()='Employee Id']/parent::div/following-sibling::div/input"));
            ClearAndType(empIdInput, employee.EmployeeId);
        }

        WaitForSpinnerToDisappear();

        WaitForElement(By.XPath("//button[@type='submit']")).Click();
    }
    public void WaitForSpinnerToDisappear()
    {
        wait.Until(d => {
            var loaders = d.FindElements(By.CssSelector(".oxd-form-loader, .oxd-loading-spinner"));
            return loaders.Count == 0 || !loaders[0].Displayed;
        });
    }
}