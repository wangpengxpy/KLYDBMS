using KLYDBMS.Models;
using KLYDBMS.Utilities;

namespace KLYDBMS.Application.Core
{
    public interface IMUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<OperateResult<int>> Login(UserModel model);
        /// <summary>
        /// 获取用户可操作菜单列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperateResult<List<UserMenuModel>>> GetUserMenus(int id);
    }
}
