using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLYDBMS.Application.Core.Data
{
    [Table("Materials")]
    public class Material
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public long Id { get; set; }
        /// <summary>
        /// 材料日期
        /// </summary>
        [Description("材料日期")]
        [Column("MaterialDate")]
        [Required]
        public DateTime MaterialDate { get; set; }
        /// <summary>
        /// 所属品牌
        /// </summary>
        [Description("所属品牌")]
        [Column("Brand")]
        [Required]
        public string Brand { get; set; }
        /// <summary>
        /// 阶段
        /// </summary>
        [Column("Stage")]
        [Description("阶段")]
        [Required]
        public string Stage { get; set; }
        /// <summary>
        /// 型体号
        /// </summary>
        [Description("型体号")]
        [Column("TypeNumber")]
        [Required]
        public string TypeNumber { get; set; }
        /// <summary>
        /// 鞋厂
        /// </summary>
        [Column("ShoeFactory")]
        [Required]
        [Description("鞋厂")]
        public string ShoeFactory { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        [Description("部门")]
        [Column("MDepartmentId")]
        [Required]
        public int MDepartmentId { get; set; }
        /// 开发人
        /// </summary>
        [Description("开发人")]
        [Column("Developer")]
        [Required]
        public string Developer { get; set; }
        /// 材料编号
        /// </summary>
        [Description("材料编号")]
        [Column("MaterialNumber")]
        [Required]
        public string MaterialNumber { get; set; }
        /// 材料类型
        /// </summary>
        [Description("材料类型")]
        [Column("MaterialType")]
        [Required]
        public string MaterialType { get; set; }
        /// 彩图
        /// </summary>
        [Description("彩图")]
        [Column("ColorChart")]
        [Required]
        public string ColorChart { get; set; }
        /// 码段
        /// </summary>
        [Description("码段")]
        [Column("CodeSegment")]
        [Required]
        public string CodeSegment { get; set; }
        /// 对外编号
        /// </summary>
        [Description("对外编号")]
        [Column("ExternalNumber")]
        [Required]
        public string ExternalNumber { get; set; }
        /// 车间代号
        /// </summary>
        [Description("车间代号")]
        [Column("WorkshopCode")]
        [Required]
        public string WorkshopCode { get; set; }
        /// 成分
        /// </summary>
        [Description("成分")]
        [Column("Component")]
        [Required]
        public string Component { get; set; }
        /// 规格
        /// </summary>
        [Description("规格")]
        [Column("Specifications")]
        [Required]
        public string Specifications { get; set; }
        /// 定型参数
        /// </summary>
        [Description("定型参数")]
        [Column("SizingParameters")]
        [Required]
        public string SizingParameters { get; set; }
        /// 成品图片
        /// </summary>
        [Description("成品图片")]
        [Column("FinishedProductImg")]
        [Required]
        public string FinishedProductImg { get; set; }
        /// 材料说明
        /// </summary>
        [Description("材料说明")]
        [Column("MaterialDesc")]
        public string MaterialDesc { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("CreatedTime", TypeName = "datetime")]
        [Required]
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [Column("UpdatedTime", TypeName = "datetime")]
        [Required]
        public DateTime UpdatedTime { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [Column("IsDeleted")]
        [Required]
        public bool IsDeleted { get; set; } = false;
        /// <summary>
        /// 备注
        /// </summary>
        [Column("Remark")]
        [Description("备注")]
        public string Remark { get; set; }

        public List<MaterialAttachment> Attachments { get; set; }
    }
}
