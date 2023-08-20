using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLYDBMS.Application.Core.Data
{
    [Table("MaterialAttachments")]
    public class MaterialAttachment
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public long Id { get; set; }
        /// <summary>
        /// 材料id
        /// </summary>
        [Column("MaterialId")]
        public long MaterialId { get; set; }
        /// <summary>
        /// 附件id
        /// </summary>
        [Column("AttachmentId")]
        [Required]
        public string AttachmentId { get; set; }

        public Material Material { get; set; }
    }
}
