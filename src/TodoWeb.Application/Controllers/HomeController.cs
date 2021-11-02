using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoWeb.Domain.Entities;
using TodoWeb.Domain.Repositories;
using TodoWeb.Domain.ViewModels;

namespace TodoWeb.Application.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index([FromServices] ITodoRepository todoRepository)
        {
            object result = await todoRepository.GetAllAsync();
            return result is IEnumerable<Todo> ? View(result as IEnumerable<Todo>) : RedirectToAction(nameof(Error), result as ErrorViewModel);
        }

        public IActionResult Error(ErrorViewModel viewModel) => View(viewModel);
    }
}
