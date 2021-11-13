using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrotechFillHingers.Backend.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected IConfiguration _config;

        public BaseController(IConfiguration configuration)
        {
            _config = configuration;
        }
    }
}
