using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Services.Clients;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService service;

        public ClientController(IClientService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult CreateClient([FromBody] ClientVM task)
        {
            service.AddNew<Client, ClientVM>(task);
            return Ok("added");

        }
        [HttpGet]
        public IActionResult GetAllClients()
        {
            var list = service.GetAll<Client,ClientVM>();
            return Ok(list);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetParticular(Guid id)
        {
            var task = service.GetByID<Client, ClientVM>(id);
            return Ok(task);
        }
        [HttpPut]
        [Route("{id}")]


        public IActionResult UpdateClient([FromBody] ClientVM task, Guid id)
        {
            service.Edit<Client, ClientVM>(task, id);
            var updated = service.GetByID<Client, ClientVM>(id);
            return Ok(new { message = "Updated", updated });

        }
        [HttpDelete]
        [Route("{id}")]


        public IActionResult DeleteClient(Guid Id)
        {
            if( service.Remove<Client, ClientVM>(Id))
            {
                return NotFound("User Doesn't Exist");

            }
            return Ok("Deleted");
        }
    }
}
