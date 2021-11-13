using AgrotechFillHingers.Backend.Interfaces;
using Dapper;

namespace AgrotechFillHingers.Backend.Models.Group_addresses
{
    [Table("Group_addresses")]
    public class Group_addresses: IModel 
    {
        [Key]
        public int id {get;set;}
        public int group_id {get;set;}
        public int type_id {get;set;}
        public string address {get;set;}
    }
}