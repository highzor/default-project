using System;
using AgrotechFillHingers.Backend.Interfaces;
using Dapper;

namespace AgrotechFillHingers.Backend.Models.Users
{
    [Table("Users")]
    public class UsersModel : IModel 
    {
        [Key]
        public int id {get;set;}
        public string name {get;set;}
        public string surname {get;set;}
        public string second_name {get;set;}
        public int type_id {get;set;}
        public int status_id {get;set;}
        public DateTime create_date {get;set;}
        public string phone { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public DateTime birthday_date { get; set; }
        public string description { get; set; }
        public string email { get; set; }
    }
}