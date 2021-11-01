using System.Threading.Tasks;

namespace TodoWeb.Domain.Services
{
    public interface ITodoServices
    {
        Task FinishTodoAsync(int todoId);
    }
}
