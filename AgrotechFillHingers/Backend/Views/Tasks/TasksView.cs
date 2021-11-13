using System.Collections.Generic;
using AgrotechFillHingers.Backend.Helpers;
using AgrotechFillHingers.Backend.Models.Task_status_history;
using AgrotechFillHingers.Backend.Models.Tasks;
using Microsoft.Extensions.Configuration;

namespace AgrotechFillHingers.Backend.Views.Tasks
{
    public class TasksView : ViewBase
    {
        public TasksView(IConfiguration configuration) : base(configuration)
        {

        }
        
        public List<TasksModel> List()
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                List<TasksModel> models = uow.TasksRepository.GetList();
                return models;
            }
        }

        public TasksModel Info(int id)
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                TasksModel model = uow.TasksRepository.GetFirst("where id = @id", new { id });

                return model;
            }
        }
    }
}