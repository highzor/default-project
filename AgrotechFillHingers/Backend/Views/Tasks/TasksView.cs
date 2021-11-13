using System.Collections.Generic;
using System.Linq;
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
        
        public int Insert(TasksModel model)
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                string sql = @"insert into users (name, curator_id, create_date, status_id,partner_id,type_id, 
                    address_id,delivery_time, description, delivery_date) 
                    output.id values (@name, @curatorId, @createDate,@statusId,@partnerId,@typeId,
                    @addressId, @deliveryTime,@description,@deliveryDate)";
                int id = uow.CustomRepository.Query<int>(sql, new
                {
                    name = model.name,
                    curatorId = model.curator_id,
                    createDate = model.create_date,
                    statusId = model.status_id,
                    partnerId = model.partner_id,
                    typeId = model.type_id,
                    addressId = model.address_id,
                    deliveryTime = model.delivery_time,
                    description = model.description,
                    deliveryDate = model.delivery_date
                }).FirstOrDefault();

                if (id > 0)
                {
                    sql = @"insert into task_status_history (task_id,new_status_id,
                                 change_datetime, description) 
                        values
                        (@taskId,@newStatusId,@changeDatetime,@description)";
                    int result = uow.CustomRepository.Query<int>(sql, new
                    {
                        taskId = id,
                        newStatusId = 1,
                        changeDatetime = model.create_date,
                        description = "Создано новое задание"
                    }).FirstOrDefault();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}