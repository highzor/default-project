using AgrotechFillHingers.Backend.Interfaces;
using Dapper;

namespace AgrotechFillHingers.Backend.Models.Partners
{
    [Table("Partners")]
    public class Partners: IModel 
    {
        [Key]
        public int id {get;set;}
        public string name {get;set;}
        public string law_name {get;set;}
        public string address {get;set;}
        public string phone {get;set;}
    }
}