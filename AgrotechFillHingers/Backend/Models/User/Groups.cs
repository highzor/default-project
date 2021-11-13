using AgrotechFillHingers.Backend.Interfaces;
using Dapper;

namespace AgrotechFillHingers.Backend.Models.User
{
    [Table("Groups")]
    public class Groups: IModel 
    {
        [Key]
        public int id {get;set;}
        public string name {get;set;}
    }
}