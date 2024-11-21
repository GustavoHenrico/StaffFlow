using System.Diagnostics;
using Farmtech.Core.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using StaffFlow.Models;

namespace StaffFlow.Controllers;

public class ManagerController(CoreDbContext coreDb) : Controller
{

    public IActionResult Index()
    {
        var ManagerList = coreDb.Manager.ToList();
        return View(ManagerList);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpGet("Manager/Delete/{id}")]
    public IActionResult Delete(Guid id)
    {
        var Employees = coreDb.Employee.Where(x => x.ManagerId == id).ToList();
        if (Employees.Count > 0)
        {
            coreDb.Employee.RemoveRange(Employees);
            coreDb.SaveChanges();
        }
        var Manager = coreDb.Manager.Find(id);
        if (Manager != null)
        {
            coreDb.Manager.Remove(Manager);
            coreDb.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    public IActionResult Edit(Guid id)
    {
        var Manager = coreDb.Manager.Find(id);
        return View(Manager);
    }

    [HttpPost]
    public IActionResult Create(CreateManager createManager)
    {
        if (ModelState.IsValid)
        {
            var newManager = new Manager()
            {
                Id = Guid.NewGuid(),
                Department = createManager.Department,
                Email = createManager.Email,
                Name = createManager.Name,
            };

            coreDb.Manager.Add(newManager);
            coreDb.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(createManager);
    }

    [HttpPost]
    public IActionResult Edit(EditManager editManager)
    {
        if (ModelState.IsValid)
        {
            var Manager = coreDb.Manager.Find(editManager.Id);
            if (Manager == null)
            {
                return RedirectToAction("Index");
            }
            Manager.Name = editManager.Name;
            Manager.Email = editManager.Email;
            Manager.Department = editManager.Department;

            coreDb.Manager.Update(Manager);
            coreDb.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(editManager);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
