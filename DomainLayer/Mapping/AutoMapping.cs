using AutoMapper;
using DomainLayer.Model;
using DomainLayer.ViewModels;

namespace DomainLayer.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<UserLogin, UserLoginVM>().ReverseMap();
            CreateMap<DailyLog, DailyLogVM>().ReverseMap();
            CreateMap<Project, ProjectVM>().ReverseMap();
            CreateMap<ProjectMember, ProjectMemberVM>().ReverseMap();
            CreateMap<RegisterUserVM, User>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => "User"))
                .ReverseMap();
            CreateMap<DailyLog, DailyLogVM>().ReverseMap();
            CreateMap<DailyLogVM, DailyLogVM>().ReverseMap();
            CreateMap<Designation, DesignationVM>().ReverseMap();
            CreateMap<TaskModel, TaskVM>().ReverseMap();
        }
    }
}
