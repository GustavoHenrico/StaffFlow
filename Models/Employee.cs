namespace StaffFlow.Models;

public class Employee
{
    public Guid? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
}

public class CreateEmployee
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
}

public class EditEmployee
{
    public Guid? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
}
