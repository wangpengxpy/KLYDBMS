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

        public async Task<OperateResult<List<UserMenuModel>>> GetUserMenus(int id)
        {
            var userRole = await _context.MUserRoles.AsNoTracking()
                .FirstOrDefaultAsync(d => d.UserId == id);

            if (userRole == null)
            {
                return OperateResult.Successed(default(List<UserMenuModel>));
            }

            var menuIds = await _context.MRoleMenus.AsNoTracking()
                .Where(d => d.RoleId == userRole.RoleId)
                .Select(d => d.MenuId).ToListAsync();

            if (!menuIds.Any())
            {
                return OperateResult.Successed(default(List<UserMenuModel>));
            }

            var roleMenus = await _context.MMenus.AsNoTracking()
                .Where(d => menuIds.Any(m => m == d.Id)).ToListAsync();

            if (!roleMenus.Any())
            {
                return OperateResult.Successed(default(List<UserMenuModel>));
            }

            var menus = await _context.MMenus.AsNoTracking().ToListAsync();

            var parentMenus = roleMenus.Where(d => !d.ParentId.HasValue).ToList();

            var models = new List<UserMenuModel>();

            foreach (var menu in parentMenus)
            {
                var model = new UserMenuModel()
                {
                    Id = menu.Id,
                    Code = menu.MenuCode,
                    Name = menu.MenuName
                };

                var entities = menus.Where(d => d.ParentId.HasValue && d.ParentId.Value == menu.Id).ToList();

                model.Children = entities.Select(d => new UserMenuModel()
                {
                    Id = d.Id,
                    Code = d.MenuCode,
                    Name = d.MenuName
                }).ToList();

                models.Add(model);
            }

            return OperateResult.Successed(models);
        }

        public async Task<OperateResult<int>> Login(UserModel model)
        {
            var user = await _context.MUsers.AsNoTracking()
                 .FirstOrDefaultAsync(d => d.UserName == model.UserName);

            if (user == null)
            {
                return OperateResult.Failed<int>("账号或密码不正确");
            }

            if (user.LockEnabled)
            {
                return OperateResult.Failed<int>("账号已被锁定，无法登录");
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
