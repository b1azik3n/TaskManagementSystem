namespace DomainLayer.Model
{
    public class ProjectMember:BaseClass
    {

        public Guid UserId { get; set; }
        public Guid  DesignationId { get; set; }
        public Designation Designation { get; set; }
        public User User { get; set; }


    }
}
