namespace KLYDBMS.Models
{
    public class UserListModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        public string UserName { get; set; }
        public bool LockEnabled { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
