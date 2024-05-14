using AutoMapper;
using DataAccessLayer.Repository.Task;
using DataAccessLayer.Repository.UnitOfWork;
using DomainLayer.Model;
using DomainLayer.ViewModels;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Services.Tasks
{
    public class TaskService : Service, ITaskService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unit;

        public TaskService(IMapper mapper, IUnitOfWork unit) : base(mapper, unit)
        {
            this.mapper = mapper;
            this.unit = unit;
        }

        public bool AssignTask(TaskProjectVM taskProjectVM)
        {
            var send = mapper.Map<TaskAssign>(taskProjectVM);
            var assign = unit.TaskRepo.AssignTask(send);
            if (assign == true)
            {
                return true;
                unit.SaveChanges();

            }
            return false;
            //return unit.TaskRepo.AssignTask(send);

        }

        public void CreateTask(TaskVM taskProjectVM,Guid id)
        {
            var send= mapper.Map<TaskModel>(taskProjectVM);
            unit.TaskRepo.AddTask(send, id);
           
            
            unit.SaveChanges();
            
            
        }

    }
}
