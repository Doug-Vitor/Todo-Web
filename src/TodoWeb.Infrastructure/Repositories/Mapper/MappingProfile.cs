using AutoMapper;
using TodoWeb.Domain.Entities;
using TodoWeb.Domain.ViewModels.TodoViewModels;

namespace TodoWeb.Infrastructure.Repositories.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() => CreateMap<Todo, TodoInputModel>().ReverseMap();
    }
}
