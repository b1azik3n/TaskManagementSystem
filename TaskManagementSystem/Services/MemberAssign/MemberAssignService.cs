using AutoMapper;
using DataAccessLayer.Repository.UnitOfWork;
using DomainLayer.Model;
using DomainLayer.ViewModels;

namespace TaskManagementSystem.Services.MemberAssign
{
    public class MemberAssignService : IMemberAssignService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unit;

        public MemberAssignService(IMapper mapper, IUnitOfWork unit)
        {
            this.mapper = mapper;
            this.unit = unit;
        }

        public void AddMember(ProjectAssignVM project)
        {
            var send = mapper.Map<ProjectAssign>(project);
            unit.MemberAssignRepo.AddMember(send);
            unit.SaveChanges();

        }

        public List<ProjectNMembersDisplayVM> ViewMembers(Guid Id)
        {
            var data = unit.MemberAssignRepo.GetMembers(Id);
            return data;

        }
    }
}
