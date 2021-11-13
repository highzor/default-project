using AgrotechFillHingers.Backend.Helpers;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
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
        
        public int Insert(UsersModel model)
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                string sql = @"insert into users (name, surname, second_name, type_id, status_id, create_date, 
                    phone, birthday_date, description, email) 
                    output.id values (@name, @surname, @secondName,@typeId,@statusId,@createDate,
                    @phone, @birthdayDate,@description,@email)";
                int id = uow.CustomRepository.Query<int>(sql, new
                {
                    name = model.name,
                    surname = model.surname,
                    secondName = model.second_name,
                    typeId = model.type_id,
                    statusId = model.status_id,
                    createDate = model.create_date,
                    phone = model.phone,
                    bitrhdayDate = model.birthday_date,
                    description = model.description,
                    email = model.email
                }).FirstOrDefault();

                if (id > 0)
                {
                    switch (model.type_id)
                    {
                        case 1:
                        {
                            sql = @"INSERT INTO volunteers (user_id) 
                                output.id values (@userId)";
                            int result = uow.CustomRepository.Query<int>(sql, new {userId = id}).FirstOrDefault();
                            break;
                        }
                        case 2:
                        {
                            sql = @"INSERT INTO curators (user_id) 
                                output.id values (@userId)";
                            int result = uow.CustomRepository.Query<int>(sql, new {userId = id}).FirstOrDefault();
                            break;
                        }
                    }
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