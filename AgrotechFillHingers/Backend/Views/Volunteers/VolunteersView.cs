using System.Collections.Generic;
using AgrotechFillHingers.Backend.Helpers;
using AgrotechFillHingers.Backend.Models.Volunteers;
using Microsoft.Extensions.Configuration;

namespace AgrotechFillHingers.Backend.Views.Volunteers
{
    public class VolunteersView : ViewBase
    {
        
        public VolunteersView(IConfiguration configuration) : base(configuration)
        {

        }
        
        public List<VolunteersModel> List()
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                List<VolunteersModel> models = uow.VolunteersRepository.GetList();
                return models;
            }
        }

        public VolunteersModel Info(int id)
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                VolunteersModel model = uow.VolunteersRepository.GetFirst("where id = @id", new { id });

                return model;
            }
        }
    }
}