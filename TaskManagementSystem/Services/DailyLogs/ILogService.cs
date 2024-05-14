﻿using DomainLayer.Model;
using DomainLayer.ViewModels;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Services.DailyLogs
{
    public interface ILogService: IService
    {
        void AddNew<Tmodel, TViewModel>(TViewModel vm, string token) where Tmodel : BaseClass;
        void DeleteLog(DailyLogVM vm);
        DailyLogVM ViewLog(string Name);
        List<DailyLogVM> GetAllLogs();


    }
}
