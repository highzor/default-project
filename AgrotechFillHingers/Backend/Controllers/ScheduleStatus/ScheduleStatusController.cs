using AgrotechFillHingers.Backend.Helpers;
using AgrotechFillHingers.Backend.Models.ScheduleStatus;
using AgrotechFillHingers.Backend.Views;
using AgrotechFillHingers.Backend.Views.ScheduleStatus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrotechFillHingers.Backend.Controllers.ScheduleStatus
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleStatusController : BaseController
    {
        private ScheduleStatusView _domainView;

        public ScheduleStatusController(IConfiguration configuration) : base(configuration)
        {
            _domainView = new ScheduleStatusView(configuration);
        }

        [Route("List")]
        [HttpGet]
        [ReturnType(typeof(ScheduleStatusModel))]
        public IActionResult List()
        {
            try
            {
                return Content(JsonConvert.SerializeObject(_domainView.List()));
            }
            catch (Exception ex)
            {
                string errorText = "Не удалось получить список статусов расписания.";
                if (ex is InnerViewException)
                {
                    errorText += Environment.NewLine + ex.Message;
                }

                return BadRequest(errorText);
            }
        }
    }
}
