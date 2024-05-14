using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectRoleController : ControllerBase
    {
        private readonly IService service;

        public ProjectRoleController(IService service)
        {
            this.service = service;
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetParticular(Guid id)
        {
           var des= service.GetByID<ProjectRole,ProjectRoleVM>(id);
            return Ok(des);
        }
        [HttpGet]
        public IActionResult GetAllRoles()
        { 
            var roles=service.GetAll<ProjectRole,ProjectRoleVM>();
            return Ok(roles);
        
        }
        [HttpPost]
        public IActionResult Create([FromBody] ProjectRoleVM designation)
        {
            service.AddNew<ProjectRole, ProjectRoleVM>(designation);
            return Ok("Created!");

        }
    }
}
