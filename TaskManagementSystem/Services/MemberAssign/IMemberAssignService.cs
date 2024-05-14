using DomainLayer.ViewModels;

namespace TaskManagementSystem.Services.MemberAssign
{
    public interface IMemberAssignService
    {
        void AddMember(ProjectAssignVM member);
        List<ProjectNMembersDisplayVM> ViewMembers(Guid Id);
    }
}
