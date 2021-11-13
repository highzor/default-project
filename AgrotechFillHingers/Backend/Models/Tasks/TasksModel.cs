using AgrotechFillHingers.Backend.Helpers;
using System;
using AgrotechFillHingers.Backend.Interfaces;
using Dapper;
using System;

namespace AgrotechFillHingers.Backend.Models.Tasks
{
    [Table("tasks")]
    public class TasksModel: IModel 
    {
        [Key]
		public int id { get; set; }
		public string name { get; set; }
		public int curator_id { get; set; }
		public string create_date { get; set; }
		public int status_id { get; set; }
		public int partner_id { get; set; }
		public int type_id { get; set; }
		public int address_id { get; set; }
		[DbType(typeof(DateTime), "dd.MM.yyyy HH:mm:ss")]
		public string delivery_time { get; set; }
		public int task_group_id { get; set; }
		public string description { get; set; }

	}
}