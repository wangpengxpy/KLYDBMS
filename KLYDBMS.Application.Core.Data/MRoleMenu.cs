using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLYDBMS.Application.Core.Data
{
    [Table("MRoleMenus")]
    public class MRoleMenu
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int Id { get; set; }
        [Column("RoleId")]
        public int RoleId { get; set; }
        [Column("MenuId")]
        public int MenuId { get; set; }
        [Column("Operate")]
        public Operate Operate { get; set; }
        [Column("ViewColumns", TypeName = "varchar")]
        public string ViewColumns { get; set; }
    }

    public enum Operate : byte
    {
        /// <summary>
        /// 所有
        /// </summary>
        [Description("所有")]
        All = 0,
        /// <summary>
        /// 添加
        /// </summary>
        [Description("添加")]
        Add = 1,
        /// <summary>
        /// 更新
        /// </summary>
        [Description("更新")]
        Update = 2,
        /// <summary>
        /// 删除
        /// </summary>
        [Description("删除")]
        Delete = 3,
        /// <summary>
        /// 查看
        /// </summary>
        [Description("查看")]
        View = 4
    }
}
