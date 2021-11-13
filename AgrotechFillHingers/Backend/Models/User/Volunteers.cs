using AgrotechFillHingers.Backend.Interfaces;
using Dapper;

namespace AgrotechFillHingers.Backend.Models.User
{
    [Table("Volunteers")]
    public class Volunteers: IModel 
    {
        [Key]
        public int id {get;set;}
        public int user_id {get;set;}
    }
}