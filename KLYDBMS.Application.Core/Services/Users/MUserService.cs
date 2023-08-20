using KLYDBMS.Application.Core.Data;
using KLYDBMS.Models;
using KLYDBMS.Utilities;
using Microsoft.EntityFrameworkCore;

namespace KLYDBMS.Application.Core
{
    public class MUserService : IMUserService
    {
        private readonly StoreDbContext _context;
        public MUserService(StoreDbContext context)
        {
            _context = context;
        }
        public OperateResult<int> Login(UserModel model)
        {
            var user = _context.MUsers.AsNoTracking()
                 .FirstOrDefault(d => d.UserName == model.UserName);

            if (user == null)
            {
                return OperateResult.Failed<int>("账号或密码不正确");
            }

            var passwordText = KLYAlgorithm.AESEncrypt(model.Password, user.Salt);

            var encryptPassword = KLYAlgorithm.SHA512Encrypt(passwordText);

            if (user.Password != encryptPassword)
            {
                return OperateResult.Failed<int>("账号或密码不正确");
            }

            return OperateResult.Successed(user.Id);
        }
    }
}
