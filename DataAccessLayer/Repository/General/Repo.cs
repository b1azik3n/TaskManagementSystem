using AutoMapper;
using DataAccessLayer.Data;
using DomainLayer.Model;

namespace DataAccessLayer.Repository.Clients
{
    public class Repo : IRepo
    {
        private readonly TaskDbContext context;
        private readonly IMapper mapper;

        public Repo(TaskDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void Add<TModel>(TModel tmodel) where TModel : class
        {
            context.Set<TModel>().Add(tmodel);
        }

        public List<T> GetAll<T>() where T : class 
        {
            var query = context.Set<T>();
            var map = mapper.ProjectTo<T>(query);
            return map.ToList();
        }

        public Tmodel GetByID<Tmodel>(Guid id) where Tmodel:BaseClass
        {
            var project = context.Set<Tmodel>().FirstOrDefault(x => x.Id ==id); //solve this name and ID later   
            if (project == null)
            {
                return null;
            }
            return project;
        }

        public void Remove<Tmodel>(Tmodel project) where Tmodel : class
        {
            context.Set<Tmodel>().Remove(project);
        }

        public void Update<Tmodel>(Tmodel project) where Tmodel: class
        {
            context.Set<Tmodel>().Update(project);
        }
    }
}
