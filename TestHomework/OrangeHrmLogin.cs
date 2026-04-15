using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using TestHomework;

[TestFixture]
public class OrangeHrmTest : TestBase
{

    [Test]
    public void TestLoginOnly()
    {
        GoToHomePage();
            
        AccountData user = new AccountData("Admin", "admin123");
        Login(user);

        wait.Until(d => d.Url.Contains("dashboard"));
        IWebElement dashboardHeader = WaitForElement(By.XPath("//h6[text()='Dashboard']"));
        Assert.That(dashboardHeader, Is.Not.Null, "Ошибка: Вход не выполнен!");
    }

    [Test]
    public void TestEmployeeCreation()
    {
        GoToHomePage();
        AccountData user = new AccountData("Admin", "admin123");
        Login(user);

        GoToPimPage();

        EmployeeData newEmployee = new EmployeeData("John", "Doe")
        {
            EmployeeId = "QA" + new Random().Next(1000, 9999).ToString()
        };

        CreateNewEmployee(newEmployee);

        wait.Until(d => d.Url.Contains("viewPersonalDetails"));
        IWebElement personalDetailsHeader = WaitForElement(By.XPath("//h6[text()='Personal Details']"));
        Assert.That(personalDetailsHeader, Is.Not.Null, "Ошибка: Сотрудник не был создан!");
    }
}