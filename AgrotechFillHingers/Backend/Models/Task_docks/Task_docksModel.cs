using System;
using AgrotechFillHingers.Backend.Helpers;
using AgrotechFillHingers.Backend.Interfaces;
using Dapper;

namespace AgrotechFillHingers.Backend.Models.Task_docks
{
    [Table("Task_docks")]
    public class Task_docksModel: IModel 
    {
        [Key]
        public int id {get;set;}
        public int task_id {get;set;}
        public string type {get;set;}
        [DbType(typeof(DateTime), "dd.MM.yyyy HH:mm:ss")]        		
        public string create_date {get;set;}
        public string file_root { get; set; }
    }
}