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
        return View();
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
        return View(employee);
    }

    [HttpPost]
    public IActionResult Create(CreateEmployee createEmployee)
    {
        if (ModelState.IsValid)
        {
            var newEmployee = new Employee()
            {
                Id = Guid.NewGuid(),
                Department = createEmployee.Department,
                Email = createEmployee.Email,
                Name = createEmployee.Name,
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
            var employee = coreDb.Employee.Find(editEmployee.Id);
            if (employee == null)
            {
                return RedirectToAction("Index");
            }
            employee.Name = editEmployee.Name;
            employee.Email = editEmployee.Email;
            employee.Department = editEmployee.Department;

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
