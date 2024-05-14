using DomainLayer.ViewModels;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Services.Tasks
{
    public interface ITaskService: IService
    {
         bool AssignTask(TaskProjectVM taskProjectVM);


        void CreateTask(TaskVM taskVM, Guid id);

    }
}
