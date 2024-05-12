using DomainLayer.Enum;

namespace DomainLayer.ViewModels
{
    public class TaskVM
    {
        public string Name { get; set; }
        public TaskType Type { get; set; }
        public Status Status { get; set; }
        public string Description { get; set; }
        public DateTime Assigned_On { get; set; }
        public DateTime Expected_Completion { get; set; }
    }
}
