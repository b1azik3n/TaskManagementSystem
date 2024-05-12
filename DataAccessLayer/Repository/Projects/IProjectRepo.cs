using DomainLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Model;

namespace DataAccessLayer.Repository.Projects
{
    public interface IProjectRepo
    {
        void AddNewProject(Project project);
        void RemoveProject(Project project);
        List<ProjectVM> GetAllProjects();
        Project GetProjectByName(string name);
        void UpdateProject (Project project);
    }
}
