using AgrotechFillHingers.Backend.Helpers;
using AgrotechFillHingers.Backend.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrotechFillHingers.Backend.Views.User
{
    public class UserView : ViewBase
    {
        public UserView()
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
                UserModel userModel = uow.UserRepository.GetByID(id);

                return userModel;
            }
        }
    }
}
