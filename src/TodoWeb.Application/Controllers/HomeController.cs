using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoWeb.Domain.Repositories;

namespace TodoWeb.Application.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index([FromServices] ITodoRepository todoRepository)
            => View(await todoRepository.GetAllAsync());
    }
}
