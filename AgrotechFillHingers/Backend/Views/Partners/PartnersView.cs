using System.Collections.Generic;
using AgrotechFillHingers.Backend.Helpers;
using AgrotechFillHingers.Backend.Models.Partners;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Configuration;

namespace AgrotechFillHingers.Backend.Views.Partners
{
    public class PartnersView : ViewBase
    {
        public PartnersView(IConfiguration configuration) : base(configuration)
        {

        }
        
        public List<PartnersModel> List()
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                List<PartnersModel> models = uow.PartnersRepository.GetList();
                return models;
            }
        }

        public PartnersModel Info(int id)
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                PartnersModel model = uow.PartnersRepository.GetFirst("where id = @id", new { id });

                return model;
            }
        }
    }
}