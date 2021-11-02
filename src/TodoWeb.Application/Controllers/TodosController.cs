using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoWeb.Domain.Entities;
using TodoWeb.Domain.Repositories;
using TodoWeb.Domain.Services;
using TodoWeb.Domain.ViewModels;
using TodoWeb.Domain.ViewModels.TodoViewModels;

namespace TodoWeb.Application.Controllers
{
    public class TodosController : Controller
    {
        private readonly ITodoRepository _todoRepository;
        private readonly ITodoServices _todoServices;
        private readonly IMapper _mapper;

        public TodosController(ITodoRepository todoRepository,
            ITodoServices todoServices, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _todoServices = todoServices;
            _mapper = mapper;
        }

        private RedirectToActionResult RedirectToErrorAction(object viewModel) =>
            RedirectToAction("Error", "Home", viewModel as ErrorViewModel);

        private RedirectToActionResult RedirectToIndex() => RedirectToAction(nameof(Index));

        public async Task<IActionResult> Index()
        {
            object result = await _todoRepository.GetAllAsync();
            return result is IEnumerable<Todo> ? View(result as IEnumerable<Todo>) : RedirectToErrorAction(result);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(TodoInputModel inputModel)
        {
            object result = await _todoRepository.InsertAsync(inputModel);
            return result is ErrorViewModel ? RedirectToErrorAction(result) : RedirectToIndex();
        }

        public async Task<RedirectToActionResult> FinishTodo(int? todoId)
        {
            object result = await _todoServices.FinishTodoAsync(todoId);
            return result is ErrorViewModel ? RedirectToErrorAction(result) : RedirectToIndex();
        }

        public async Task<IActionResult> Edit(int? todoId)
        {
            object result = await _todoRepository.GetByIdAsync(todoId);
            if (result is Todo)
            {
                TodoInputModel inputModel = _mapper.Map<TodoInputModel>(result as Todo);
                ViewData[$"{nameof(Todo)}{nameof(Todo.Id)}"] = todoId;
                return View(inputModel);
            }
            else
                return RedirectToErrorAction(result);
        }
   
        [HttpPost]
        public async Task<RedirectToActionResult> Edit(int todoId, TodoInputModel updatedTodo)
        {
            object result = await _todoRepository.UpdateAsync(todoId, updatedTodo);
            return result is ErrorViewModel ? RedirectToErrorAction(result) : RedirectToIndex();
        }

        public async Task<RedirectToActionResult> Remove(int? todoId)
        {
            object result = await _todoRepository.RemoveAsync(todoId);
            return result is ErrorViewModel ? RedirectToErrorAction(result) : RedirectToIndex();
        }
    }
}
