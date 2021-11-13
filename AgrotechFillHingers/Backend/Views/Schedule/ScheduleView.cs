using AgrotechFillHingers.Backend.Helpers;
using AgrotechFillHingers.Backend.Models.Schedule;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrotechFillHingers.Backend.Views.Schedule
{
    public class ScheduleView : ViewBase
    {
        public ScheduleView(IConfiguration configuration) : base(configuration)
        {

        }

        public List<ScheduleModel> List()
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                List<ScheduleModel> scheduleModels = uow.ScheduleRepository.GetList();
                return scheduleModels;
            }
        }

        public ScheduleModel Info(int id)
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                ScheduleModel userModel = uow.ScheduleRepository.GetFirst("where id = @id", new { id });

                return userModel;
            }
        }
    }
}
