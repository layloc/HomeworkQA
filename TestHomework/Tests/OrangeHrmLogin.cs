using System.Xml.Serialization;
using TestHomework.Models;

namespace TestHomework.Tests;

[TestFixture]
public class OrangeHrmTests : TestBase
{
    public static IEnumerable<EmployeeData> EmployeeDataFromXmlFile()
    {
        return (List<EmployeeData>)new XmlSerializer(typeof(List<EmployeeData>))
            .Deserialize(new StreamReader(@"employees.xml"));
    }
        
    [Test, TestCaseSource("EmployeeDataFromXmlFile")]
    public void TestEmployeeCreation(EmployeeData newEmployee) // 3. Принимаем объект из файла
    {
        app.Navigation.GoToHomePage();
        app.Auth.Login(new AccountData("Admin", "admin123"));
        app.Navigation.GoToPimPage();

        // Создаем сотрудника данными из XML файла!
        app.Employee.CreateNewEmployee(newEmployee);

        // Считываем сохраненные данные и сравниваем
        EmployeeData savedEmployee = app.Employee.GetCreatedEmployeeData();
            
        Assert.That(savedEmployee.FirstName, Is.EqualTo(newEmployee.FirstName), "Имя не совпадает!");
        Assert.That(savedEmployee.LastName, Is.EqualTo(newEmployee.LastName), "Фамилия не совпадает!");
            
        TestContext.Out.WriteLine($"УСПЕХ! Создан сотрудник {newEmployee.FirstName} с ID {newEmployee.EmployeeId}");
    }
}