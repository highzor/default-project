using AgrotechFillHingers.Backend.Helpers;
using System;
using AgrotechFillHingers.Backend.Interfaces;
using Dapper;
using System;

namespace AgrotechFillHingers.Backend.Models.Tasks
{
    [Table("partner_addresses")]
    public class Partner_addressesModel: IModel 
    {
        [Key]
        public int id { get; set; }
        public int partner_id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string contact { get; set; }
        public string phone { get; set; }
        public string description { get; set; }
    }
}