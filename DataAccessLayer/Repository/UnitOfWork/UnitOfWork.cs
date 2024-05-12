using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Repository.Authentication;
using DataAccessLayer.Repository.Clients;
using DataAccessLayer.Repository.DailyLogs;
using DataAccessLayer.Repository.Projects;

namespace DataAccessLayer.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskDbContext context;

        public UnitOfWork(TaskDbContext context, IMapper mapper)
        {
            LogRepo = new LogRepo(context, mapper);
            this.context = context;
            AuthRepo = new AuthRepo(context); 
            ProjectRepo = new ProjectRepo(context,mapper);
            Repo= new Repo(context,mapper);

        }

        public ILogRepo LogRepo { get; set; }
        public IAuthRepo AuthRepo { get; set; }
        public IProjectRepo ProjectRepo { get; set; }
        public IRepo Repo { get; set; }

        public void SaveChanges()
        {

            context.SaveChanges();
        }

        public void SaveChangesAsync()
        {
            context.SaveChangesAsync();
        }
    }
}
