using AutoMapper;
using DataAccessLayer.Repository.Projects;
using DataAccessLayer.Repository.UnitOfWork;
using DomainLayer.Model;
using DomainLayer.ViewModels;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Services.Projects
{
    public class ProjectService :Service, IProjectService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unit;

        public ProjectService(IMapper mapper, IUnitOfWork unit) : base(mapper, unit)
        {
            this.mapper = mapper;
            this.unit = unit;
        }

        public void AddNew(ProjectAddVM projectVM, Guid id)
        {
            var project = mapper.Map<Project>(projectVM);
            unit.ProjectRepo.AddNew(project, id);
            unit.SaveChanges();

        }

        public void EditProject(ProjectAddVM projectVM, Guid Id)
        {
            var project = unit.ProjectRepo.GetProjectByIdMainModel(Id);
            mapper.Map(projectVM, project);
            unit.ProjectRepo.UpdateProject(project);
            unit.SaveChanges();

        }

        public List<ProjectDisplayVM> GetAllProjects()
        {
            var list = unit.ProjectRepo.GetAllProjects();
            return list;

        }

        public ProjectDisplayVM GetProjectById(Guid Id)
        {
            var project = unit.ProjectRepo.GetProjectByIdMainModel(Id);
            var vm = mapper.Map<ProjectDisplayVM>(project);
            return vm;
        }

        public void RemoveProject(Guid Id)
        {
            unit.Repo.Remove<Project>(Id);
        }
    }
    
}
