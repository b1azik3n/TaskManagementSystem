using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Services.Tasks;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService service;

        public TaskController(ITaskService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("{ProjectId}")]
        public IActionResult CreateTask([FromBody] TaskVM task,Guid ProjectId)
        {
            service.CreateTask(task,ProjectId);
            return Ok("added");

        }
        [HttpGet]

        public IActionResult GetAllTasks()
        {
            var list = service.GetAll<TaskModel,TaskVM>();
            return Ok(list);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetParticular(Guid id)
        {
            var task = service.GetByID<TaskModel, TaskVM>(id);
            return Ok(task);
        }
        [HttpPut]
        [Route("{id}")]


        public IActionResult EditTask([FromBody] TaskVM task, Guid id)
        {
                service.Edit<TaskModel,TaskVM>(task,id);
                var updated=service.GetByID<TaskModel,TaskVM> (id);
                return Ok(new { message = "Updated", updated });

        }
        [HttpDelete]
        [Route("{id}")]
            public IActionResult DeleteTask(Guid Id)
            {
               if( service.Remove<TaskModel,TaskVM>(Id))
               {
                return Ok("Deleted");


               };
                return NotFound();
            }
       
    }
    
}
