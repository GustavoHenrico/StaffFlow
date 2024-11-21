using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StaffFlow.Models;

namespace StaffFlow.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return RedirectToAction("Index", "Employee");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
