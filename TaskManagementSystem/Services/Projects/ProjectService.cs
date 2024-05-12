using AutoMapper;
using DataAccessLayer.Repository.Projects;
using DataAccessLayer.Repository.UnitOfWork;
using DomainLayer.Model;
using DomainLayer.ViewModels;

namespace TaskManagementSystem.Services.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unit;

        public ProjectService(IMapper mapper, IUnitOfWork unit)
        {
            this.mapper = mapper;
            this.unit = unit;
        }

        public void AddNewProject(ProjectVM projectVM)
        {
            var project = Mapper.Map<Project>(projectVM);
            unit.ProjectRepo.AddNewProject(project);
            unit.SaveChanges();

        }

        public void EditProject(ProjectVM projectVM)
        {
            var project = unit.ProjectRepo.GetProjectByName(projectVM.Name);
            mapper.Map(projectVM, project);
            unit.ProjectRepo.UpdateProject(project);
            unit.SaveChanges();

        }

        public List<ProjectVM> GetAllProjects()
        {
            var list = unit.ProjectRepo.GetAllProjects();
            return list;

        }

        public ProjectVM GetProjectByName(string name)
        {
            var project = unit.ProjectRepo.GetProjectByName(name);
            var vm = mapper.Map<ProjectVM>(project);
            return vm;
        }

        public void RemoveProject(ProjectVM project)
        {
            var send = mapper.Map<Project>(project);
            unit.ProjectRepo.RemoveProject(send);
        }
    }
    
}
