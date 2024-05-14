using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Services.Tasks;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskAssignmentController : ControllerBase
    {
        private readonly ITaskService service;

        public TaskAssignmentController(ITaskService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult AssignTask([FromBody] TaskProjectVM taskProjectVM)
        {
            if (service.AssignTask(taskProjectVM))
            {
                return Ok("task Assigned"); //kasle k ma kk you can do..
            }
            return BadRequest("MemberNotAssignedToProjectItSeems");
        }
    }
}
