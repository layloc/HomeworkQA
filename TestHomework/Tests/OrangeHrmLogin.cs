namespace TestHomework;

[TestFixture]
public class OrangeHrmTests : TestBase
{
    [Test]
    public void TestLoginOnly()
    {
        app.Navigation.GoToHomePage();
        AccountData user = new AccountData("Admin", "admin123");
        app.Auth.Login(user);
        Assert.That(app.Auth.IsLoggedIn(), Is.True, "Ошибка: Вход не выполнен!");
    }

    [Test]
    public void TestEmployeeCreation()
    {
        app.Navigation.GoToHomePage();
        AccountData user = new AccountData("Admin", "admin123");
        app.Auth.Login(user);
        app.Navigation.GoToPimPage();
        EmployeeData newEmployee = new EmployeeData("John", "Doe")
        {
            EmployeeId = "QA" + new Random().Next(1000, 9999).ToString()
        };
        app.Employee.CreateNewEmployee(newEmployee);
        Assert.That(app.Employee.IsEmployeeCreated(), Is.True, "Ошибка: Сотрудник не был создан!");
        TestContext.Out.WriteLine($"УСПЕХ! Создан сотрудник: ID {newEmployee.EmployeeId}");
        System.Threading.Thread.Sleep(5000); 
    }
}