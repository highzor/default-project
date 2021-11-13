using AgrotechFillHingers.Backend.Helpers;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using AgrotechFillHingers.Backend.Models.Users;

namespace AgrotechFillHingers.Backend.Views.Users
{
    public class UsersView : ViewBase
    {
        public UsersView(IConfiguration configuration) : base(configuration)
        {

        }

        public List<UsersModel> List()
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                List<UsersModel> models = uow.UsersRepository.GetList();

                return models;
            }
        }

        public UsersModel Info(int id)
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                UsersModel userModel = uow.UsersRepository.GetFirst("where id = @id", new { id });

                return userModel;
            }
        }
    }
}