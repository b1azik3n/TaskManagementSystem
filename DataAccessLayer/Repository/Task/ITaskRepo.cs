using DataAccessLayer.Repository.General;
using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Task
{
    public interface ITaskRepo : IRepo
    {
        void AddTask(TaskModel task, Guid id);
        bool AssignTask(TaskAssign task);
    }
}
