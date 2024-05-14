using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Services.MemberAssign;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class MemberAssignmentController : ControllerBase
    {
        private readonly IMemberAssignService service;

        public MemberAssignmentController(IMemberAssignService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult AssignMember([FromBody] ProjectAssignVM projectMemberVM)
        {
            service.AddMember(projectMemberVM);
            return Ok("AddedMemberToProject");
                   
        }
        [HttpPost]
        [Route("{id}")]
        public IActionResult ViewMembersOfProject(Guid id)
        {
            List<ProjectNMembersDisplayVM> details =service.ViewMembers(id);
            return Ok(details);

        }
    }
}
