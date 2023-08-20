using Microsoft.EntityFrameworkCore;

namespace KLYDBMS.Application.Core.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// 部门模型
        /// </summary>
        public DbSet<MDepartment> MDepartments { get; set; }
        /// <summary>
        /// 用户模型
        /// </summary>
        public DbSet<MUser> MUsers { get; set; }
        /// <summary>
        /// 角色模型
        /// </summary>
        public DbSet<MRole> MRoles { get; set; }
        /// <summary>
        /// 用户角色模型
        /// </summary>
        public DbSet<MUserRole> MUserRoles { get; set; }
        /// <summary>
        /// 菜单模型
        /// </summary>
        public DbSet<MMenu> MMenus { get; set; }
        /// <summary>
        /// 角色菜单模型
        /// </summary>
        public DbSet<MRoleMenu> MRoleMenus { get; set; }
        /// <summary>
        /// 系统操作日志
        /// </summary>
        public DbSet<MSysLog> MSysLogs { get; set; }

        /// <summary>
        /// 资料模型
        /// </summary>
        public DbSet<Material> Materials { get; set; }
        /// <summary>
        /// 资料附件模型
        /// </summary>
        public DbSet<MaterialAttachment> MaterialAttachments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
