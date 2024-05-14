using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DomainLayer.Model
{
    public class ProjectAssign:BaseClass
    {

        [ForeignKey(nameof(Project))]
        
        public Guid AssignedProjectId {  get; set; }

        public Guid UserId { get; set; }
        public Guid  ProjectRoleId { get; set; }
        public ProjectRole ProjectRole { get; set; }
        public User User { get; set; }
        public Project Project { get; set; }


    }
}
