namespace TestHomework.Models;

public class EmployeeData
{
    public EmployeeData(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    public EmployeeData() { }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmployeeId { get; set; }
    
}