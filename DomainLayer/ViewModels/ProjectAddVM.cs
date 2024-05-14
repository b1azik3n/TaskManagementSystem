using DomainLayer.Enum;
using Microsoft.VisualBasic;

namespace DomainLayer.ViewModels
{
    public class ProjectAddVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
        //public Guid? ClientId { get; set; } //co





    }
}
