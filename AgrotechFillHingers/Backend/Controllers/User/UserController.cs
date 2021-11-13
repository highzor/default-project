using AgrotechFillHingers.Backend.Helpers;
using AgrotechFillHingers.Backend.Models.User;
using AgrotechFillHingers.Backend.Views;
using AgrotechFillHingers.Backend.Views.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrotechFillHingers.Backend.Controllers.User
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: BaseController
    {
        private UserView _domainView;

        public UserController(IConfiguration configuration) : base(configuration)
        {
            _domainView = new UserView(configuration);
        }


        [Route("List")]
        [HttpGet]
        [ReturnType(typeof(UserModel))]
        public IActionResult List()
        {
            try
            {
                return Content(JsonConvert.SerializeObject(_domainView.List()));
            }
            catch(Exception ex)
            {
                string errorText = "Не удалось получить список пользователей.";
                if (ex is InnerViewException)
                {
                    errorText += Environment.NewLine + ex.Message;
                }

                return BadRequest(errorText);
            }
        }

        [Route("Info")]
        [HttpGet]
        [ReturnType(typeof(UserModel))]
        public IActionResult Info(int id)
        {
            try
            {
                return Content(JsonConvert.SerializeObject(_domainView.Info(id)));
            }
            catch (Exception ex)
            {
                string errorText = "Не удалось получить информацию о пользователе.";
                if (ex is InnerViewException)
                {
                    errorText += Environment.NewLine + ex.Message;
                }

                return BadRequest(errorText);
            }
        }

        [Route("Insert")]
        [HttpPost]
        [ReturnType(typeof(int))]
        public IActionResult Insert(UserModel userModel)
        {
            try
            {
                return Content(JsonConvert.SerializeObject(_domainView.Insert(userModel)));
            }
            catch (Exception ex)
            {
                string errorText = "Не удалось добавить пользователя.";
                if (ex is InnerViewException)
                {
                    errorText += Environment.NewLine + ex.Message;
                }

                return BadRequest(errorText);
            }
        }
    }

}
