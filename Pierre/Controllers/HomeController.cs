using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Pierre.Models;

namespace Pierre.Controllers;

public class HomeController : Controller
{
     [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

  }