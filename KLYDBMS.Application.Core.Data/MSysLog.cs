using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLYDBMS.Application.Core.Data
{
    [Table("MSysLogs")]
    public class MSysLog
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column("UserName", TypeName = "varchar")]
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        /// <summary>
        /// 事件类型
        /// </summary>
        [Column("EventType")]
        [Required]
        public string EventType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column("Source")]
        public string Source { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column("Target")]
        public string Target { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("CreatedTime", TypeName = "datetime")]
        public DateTime CreatedTime { get; set; }
    }
}
