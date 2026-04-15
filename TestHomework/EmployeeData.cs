namespace TestHomework;

public class EmployeeData
{
    public EmployeeData(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmployeeId { get; set; }
    
}