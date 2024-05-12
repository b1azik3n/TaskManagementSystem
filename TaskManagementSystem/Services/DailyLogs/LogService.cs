using AutoMapper;
using DataAccessLayer.Repository.UnitOfWork;
using DomainLayer.Model;
using DomainLayer.ViewModels;

namespace TaskManagementSystem.Services.DailyLogs
{
    public class LogService : ILogService
    {
        private readonly IUnitOfWork unit;
        private readonly IMapper mapper;

        public LogService(IUnitOfWork unit, IMapper mapper)
        {
            this.unit = unit;
            this.mapper = mapper;
        }

        public void SubmitLog(DailyLogVM vm, string stringID)
        {
            var log = mapper.Map<DailyLog>(vm);
            log.UserId = Guid.Parse(stringID);
            unit.LogRepo.AddLog(log);
            unit.SaveChanges();

        }
        public void DeleteLog(DailyLogVM vm)
        {
            var log = mapper.Map<DailyLog>(vm);
            unit.LogRepo.RemoveLog(log);
            unit.SaveChanges();
        }

        public DailyLogVM ViewLog(string Name)
        {
            var log = unit.LogRepo.GetLog(Name);
            var vm = mapper.Map<DailyLogVM>(log);
            return vm;
        }

        public List<DailyLogVM> GetAllLogs()
        {
            var list = unit.LogRepo.GetAllLogs<DailyLog, DailyLogVM>();
            //List<DailyLogVM> newlist= new List<DailyLogVM>();
            //foreach (var log in list)
            //{
            //   var newlog=mapper.Map<DailyLogVM>(log);
            //    newlist.Add(newlog);

            //}
            return list;
        }
    }
}
