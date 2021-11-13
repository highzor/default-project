using AgrotechFillHingers.Backend.Interfaces;
using Dapper;

namespace AgrotechFillHingers.Backend.Models.Curators
{
    [Table("Curators")]
    public class CuratorsModel: IModel 
    {
        [Key]
        public int id {get;set;}
        public int status_id {get;set;}
        public int user_id {get;set;}
    }
}