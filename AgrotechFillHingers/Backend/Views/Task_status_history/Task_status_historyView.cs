using System.Collections.Generic;
using AgrotechFillHingers.Backend.Helpers;
using AgrotechFillHingers.Backend.Models.Task_status_history;
using Microsoft.Extensions.Configuration;

namespace AgrotechFillHingers.Backend.Views.Task_status_history
{
    public class Task_status_historyView : ViewBase
    {
        public Task_status_historyView(IConfiguration configuration) : base(configuration)
        {

        }
        
        public List<Task_status_historyModel> List()
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                List<Task_status_historyModel> models = uow.TaskStatusHistoryRepository.GetList();
                return models;
            }
        }

        public Task_status_historyModel Info(int id)
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                Task_status_historyModel model = uow.TaskStatusHistoryRepository.GetFirst("where id = @id", new { id });

                return model;
            }
        }
    }
}