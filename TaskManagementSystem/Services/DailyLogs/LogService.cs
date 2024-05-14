using AutoMapper;
using DataAccessLayer.Repository.UnitOfWork;
using DomainLayer.Model;
using DomainLayer.ViewModels;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Services.DailyLogs
{
    public class LogService : Service, ILogService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unit;

        public LogService(IMapper mapper, IUnitOfWork unit) : base(mapper, unit)
        {
            this.mapper = mapper;
            this.unit = unit;
        }

        public void AddNew<Tmodel, TViewModel>(TViewModel viewModel, string stringID) where Tmodel : BaseClass
        {
            var log = mapper.Map<DailyLog>(viewModel);
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
