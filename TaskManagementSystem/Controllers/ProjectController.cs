using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using TaskManagementSystem.Services.Projects;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService service;

        public ProjectController(IProjectService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult AddProject([FromBody] ProjectVM project)
        {
            service.AddNewProject(project);
            return Ok("Added");
            
        }
        [HttpGet]
        public IActionResult GetAllProjects()
        {
          var list= service.GetAllProjects();
            return Ok(list);
        }
        [HttpGet]
        public IActionResult Get_A_Project(string Name) {
            var project=service.GetProjectByName(Name);
            return Ok("project");
        }
        [HttpPost]
        public IActionResult EditProject([FromBody] ProjectVM project)
        {
            service.EditProject(project);
            var updated=service.GetProjectByName(project.Name);
            return Ok(new {message="Updated",updated});
           
        }
        [HttpDelete]
        public IActionResult DeleteProject([FromBody] ProjectVM project)
        {
            service.RemoveProject(project); 
            return Ok();
        }
    }

}
