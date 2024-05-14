using DomainLayer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class TaskModel:BaseClass
    {

        public string Name { get; set; }
        public TaskType Type { get; set; }
        public Status Status { get; set; }
        public string Description { get; set; }
        public DateTime Expected_Completion {  get; set; }
        [ForeignKey(nameof(Project))]
        public Guid ProjectId { get; set; } 
        public Project Project { get; set; }
       
        
    }
}
