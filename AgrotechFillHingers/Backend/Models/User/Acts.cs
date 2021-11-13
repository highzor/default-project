using AgrotechFillHingers.Backend.Interfaces;
using Dapper;

namespace AgrotechFillHingers.Backend.Models.User
{
    [Table("Acts")]
    public class Acts: IModel 
    {
        [Key]
        public int id {get;set;}
        public int task_id {get;set;}
        public string create_date {get;set;}
        public string product_name {get;set;}
        public int number {get;set;}
        public string count_type {get;set;}
        public double amount {get;set;}
    }
}