using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLYDBMS.Application.Core.Data
{
    [Table("MUsers")]
    public class MUser
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int Id { get; set; }
        [Column("UserName", TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string UserName { get; set; }
        [Column("Password")]
        [Required]
        public string Password { get; set; }
        [Column("Salt", TypeName = "varchar")]
        [StringLength(32)]
        [Required]
        public string Salt { get; set; } = Guid.NewGuid().ToString("N");
        [Column("LockEnabled")]
        [Required]
        public bool LockEnabled { get; set; }
        [Column("Remark")]
        public string Remark { get; set; }
        [Column("CreatedTime", TypeName = "datetime")]
        [Required]
        public DateTime CreatedTime { get; set; }
        [Column("DeletedTime", TypeName = "datetime")]
        [Required]
        public DateTime DeletedTime { get; set; }
    }
}
