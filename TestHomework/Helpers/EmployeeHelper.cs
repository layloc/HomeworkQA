using OpenQA.Selenium;

namespace TestHomework;

public class EmployeeHelper : HelperBase
{
    public EmployeeHelper(AppManager manager) : base(manager)
    {
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

    public bool IsEmployeeCreated()
    {
        wait.Until(d => d.Url.Contains("viewPersonalDetails"));
        var header = WaitForElement(By.XPath("//h6[text()='Personal Details']"));
        return header != null;
    }
}