using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IService service;

        public DesignationController(IService service)
        {
            this.service = service;
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetParticular(Guid id)
        {
           var des= service.GetByID<Designation,DesignationVM>(id);
            return Ok(des);
        }
        [HttpPost]
        public IActionResult Create([FromBody] DesignationVM designation)
        {
            service.AddNew<Designation, DesignationVM>(designation);
            return Ok("Created!");

        }
    }
}
