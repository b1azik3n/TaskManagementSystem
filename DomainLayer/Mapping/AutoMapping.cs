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
            CreateMap<Project, ProjectAddVM>().ReverseMap();
            CreateMap<Project, ProjectDisplayVM>().ReverseMap();
            CreateMap<ProjectAssign, ProjectNMembersDisplayVM>().ReverseMap();
            CreateMap<RegisterUserVM, User>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => "User"))
                .ReverseMap();
            CreateMap<DailyLog, DailyLogVM>().ReverseMap();
            CreateMap<DailyLogVM, DailyLogVM>().ReverseMap();
            CreateMap<ProjectRole, ProjectRoleVM>().ReverseMap();
            CreateMap<TaskModel, TaskVM>().ReverseMap();
            CreateMap<ProjectAssign,ProjectAssignVM>().ReverseMap();  
            CreateMap<Client, ClientVM>().ReverseMap();
            CreateMap<TaskAssign, TaskProjectVM>().ReverseMap();
        }
    }
}
