using System.Collections.Generic;
using AgrotechFillHingers.Backend.Helpers;
using AgrotechFillHingers.Backend.Models.Acts;
using Microsoft.Extensions.Configuration;

namespace AgrotechFillHingers.Backend.Views.Acts
{
    public class ActsView : ViewBase
    {
        public ActsView(IConfiguration configuration) : base(configuration)
        {

        }
        
        public List<ActsModel> List()
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                List<ActsModel> models = uow.ActsRepository.GetList();
                return models;
            }
        }

        public ActsModel Info(int id)
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                ActsModel model = uow.ActsRepository.GetFirst("where id = @id", new { id });

                return model;
            }
        }
    }
}