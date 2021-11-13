using AgrotechFillHingers.Backend.Interfaces;
using Dapper;

namespace AgrotechFillHingers.Backend.Models.User
{
    [Table("Users")]
    public class Users : IModel 
    {
        [Key]
        public int id {get;set;}
        public string name {get;set;}
        public string surname {get;set;}
        public string second_name {get;set;}
        public int type_id {get;set;}
        public int status_id {get;set;}
        public string create_date {get;set;}
    }
}