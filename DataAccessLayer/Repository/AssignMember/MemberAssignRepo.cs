using AutoMapper.Configuration.Conventions;
using DataAccessLayer.Data;
using DomainLayer.Model;
using DomainLayer.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.AssignMember
{
    public class MemberAssignRepo : IMemberAssignRepo
    {
        private readonly TaskDbContext context;

        public MemberAssignRepo(TaskDbContext context)
        {
            this.context = context;
        }

        public void AddMember(ProjectAssign member)
        {
            context.ProjectMembers.Add(member);

        }
        public List<ProjectNMembersDisplayVM> GetMembers(Guid id)
        {
            List<ProjectAssign> project = context.ProjectMembers
                .Include(x => x.Project)
                .Include(x => x.User)
                .Where(x => x.AssignedProjectId == id)
                .ToList();
            //projectionn betterment tryy


            List<ProjectNMembersDisplayVM> mainlist = context.ProjectMembers
                .Where(x => x.AssignedProjectId == id)
                .Select(x => new ProjectNMembersDisplayVM
                {
                    ProjectName = x.Project.Name,
                    UserName = x.User.Name,
                    ProjectRole = x.ProjectRole.Name
                })
                .ToList();
            return mainlist;

            //foreach (var loop in project)
            //{
            //   var user= context.Users.FirstOrDefault(x => x.Id == loop.UserId);
            //   var projects = context.Projects.FirstOrDefault(x => x.Id == loop.Assigned_ProjectId);
            //   var role =context.ProjectRoles.FirstOrDefault(x => x.Id == loop.ProjectRoleId);
            //    ProjectNMembersDisplayVM data = new ProjectNMembersDisplayVM
            //    {
            //        ProjectName = projects.Name,
            //        UserName = user.Name,
            //        ProjectRole = role.Name
            //    };
            //    mainlist.Add(data);
            //}
            //return mainlist;
            

        }
    }
}
