using AgrotechFillHingers.Backend.Interfaces;
using Dapper;

namespace AgrotechFillHingers.Backend.Models.Volunteers
{
    [Table("VolunteersModel")]
    public class VolunteersModel: IModel 
    {
        [Key]
        public int id {get;set;}
        public int user_id {get;set;}
        public int groupId { get; set; }
        public int available_metro { get; set; }
        public int available_days { get; set; }
    }
}