using System.Collections.Generic;
using AgrotechFillHingers.Backend.Helpers;
using AgrotechFillHingers.Backend.Models.Groups;
using Microsoft.Extensions.Configuration;

namespace AgrotechFillHingers.Backend.Views.Groups
{
    public class GroupsView : ViewBase
    {
        public GroupsView(IConfiguration configuration) : base(configuration)
        {

        }
        
        public List<GroupsModel> List()
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                List<GroupsModel> models = uow.GroupsRepository.GetList();
                return models;
            }
        }

        public GroupsModel Info(int id)
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                GroupsModel model = uow.GroupsRepository.GetFirst("where id = @id", new { id });

                return model;
            }
        }
    }
}