using AgrotechFillHingers.Backend.Interfaces;
using Dapper;

namespace AgrotechFillHingers.Backend.Models.Groups
{
    [Table("Groups")]
    public class GroupsModel: IModel 
    {
        [Key]
        public int id {get;set;}
        public string name {get;set;}
        public string description {get;set;}
    }
}