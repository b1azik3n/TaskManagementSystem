using DomainLayer.Model;
using DomainLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Clients
{
    public interface IRepo
    {
        void Add<Tmodel>(Tmodel tmodel) where Tmodel : class;
        void Remove<Tmodel>(Tmodel project) where Tmodel : class;
        List<T> GetAll<T>() where T : class;
        Tmodel GetByID<Tmodel>(Guid name) where Tmodel : BaseClass;
        void Update<Tmodel>(Tmodel project) where Tmodel: class;
    }
}
