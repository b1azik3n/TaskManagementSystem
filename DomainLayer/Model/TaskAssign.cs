using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class TaskAssign:BaseClass
    {
        [ForeignKey(nameof(ProjectMember))]
        public Guid ProjectMemberId {  get; set; }
        [ForeignKey(nameof(task))]
        public Guid TaskId { get; set; }
        public DateTime Assigned_On { get; set; }
        public TaskModel task { get; set; }
        public ProjectAssign ProjectMember { get; set; }



    }
}
