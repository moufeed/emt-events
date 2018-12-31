using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmtEvents.DirectBackendServices.IdentityService.UsersMenager.Mapper
{
    public static class UsersManagerMapper
    {
        public static TamTechBackendSDK.IdentityService.Models.UserManager.RegisterUserModel MapToBackendModel(this TamTechSDK.Common.Services.Identity.Models.Params.RegisterUserModel frontend)
        {
            return new TamTechBackendSDK.IdentityService.Models.UserManager.RegisterUserModel
            {

                Email = frontend.Email,
                MobileNumber = frontend.PhoneNumber,
                Password = frontend.Password,
                RolesNames = frontend.RolesNames.ToList(),
                UserName = frontend.UserName,

            };
        }
        public static TamTechBackendSDK.IdentityService.Models.UserManager.GetUsersModel MapToBackendModel(this TamTechSDK.Common.Services.Identity.Models.Params.GetUsersModel frontend)
        {
            return new TamTechBackendSDK.IdentityService.Models.UserManager.GetUsersModel
            {
                PageNumber = frontend.PageNumber,
                PageSize = frontend.PageSize,
                RoleId = frontend.RoleId,
                UserName = frontend.UserName,

            };
        }

        public static TamTechSDK.Common.Models.Pagination.PaginationMetadataModel MapToFrontendModel(this TamTechBackendSDK.IdentityService.Models.PaginationMetadataModel backend)
        {

            return new TamTechSDK.Common.Models.Pagination.PaginationMetadataModel
            {
                NextPage = backend.NextPage,
                PageNumber = backend.PageNumber.ToString(),
                PageSize = backend.PageSize,
                PreviousPage = backend.PreviousPage,
                TotalCount = backend.TotalCount,
                TotalPages = backend.TotalPages

            };
        }


        public static TamTechSDK.Common.Services.Identity.Models.UserModel MapToFrontendModel(this TamTechBackendSDK.IdentityService.Models.Users.UserModel backend)
        {
            return new TamTechSDK.Common.Services.Identity.Models.UserModel
            {
                AccessFailedCount = backend.AccessFailedCount,
                Email = backend.Email,
                EmailConfirmed = backend.EmailConfirmed,
                Gender = backend.Gender,
                Id = backend.Id,
                IsBlocked = backend.IsBlocked,
                IsLockout = backend.IsLockout,
                LockoutEnabled = backend.LockoutEnabled,
                LockoutEnd = backend.LockoutEnd,
                MobileNumber = backend.MobileNumber,
                MobileNumberConfirmed = backend.MobileNumberConfirmed,
                Name = backend.Name,
                NormalizedEmail = backend.NormalizedEmail,
                NormalizedUserName = backend.NormalizedUserName,
                UserName = backend.UserName,
                ImageUrl = backend.ImageUrl,
            };
        }



    }
}
