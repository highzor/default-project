using System;
using AgrotechFillHingers.Backend.Helpers;
using AgrotechFillHingers.Backend.Interfaces;
using Dapper;

namespace AgrotechFillHingers.Backend.Models.Acts
{
    [Table("Acts")]
    public class ActsModel: IModel 
    {
        [Key]
        public int id {get;set;}
        public int task_id {get;set;}
        [DbType(typeof(DateTime), "dd.MM.yyyy HH:mm:ss")]
        public string create_date {get;set;}
        public string product_name {get;set;}
        public int number {get;set;}
        public string count_type {get;set;}
        public double amount {get;set;}
        public string description { get; set; }
    }
}