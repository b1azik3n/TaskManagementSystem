﻿using DataAccessLayer.Repository.AssignMember;
using DataAccessLayer.Repository.Authentication;
using DataAccessLayer.Repository.DailyLogs;
using DataAccessLayer.Repository.General;
using DataAccessLayer.Repository.Projects;
using DataAccessLayer.Repository.Task;

namespace DataAccessLayer.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        public ILogRepo LogRepo { get; set; }
        public IAuthRepo AuthRepo { get; set; }
        public IProjectRepo ProjectRepo { get; set; }
        public IRepo Repo { get; set; }

        public IMemberAssignRepo MemberAssignRepo { get; set; }
        public ITaskRepo TaskRepo { get; set; }






        public void SaveChanges();
        public void SaveChangesAsync();

    }
}
