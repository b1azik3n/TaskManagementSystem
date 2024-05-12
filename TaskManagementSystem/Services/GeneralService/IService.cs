using DomainLayer.Model;
using DomainLayer.ViewModels;

namespace TaskManagementSystem.Services.GeneralService
{
    public interface IService
    {
        void AddNew<Tmodel, TViewModel>(TViewModel tmodel) where Tmodel : BaseClass;
        void Remove<Tmodel, TViewModel>(TViewModel tmodel) where Tmodel : BaseClass;
        List<Tmodel> GetAll<Tmodel>() where Tmodel : BaseClass;
        TviewModel GetByID<Tmodel, TviewModel>(Guid name) where Tmodel : BaseClass;
        void Edit<Tmodel,TViewModel>(TViewModel tmodel, Guid Id) where Tmodel : BaseClass;
    }
}
