using DomainLayer.Model;

namespace DataAccessLayer.Repository.DailyLogs
{
    public interface ILogRepo
    {
        void AddLog(DailyLog log);
        void RemoveLog(DailyLog log);
        DailyLog GetLog(string Name);

        List<TViewModel> GetAllLogs<TModel, TViewModel>() where TModel : class;

    }
}
