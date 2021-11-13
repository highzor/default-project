using AgrotechFillHingers.Backend.Interfaces;
using Dapper;

namespace AgrotechFillHingers.Backend.Models.Tasks
{
    [Table("Tasks")]
    public class Tasks: IModel 
    {
        [Key]
        public int id {get;set;}
        public string name {get;set;}
        public int curator_id {get;set;}
        public string create_date {get;set;}
    }
}