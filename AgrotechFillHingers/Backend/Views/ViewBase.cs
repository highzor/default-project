using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrotechFillHingers.Backend.Views
{
    public abstract class ViewBase
    {
        protected IConfiguration _config;

        public ViewBase(IConfiguration configuration)
        {
            _config = configuration;
        }

        public string GetConnectionString()
        {
            //string val = _config.GetSection("PostgreSql").GetSection("ConnectionString").Value;
            string val = "Server=ec2-54-74-14-109.eu-west-1.compute.amazonaws.com;Database=d5lhga5iqi95v0;Port=5432;User Id=rpbvwnisjoulko;Password=906eaa544d26699d346751134974f49b5c6999b3766c373cf94095b16fbf4d83;";
            return val;
        }

    }

    [Serializable]
    class InnerViewException : Exception
    {
        public InnerViewException() { }

        public InnerViewException(string errorText): base(errorText)
        {

        }
    }
}
