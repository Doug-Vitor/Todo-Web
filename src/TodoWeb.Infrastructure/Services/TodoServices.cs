using AutoMapper;
using System;
using System.Threading.Tasks;
using TodoWeb.Domain.Entities;
using TodoWeb.Domain.Repositories;
using TodoWeb.Domain.Services;
using TodoWeb.Domain.ViewModels.TodoViewModels;

namespace TodoWeb.Infrastructure.Services
{
    public class TodoServices : ITodoServices
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public TodoServices(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        public async Task FinishTodoAsync(int todoId)
        {
            Todo todo = await _todoRepository.GetByIdAsync(todoId) as Todo;
            todo.IsFinished = true;
            await _todoRepository.UpdateAsync(todoId, _mapper.Map<TodoInputModel>(todo));
        }
    }
}
