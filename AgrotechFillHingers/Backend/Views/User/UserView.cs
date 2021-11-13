using AgrotechFillHingers.Backend.Helpers;
using AgrotechFillHingers.Backend.Models.User;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrotechFillHingers.Backend.Views.User
{
    public class UserView : ViewBase
    {
        public UserView(IConfiguration configuration) : base(configuration)
        {

        }

        public List<UserModel> List()
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                List<UserModel> userModels = uow.UserRepository.GetList();

                return userModels;
            }
        }

        public UserModel Info(int id)
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                UserModel userModel = uow.UserRepository.GetFirst("where id = @id", new { id });

                return userModel;
            }
        }

        public int Insert(UserModel model)
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                string sql = @"insert into users (name) output.id values (@name)";
                int id = uow.CustomRepository.Query<int>(sql, new { name = model.name }).FirstOrDefault();

                if (id > 0)
                {
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
