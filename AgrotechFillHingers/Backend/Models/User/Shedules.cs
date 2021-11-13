using AgrotechFillHingers.Backend.Interfaces;
using Dapper;

namespace AgrotechFillHingers.Backend.Models.User
{
    [Table("Shedules")]
    public class Shedules: IModel 
    {
        [Key]
        public int id {get;set;}
        public int user_id {get;set;}
        public string task_datetime {get;set;}
        public int task_id {get;set;}
    }
}