using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLYDBMS.Application.Core.Data
{
    [Table("MUserRoles")]
    public class MUserRole
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int Id { get; set; }
        [Column("UserId")]
        public int UserId { get; set; }
        [Column("RoleId")]
        public int RoleId { get; set; }
    }
}
