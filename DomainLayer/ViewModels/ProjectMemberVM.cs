using DomainLayer.Model;

namespace DomainLayer.ViewModels
{
    public class ProjectMemberVM
    {
        public string Name { get; set; }
        public string Email { get; set; }

        List<ProjectMember> projectMembers { get; set; }

    }
}
