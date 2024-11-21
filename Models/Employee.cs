namespace StaffFlow.Models;

public class Employee
{
    public Guid? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public Manager? Manager { get; set; }
    public Guid? ManagerId { get; set; }
}

public class CreateEmployee
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public Guid? ManagerId { get; set; }

}

public class EditEmployee
{
    public Guid? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public Guid? ManagerId { get; set; }

}

public class EmployeeEditViewModel
{
    public Employee Employee { get; set; }
    public IEnumerable<Manager> Managers { get; set; }
}
