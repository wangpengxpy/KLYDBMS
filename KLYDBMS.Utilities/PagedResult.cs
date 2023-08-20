using System.Collections.Generic;

namespace KLYDBMS.Utilities
{
    public class PagedResult<T> where T : class
    {
        public int Total { get; private set; }
        public IEnumerable<T> Rows { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="total"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public static PagedResult<T> Create(int total, IEnumerable<T> rows)
        {
            return new PagedResult<T>()
            {
                Total = total,
                Rows = rows
            };
        }
    }
}
