using DomainLayer.Model;

namespace DomainLayer.ViewModels
{
    public class ProjectAssignVM
    {
        public Guid AssignedProjectId { get; set; }

        public Guid UserId { get; set; }
        public Guid ProjectRoleId { get; set; }

    }
}
