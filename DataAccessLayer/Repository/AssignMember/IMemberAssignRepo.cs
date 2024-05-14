using DomainLayer.Model;
using DomainLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.AssignMember
{
    public interface IMemberAssignRepo
    {
        void AddMember(ProjectAssign member);
        List<ProjectNMembersDisplayVM> GetMembers(Guid id);

    }
}
