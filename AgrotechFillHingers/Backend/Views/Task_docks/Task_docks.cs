using System.Collections.Generic;
using AgrotechFillHingers.Backend.Helpers;
using AgrotechFillHingers.Backend.Models.Task_docks;
using Microsoft.Extensions.Configuration;

namespace AgrotechFillHingers.Backend.Views.Task_docks
{
    public class Task_docksView : ViewBase
    {
        public Task_docksView(IConfiguration configuration) : base(configuration)
        {

        }
        
        public List<Task_docksModel> List()
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                List<Task_docksModel> models = uow.TaskDocksRepository.GetList();
                return models;
            }
        }

        public Task_docksModel Info(int id)
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                Task_docksModel model = uow.TaskDocksRepository.GetFirst("where id = @id", new { id });

                return model;
            }
        }
    }
}