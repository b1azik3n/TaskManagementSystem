using DomainLayer.ViewModels;

namespace TaskManagementSystem.Services.Projects
{
    public interface IProjectService
    {
        void AddNewProject(ProjectVM project);
        void RemoveProject(ProjectVM project);
        List<ProjectVM> GetAllProjects();
        ProjectVM GetProjectByName(string name);
        void EditProject(ProjectVM project);
    }
}
