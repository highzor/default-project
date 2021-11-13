﻿using AgrotechFillHingers.Backend.Interfaces;
using Dapper;

namespace AgrotechFillHingers.Backend.Models.Task_status_history
{
    [Table("Task_status_history")]
    public class Task_status_historyModel: IModel 
    {
        [Key]
        public int id {get;set;}
        public int task_id {get;set;}
        public int new_status_id {get;set;}
        public string change_datetime {get;set;}
    }
}