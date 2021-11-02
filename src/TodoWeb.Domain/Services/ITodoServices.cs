using System.Threading.Tasks;

namespace TodoWeb.Domain.Services
{
    public interface ITodoServices
    {
        Task<object> FinishTodoAsync(int? todoId);
    }
}
