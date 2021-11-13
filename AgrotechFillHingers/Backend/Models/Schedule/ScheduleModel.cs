using AgrotechFillHingers.Backend.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrotechFillHingers.Backend.Models.Schedule
{
    [Table("shedules")]
    public class ScheduleModel : IModel
    {
        [Key]
        public int id { get; set; }
        public int user_id { get; set; }
        public string task_datetime { get; set; }
        public int task_id { get; set; }
        public string description { get; set; }
    }
}
