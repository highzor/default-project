using AgrotechFillHingers.Backend.Interfaces;
using Dapper;

namespace AgrotechFillHingers.Backend.Models.ScheduleStatus
{
    [Table("shedules_statuses")]
    public class ScheduleStatusModel : IModel
    {
        [Key]
        public int id { get; set; }
        public string color { get; set; }
        public string reason { get; set; }
    }

}
