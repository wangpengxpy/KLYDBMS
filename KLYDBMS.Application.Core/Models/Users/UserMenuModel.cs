namespace KLYDBMS.Models
{
    public class UserMenuModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 菜单编码
        public string Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<UserMenuModel> Children { get; set; } = new List<UserMenuModel>();
    }
}
