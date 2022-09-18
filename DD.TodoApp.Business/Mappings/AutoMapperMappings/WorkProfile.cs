using AutoMapper;
using DD.TodoApp.Dtos.WorkDtos;
using DD.TodoApp.Entities.Concrete;

namespace DD.TodoApp.Business.Mappings.AutoMapperMappings
{
    public class WorkProfile : Profile
    {
        public WorkProfile()
        {
            CreateMap<Work,WorkListDto>().ReverseMap();
            CreateMap<Work, WorkCreateDto>().ReverseMap();
            CreateMap<Work, WorkUpdateDto>().ReverseMap();
            CreateMap<WorkListDto, WorkUpdateDto>().ReverseMap();

        }
    }
}
