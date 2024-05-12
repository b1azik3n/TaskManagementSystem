using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repository.Authentication;
using DataAccessLayer.Repository.Clients;
using DataAccessLayer.Repository.DailyLogs;
using DataAccessLayer.Repository.Projects;

namespace DataAccessLayer.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        public ILogRepo LogRepo { get; set; }
        public IAuthRepo AuthRepo { get; set; }
        public IProjectRepo ProjectRepo { get; set; }
        public IRepo Repo { get; set; }



        public void SaveChanges();
        public void SaveChangesAsync();

    }
}
