using System.Collections.Generic;
using System.Threading.Tasks;
using TodoWeb.Domain.ViewModels.TodoViewModels;

namespace TodoWeb.Domain.Repositories
{
    public interface ITodoRepository
    {
        Task<object> InsertAsync(TodoInputModel inputModel);
        Task<object> GetByIdAsync(int? id);
        Task<object> GetAllAsync();
        Task<object> UpdateAsync(int? id, TodoInputModel inputModel);
        Task<object> RemoveAsync(int? id);
    }
}
