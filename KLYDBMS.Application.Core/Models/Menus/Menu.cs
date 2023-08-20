namespace KLYDBMS.Models
{
    public class Menu
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// public
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// public
        /// </summary>
        public List<Menu> Children { get; set; }
    }
}
