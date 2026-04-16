using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace TestHomework;

public class AppManager
{
    protected IWebDriver driver;
    protected WebDriverWait wait;
    private string baseURL;

    // Объявляем классы-помощники
    private NavigationHelper navigation;
    private LoginHelper auth;
    private EmployeeHelper employee;

    public AppManager()
    {
        var options = new FirefoxOptions();
        options.BinaryLocation = @"D:\FirefoxPortable\App\Firefox64\firefox.exe";
        driver = new FirefoxDriver(@"D:\thirdcourse\TestHomework\TestHomework\geckodriver.exe", options);
            
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        driver.Manage().Window.Maximize();
        baseURL = "https://opensource-demo.orangehrmlive.com/web/index.php";

        // Инициализируем помощников и передаем им себя (this)
        navigation = new NavigationHelper(this, baseURL);
        auth = new LoginHelper(this);
        employee = new EmployeeHelper(this);
    }

    // Property для доступа к драйверу, ожиданию и хелперам
    public IWebDriver Driver => driver;
    public WebDriverWait Wait => wait;
    public NavigationHelper Navigation => navigation;
    public LoginHelper Auth => auth;
    public EmployeeHelper Employee => employee;

    public void Stop()
    {
        driver.Quit();
        driver.Dispose();
    }
}