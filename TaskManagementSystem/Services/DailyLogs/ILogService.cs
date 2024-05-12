using DomainLayer.ViewModels;

namespace TaskManagementSystem.Services.DailyLogs
{
    public interface ILogService
    {
        void SubmitLog(DailyLogVM vm, string token);
        void DeleteLog(DailyLogVM vm);
        DailyLogVM ViewLog(string Name);
        List<DailyLogVM> GetAllLogs();


    }
}
