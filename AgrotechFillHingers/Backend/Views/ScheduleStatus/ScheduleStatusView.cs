using AgrotechFillHingers.Backend.Helpers;
using AgrotechFillHingers.Backend.Models.ScheduleStatus;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrotechFillHingers.Backend.Views.ScheduleStatus
{
    public class ScheduleStatusView : ViewBase
    {
        public ScheduleStatusView(IConfiguration configuration) : base(configuration)
        {

        }

        public List<ScheduleStatusModel> List()
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                List<ScheduleStatusModel> userModels = uow.ScheduleStatusRepository.GetList();

                return userModels;
            }
        }
    }
}
