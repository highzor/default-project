using AgrotechFillHingers.Backend.Helpers;
using AgrotechFillHingers.Backend.Models.Tasks;
using AgrotechFillHingers.Backend.Views;
using AgrotechFillHingers.Backend.Views.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrotechFillHingers.Backend.Controllers.Tasks
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : BaseController
    {
        private TasksView _domainView;

        public TasksController(IConfiguration configuration) : base(configuration)
        {
            _domainView = new TasksView(configuration);
        }


        [Route("List")]
        [HttpGet]
        [ReturnType(typeof(List<TasksModel>))]
        public IActionResult List()
        {
            try
            {
                return Content(JsonConvert.SerializeObject(_domainView.List()));
            }
            catch (Exception ex)
            {
                string errorText = "Не удалось получить список заданий.";
                if (ex is InnerViewException)
                {
                    errorText += Environment.NewLine + ex.Message;
                }

                return BadRequest(errorText);
            }
        }

        [Route("Info")]
        [HttpGet]
        [ReturnType(typeof(TasksModel))]
        public IActionResult Info(int id)
        {
            try
            {
                return Content(JsonConvert.SerializeObject(_domainView.Info(id)));
            }
            catch (Exception ex)
            {
                string errorText = "Не удалось получить информацию о задании.";
                if (ex is InnerViewException)
                {
                    errorText += Environment.NewLine + ex.Message;
                }

                return BadRequest(errorText);
            }
        }
    }

}
