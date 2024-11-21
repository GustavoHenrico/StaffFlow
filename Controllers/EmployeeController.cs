using System.Diagnostics;
using Farmtech.Core.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using StaffFlow.Models;

namespace StaffFlow.Controllers;

public class EmployeeController(CoreDbContext coreDb) : Controller
{

    public IActionResult Index()
    {
        var employeeList = coreDb.Employee.ToList();
        return View(employeeList);
    }

    public IActionResult Create()
    {
        var managers = coreDb.Manager.ToList();
        return View(managers);
    }

    [HttpGet("Employee/Delete/{id}")]
    public IActionResult Delete(Guid id)
    {
        var employee = coreDb.Employee.Find(id);
        if (employee != null)
        {
            coreDb.Employee.Remove(employee);
            coreDb.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    public IActionResult Edit(Guid id)
    {
        var employee = coreDb.Employee.Find(id);
        var managers = coreDb.Manager.ToList();

        // Criar o ViewModel
        var viewModel = new EmployeeEditViewModel
        {
            Employee = employee,
            Managers = managers
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Create(CreateEmployee createEmployee)
    {
        if (ModelState.IsValid)
        {
            var manager = coreDb.Manager.Find(createEmployee.ManagerId);

            var newEmployee = new Employee()
            {
                Id = Guid.NewGuid(),
                Department = createEmployee.Department,
                Email = createEmployee.Email,
                Name = createEmployee.Name,
                ManagerId = manager?.Id,
                Manager = manager
            };

            coreDb.Employee.Add(newEmployee);
            coreDb.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(createEmployee);
    }

    [HttpPost]
    public IActionResult Edit(EditEmployee editEmployee)
    {
        if (ModelState.IsValid)
        {
            var manager = coreDb.Manager.Find(editEmployee.ManagerId);
            var employee = coreDb.Employee.Find(editEmployee.Id);
            if (employee == null)
            {
                return RedirectToAction("Index");
            }
            employee.Name = editEmployee.Name;
            employee.Email = editEmployee.Email;
            employee.Department = editEmployee.Department;
            employee.ManagerId = manager?.Id;
            employee.Manager = manager;

            coreDb.Employee.Update(employee);
            coreDb.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(editEmployee);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
