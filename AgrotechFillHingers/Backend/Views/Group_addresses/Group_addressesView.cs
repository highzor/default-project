using System.Collections.Generic;
using AgrotechFillHingers.Backend.Helpers;
using AgrotechFillHingers.Backend.Models.Group_addresses;
using Microsoft.Extensions.Configuration;

namespace AgrotechFillHingers.Backend.Views.Group_addresses
{
    public class Group_addressesView : ViewBase
    {
        public Group_addressesView(IConfiguration configuration) : base(configuration)
        {

        }
        
        public List<Group_addressesModel> List()
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                List<Group_addressesModel> models = uow.GroupAddressesRepository.GetList();
                return models;
            }
        }

        public Group_addressesModel Info(int id)
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                Group_addressesModel model = uow.GroupAddressesRepository.GetFirst("where id = @id", new { id });

                return model;
            }
        }
    }
}