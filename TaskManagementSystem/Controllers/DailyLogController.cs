using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagementSystem.Services.DailyLogs;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyLogController : ControllerBase
    {
        private readonly ILogService logService;
        private readonly IHttpContextAccessor contextAccessor;

        public DailyLogController(ILogService logService, IHttpContextAccessor contextAccessor)
        {
            this.logService = logService;
            this.contextAccessor = contextAccessor;
        }

        [HttpPost]
        [Authorize]
        public IActionResult SubmitLog([FromBody] DailyLogVM log)
        {
            string Id = GetUserIDFromToken();
            logService.AddNew<DailyLog,DailyLogVM>(log,Id);

            return Ok(new { message = "Submitted Succesfully" });


        }
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        [HttpGet]
        public IActionResult ViewSpecific(Guid Id)
        {
            var loginfo = logService.GetByID<DailyLog, DailyLogVM>(Id);
            return Ok(loginfo);
        }
        [HttpGet]
        public IActionResult ViewAllLog()
        {
            var list=logService.GetAll<DailyLog,DailyLogVM>();
            return Ok(list);

        }
        [HttpDelete] 
        public IActionResult DeleteLog(Guid Id)
        { 
            if( logService.Remove<DailyLog, DailyLogVM>(Id))
            {
                return Ok("Deleted");

            }; 
           return NotFound();
        }

        protected string GetUserIDFromToken()
        {
            string token= contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            return token;

        }
    }
}
