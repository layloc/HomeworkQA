using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace TestHomework.Helpers;

public class AppManager
{
    protected IWebDriver driver;
    protected WebDriverWait wait;
    private string baseURL;

    private NavigationHelper navigation;
    private LoginHelper auth;
    private EmployeeHelper employee;

    // 1. ThreadLocal переменная
    private static ThreadLocal<AppManager> app = new ThreadLocal<AppManager>();

    // 2. Приватный конструктор
    private AppManager()
    {
        var options = new FirefoxOptions();
        options.BinaryLocation = @"D:\FirefoxPortable\App\Firefox64\firefox.exe";
        driver = new FirefoxDriver(@"D:\thirdcourse\TestHomework\TestHomework\geckodriver.exe", options);
            
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        driver.Manage().Window.Maximize();
        baseURL = "https://opensource-demo.orangehrmlive.com/web/index.php";

        navigation = new NavigationHelper(this, baseURL);
        auth = new LoginHelper(this);
        employee = new EmployeeHelper(this);
    }

    // 3. Метод GetInstance (инициализация один раз)
    public static AppManager GetInstance()
    {
        if (!app.IsValueCreated)
        {
            AppManager newInstance = new AppManager();
            newInstance.Navigation.GoToHomePage();
            app.Value = newInstance;
        }
        return app.Value;
    }

    public IWebDriver Driver => driver;
    public WebDriverWait Wait => wait;
    public NavigationHelper Navigation => navigation;
    public LoginHelper Auth => auth;
    public EmployeeHelper Employee => employee;
        
    ~AppManager()
    {
        try
        {
            driver.Quit();
            driver.Dispose();
        }
        catch (Exception)
        {
            
        }
    }
}