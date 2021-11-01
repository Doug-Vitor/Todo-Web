using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoWeb.Domain.ViewModels.TodoViewModels
{
    public class TodoInputModel
    {
        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [DisplayName("Título")]
        [StringLength(75, ErrorMessage = "Campo {0} deve conter no máximo {1} caracteres.")]
        public string Title { get; set; }

        [StringLength(200, ErrorMessage = "Campo {0} deve conter no máximo {1} caracteres.")]
        [DisplayName("Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [DisplayName("Tarefa finalizada")]
        public bool IsFinished { get; set; }
    }
}
