using OpenQA.Selenium;
using TestHomework.Models;

namespace TestHomework.Helpers;

public class EmployeeHelper : HelperBase
{
    public EmployeeHelper(AppManager manager) : base(manager) { }

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
        
    public EmployeeData GetCreatedEmployeeData()
    {
        WaitForSpinnerToDisappear();
        string firstName = WaitForElement(By.Name("firstName")).GetAttribute("value");
        string lastName = WaitForElement(By.Name("lastName")).GetAttribute("value");

        return new EmployeeData(firstName, lastName);
    }
        
    public void SearchAndOpenEmployee(string empId)
    {
        IWebElement empIdInput = WaitForElement(By.XPath("//label[text()='Employee Id']/parent::div/following-sibling::div/input"));
        ClearAndType(empIdInput, empId);

        WaitForElement(By.XPath("//button[@type='submit']")).Click();
        WaitForSpinnerToDisappear();
        Thread.Sleep(1500); 
        WaitForElement(By.XPath("//button[.//i[contains(@class, 'bi-pencil')]]")).Click();
        WaitForSpinnerToDisappear();
    }
        
    public void ModifyEmployee(EmployeeData newData)
    {
        IWebElement firstNameInput = WaitForElement(By.Name("firstName"));
        ClearAndType(firstNameInput, newData.FirstName);

        IWebElement lastNameInput = WaitForElement(By.Name("lastName"));
        ClearAndType(lastNameInput, newData.LastName);

        WaitForElement(By.XPath("(//button[@type='submit'])[1]")).Click();
        WaitForSpinnerToDisappear();
    }

    public bool IsEmployeeCreated()
    {
        wait.Until(d => d.Url.Contains("viewPersonalDetails"));
        return WaitForElement(By.XPath("//h6[text()='Personal Details']")) != null;
    }
}