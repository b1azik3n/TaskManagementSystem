using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Services.GeneralService;
using TaskManagementSystem.Services.Projects;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService service;

        public ProjectController(IProjectService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("{ClientId}")]
        public IActionResult AddProject([FromBody] ProjectAddVM project,Guid ClientId)
        {
            service.AddNew(project,ClientId);
            return Ok("Added");

        }
        [HttpGet]
        public IActionResult GetAllProjects()
        {
            var list = service.GetAll<Project,ProjectAddVM>();
            return Ok(list);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get_A_Project(Guid Id) {
            var project = service.GetProjectById(Id);
            return Ok(project);
        }
        [HttpPut]
        public IActionResult UpdateProject([FromBody] ProjectAddVM project, Guid Id)
        {
            service.Edit<Project, ProjectAddVM>(project, Id);
            var updated = service.GetByID<Project,ProjectAddVM>(Id);
            return Ok(new { message = "Updated", updated });

        }
        [HttpDelete]
        public IActionResult DeleteProject(Guid id)
        {
            
            if(service.Remove <Project, ProjectAddVM>(id))
            {
                return Ok("deleted");
            };
            return NotFound();
        }
       
        
    }

}
