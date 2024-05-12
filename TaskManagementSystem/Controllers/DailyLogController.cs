using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagementSystem.Services.DailyLogs;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]/[Action]")]
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
            var Id = GetUserIDFromToken();
            logService.SubmitLog(log,Id);

            return Ok(new { message = "Submitted Succesfully",Id });


        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult ViewSpecific([FromBody] string name)
        {
            var loginfo = logService.ViewLog(name);
            return Ok(loginfo);
        }
        [HttpGet]
        public IActionResult ViewAllLog()
        {
            var list=logService.GetAllLogs();
            return Ok(list);

        }
        [HttpDelete] //make it better later
        public IActionResult DeleteLog([FromBody] DailyLogVM log) {  logService.DeleteLog(log); return Ok(); }

        protected string GetUserIDFromToken()
        {
            string token= contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            return token;

        }
    }
}
