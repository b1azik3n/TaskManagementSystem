using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IService service;

        public TaskController(IService service)
        {
            this.service = service;
        }
        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskVM task)
        {
            service.AddNew<TaskModel, TaskVM>(task);
            return Ok("added");

        }
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var list = service.GetAll<TaskModel>();
            return Ok(list);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetParticular(Guid id)
        {
            var task = service.GetByID<TaskModel, TaskVM>(id);
            return Ok(task);
        }
        [HttpPost]
        [Route("{id}")]


        public IActionResult EditTask([FromBody] TaskVM task, Guid id)
        {
                service.Edit<TaskModel,TaskVM>(task,id);
                var updated=service.GetByID<TaskModel,TaskVM> (id);
                return Ok(new { message = "Updated", updated });

        }
        [HttpDelete]
            public IActionResult DeleteProject([FromBody] TaskVM task)
            {
                service.Remove<TaskModel,TaskVM>(task);
                return Ok();
            }
        }
}
