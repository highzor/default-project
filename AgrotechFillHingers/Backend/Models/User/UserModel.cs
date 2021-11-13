using AgrotechFillHingers.Backend.Interfaces;
using Dapper;

namespace AgrotechFillHingers.Backend.Models.User
{
    [Table("users")]
    public class UserModel : IModel
    {
        [Key]
        public int? ID { get; set; }
    }
}
