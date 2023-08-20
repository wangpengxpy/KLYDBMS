using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLYDBMS.Application.Core.Data
{
    [Table("MRoles")]
    public class MRole
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int Id { get; set; }
        [Column("RoleName")]
        [StringLength(20)]
        [Required]
        public string RoleName { get; set; }
        [Column("RoleCode", TypeName = "varchar")]
        [StringLength(50)]
        public string RoleCode { get; set; }
        [Column("Remark")]
        public string Remark { get; set; }
        [Column("CreatedTime", TypeName = "datetime")]
        public DateTime CreatedTime { get; set; }
    }
}
