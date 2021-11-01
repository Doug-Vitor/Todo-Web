using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TodoWeb.Domain.Entities;
using TodoWeb.Domain.Repositories;
using TodoWeb.Domain.Services;
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

        public async Task<IActionResult> Index() => View(await _todoRepository.GetAllAsync());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(TodoInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                await _todoRepository.InsertAsync(inputModel);
                return RedirectToAction(nameof(Index));
            }

            return View(inputModel);
        }

        public async Task<RedirectToActionResult> FinishTodo(int todoId)
        {
            await _todoServices.FinishTodoAsync(todoId);
            return RedirectToAction(nameof(Index), "Home");
        }

        public async Task<IActionResult> Edit(int? todoId)
        {
            Todo todo = await _todoRepository.GetByIdAsync(todoId) as Todo;
            TodoInputModel inputModel = _mapper.Map<TodoInputModel>(todo);

            ViewData[$"{nameof(Todo)}{nameof(Todo.Id)}"] = todo.Id;
            return View(inputModel);
        }
   
        [HttpPost]
        public async Task<RedirectToActionResult> Edit(int todoId, TodoInputModel updatedTodo)
        {
            await _todoRepository.UpdateAsync(todoId, updatedTodo);
            return RedirectToAction(nameof(Index));
        }

        public async Task<RedirectToActionResult> Remove(int todoId)
        {
            await _todoRepository.RemoveAsync(todoId);
            return RedirectToAction(nameof(Index));
        }
    }
}
