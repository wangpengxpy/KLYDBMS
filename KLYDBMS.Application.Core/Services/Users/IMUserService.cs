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
        OperateResult<int> Login(UserModel model);
    }
}
