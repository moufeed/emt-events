using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmtEvents.DirectBackendServices.IdentityService.RolesService.Mapper;
using TamTechSDK.Common.Services.Identity;
using TamTechSDK.Common.Services.Identity.Models;

namespace EmtEvents.DirectBackendServices.IdentityService.RolesService
{
    public class DirectRolesService : BaseDirectService, IRolesService
    {
        #region Props   
        private readonly TamTechBackendSDK.IdentityService.Services.IRoleService _roleService;
        #endregion


        #region Ctors
        public DirectRolesService(
            TamTechBackendSDK.IdentityService.Services.IRoleService roleService
            )
        {
            _roleService = roleService;

        }
        #endregion
        public Task<IEnumerable<RoleModel>> GetAllAsync()
        {
            var result = _roleService.Get();
            var roles = result != null ? result.Select(m => m.MapToFrontendModel()) : new List<RoleModel>();
            return Task.FromResult(roles);
        }

    }
}
