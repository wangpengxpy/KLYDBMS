using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLYDBMS.Application.Core.Data
{
    [Table("MMenu")]
    public class MMenu
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int Id { get; set; }
        public int? ParentId { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Column("MenuName")]
        [Required]
        [StringLength(20)]
        public string MenuName { get; set; }
        /// <summary>
        /// 菜单编码
        /// </summary>
        [Column("MenuCode", TypeName = "varchar")]
        [StringLength(50)]
        public string MenuCode { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("Remark")]
        public string Remark { get; set; }
        [Column("CreatedTime", TypeName = "datetime")]
        public DateTime CreatedTime { get; set; }
    }
}
