using AutoMapper;
using DataAccessLayer.Repository.UnitOfWork;
using TaskManagementSystem.Services.GeneralService;

namespace TaskManagementSystem.Services.Clients
{
    public class ClientService : Service, IClientService
    {
        public ClientService(IMapper mapper, IUnitOfWork unit) : base(mapper, unit)
        {
        }
    }
}
