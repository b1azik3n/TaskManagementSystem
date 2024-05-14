using DomainLayer.ViewModels;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Services.Projects
{
    public interface IProjectService:IService
    {
        void AddNew(ProjectAddVM project, Guid id);
        List<ProjectDisplayVM> GetAllProjects();
        ProjectDisplayVM GetProjectById(Guid Id);
        public void EditProject(ProjectAddVM projectVM, Guid Id);

    }
}
