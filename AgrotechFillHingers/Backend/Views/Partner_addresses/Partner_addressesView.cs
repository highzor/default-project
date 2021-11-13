using System.Collections.Generic;
using AgrotechFillHingers.Backend.Helpers;
using AgrotechFillHingers.Backend.Models.Partners;
using AgrotechFillHingers.Backend.Models.Tasks;
using Microsoft.Extensions.Configuration;

namespace AgrotechFillHingers.Backend.Views.Partner_addresses
{
    public class Partner_addressesView : ViewBase
    {
        public Partner_addressesView(IConfiguration configuration) : base(configuration)
        {

        }
        
        public List<Partner_addressesModel> List()
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                List<Partner_addressesModel> models = uow.Partner_addressesRepository.GetList();
                return models;
            }
        }

        public Partner_addressesModel Info(int id)
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                Partner_addressesModel model = uow.Partner_addressesRepository.GetFirst("where id = @id", new { id });

                return model;
            }
        }
    }
}