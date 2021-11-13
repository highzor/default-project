using AgrotechFillHingers.Backend.Helpers;
using AgrotechFillHingers.Backend.Models.Schedule;
using AgrotechFillHingers.Backend.Views;
using AgrotechFillHingers.Backend.Views.Schedule;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrotechFillHingers.Backend.Controllers.Schedule
{

    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : BaseController
    {
        private ScheduleView _domainView;

        public ScheduleController(IConfiguration configuration) : base(configuration)
        {
            _domainView = new ScheduleView(configuration);
        }

        [Route("List")]
        [HttpGet]
        [ReturnType(typeof(ScheduleModel))]
        public IActionResult List()
        {
            try
            {
                return Content(JsonConvert.SerializeObject(_domainView.List()));
            }
            catch (Exception ex)
            {
                string errorText = "Не удалось получить расписание.";
                if (ex is InnerViewException)
                {
                    errorText += Environment.NewLine + ex.Message;
                }

                return BadRequest(errorText);
            }
        }

        [Route("Info")]
        [HttpGet]
        [ReturnType(typeof(ScheduleModel))]
        public IActionResult Info(int id)
        {
            try
            {
                return Content(JsonConvert.SerializeObject(_domainView.Info(id)));
            }
            catch (Exception ex)
            {
                string errorText = "Не удалось получить информацию о расписании.";
                if (ex is InnerViewException)
                {
                    errorText += Environment.NewLine + ex.Message;
                }

                return BadRequest(errorText);
            }
        }
    }

}
