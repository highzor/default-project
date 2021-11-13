using AgrotechFillHingers.Backend.Interfaces;
using Dapper;

namespace AgrotechFillHingers.Backend.Models.Task_docks
{
    [Table("Task_docks")]
    public class Task_docks: IModel 
    {
        [Key]
        public int id {get;set;}
        public int task_id {get;set;}
        public string type {get;set;}
        public string create_date {get;set;}
    }
}