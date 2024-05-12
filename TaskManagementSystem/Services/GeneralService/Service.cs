
using AutoMapper;
using DataAccessLayer.Repository.UnitOfWork;
using DomainLayer.Model;

namespace TaskManagementSystem.Services.GeneralService
{
    public class Service : IService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unit;

        public Service(IMapper mapper, IUnitOfWork unit)
        {
            this.mapper = mapper;
            this.unit = unit;
        }

        public void AddNew<Tmodel, TViewModel>(TViewModel viewModel) where Tmodel : BaseClass
        {

            var project = mapper.Map<Tmodel>(viewModel);
            unit.Repo.Add(project);
            unit.SaveChanges();
        }

        public void Edit<Tmodel, TViewModel>(TViewModel tmodel, Guid Id) where Tmodel : BaseClass
        {

            var model = unit.Repo.GetByID<Tmodel>(Id);
            mapper.Map(tmodel, model);
            unit.Repo.Update(model);
            unit.SaveChanges();
        }

        public List<Tmodel> GetAll<Tmodel>() where Tmodel : BaseClass
        {
            var list = unit.Repo.GetAll<Tmodel>();
            return list;

        }

        public TviewModel GetByID<Tmodel, TviewModel>(Guid id) where Tmodel : BaseClass
        {
            Tmodel project = unit.Repo.GetByID<Tmodel>(id);
            var vm = mapper.Map<TviewModel>(project);
            return vm;
        }

        public void Remove<Tmodel, TViewModel>(TViewModel tmodel) where Tmodel : BaseClass
        {
            var send = mapper.Map<Tmodel>(tmodel);
            unit.Repo.Remove(send);
        }
    }
}
