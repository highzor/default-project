using System.Collections.Generic;
using AgrotechFillHingers.Backend.Helpers;
using AgrotechFillHingers.Backend.Models.Curators;
using Microsoft.Extensions.Configuration;

namespace AgrotechFillHingers.Backend.Views.Curators
{
    public class CuratorsView : ViewBase
    {
        public CuratorsView(IConfiguration configuration) : base(configuration)
        {

        }
        
        public List<CuratorsModel> List()
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                List<CuratorsModel> models = uow.CuratorsRepository.GetList();
                return models;
            }
        }

        public CuratorsModel Info(int id)
        {
            using (var uow = new UnitOfWork(GetConnectionString()))
            {
                CuratorsModel model = uow.CuratorsRepository.GetFirst("where id = @id", new { id });

                return model;
            }
        }
    }
}