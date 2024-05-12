using AutoMapper;
using DataAccessLayer.Data;
using DomainLayer.Enum;
using DomainLayer.Model;
using DomainLayer.ViewModels;

namespace DataAccessLayer.Repository.Projects
{
    public class ProjectRepo : IProjectRepo
    {
        private readonly TaskDbContext context;
        private readonly IMapper mapper;

        public ProjectRepo(TaskDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddNewProject(Project project)
        {
            project.Status = Status.Started;
            context.Projects.Add(project);

        }

        public List<ProjectVM> GetAllProjects()
        {
            var query = context.Projects;
            var map= mapper.ProjectTo<ProjectVM>(query);
            return map.ToList();
        }

        public Project GetProjectByName(string name)
        {
            var project= context.Projects.FirstOrDefault(x => x.Name == name);
            if (project == null)
            {
                return null;
            }
            return project;
        }

        public void RemoveProject(Project project)
        {
            context.Projects.Remove(project);

        }

        public void UpdateProject(Project project)
        {
            context.Projects.Update(project);
        }
    }
}
