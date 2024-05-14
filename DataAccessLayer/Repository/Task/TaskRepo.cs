using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Repository.General;
using DomainLayer.Model;

namespace DataAccessLayer.Repository.Task
{
    public class TaskRepo : Repo, ITaskRepo
    {
        private readonly TaskDbContext context;
        private readonly IMapper mapper;

        public TaskRepo(TaskDbContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public bool AssignTask(TaskAssign task)
        {
            var projectid=context.Tasks.Where(c => c.Id == task.TaskId).Select(x => x.ProjectId);
            var checkid=context.ProjectMembers.Where(x => x.UserId == task.ProjectMemberId).Select(x => x.AssignedProjectId);
            if(projectid==checkid)
            {
                context.TaskProjects.Add(task);
                return true;

            }
            return false;



        }
        public void AddTask(TaskModel task, Guid id)
        {
            task.ProjectId = id;
            context.Tasks.Add(task);
        }
    }
}
