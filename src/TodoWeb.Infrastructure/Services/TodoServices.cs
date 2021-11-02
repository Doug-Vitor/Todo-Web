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

        public async Task<object> FinishTodoAsync(int? todoId)
        {
            object result = await _todoRepository.GetByIdAsync(todoId);

            if (result is Todo)
                (result as Todo).IsFinished = true;
            else
                return result;

            return _todoRepository.UpdateAsync(todoId, _mapper.Map<TodoInputModel>(result as Todo));
        }
    }
}
