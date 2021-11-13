using AgrotechFillHingers.Backend.Interfaces;
using Dapper;

namespace AgrotechFillHingers.Backend.Models.Curators
{
    [Table("Curators")]
    public class Curators: IModel 
    {
        [Key]
        public int id {get;set;}
        public int status_id {get;set;}
    }
}