using Microsoft.AspNetCore.Mvc;

namespace EsportsAcademy.Controllers;

public class HomeController : Controller
{
    // GET: /
    public IActionResult Index() => View();

    // GET: /Home/Error
    public IActionResult Error() => View();
}
