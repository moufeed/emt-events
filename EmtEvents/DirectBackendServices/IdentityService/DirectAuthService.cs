using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.Identity.Auth.Models;
using TamTechBackendSDK.IdentityService.Services.UserAccountServices.ResetPasswordService;
using TamTechBackendSDK.IdentityService.Services.UserAccountServices.ResetPasswordService.Models;
using TamTechBackendSDK.IdentityService.Services;
using TamTechBackendSDK.IdentityService.Models.Users;

namespace EmtEvents.DirectBackendServices.IdentityService
{
    public class DirectAuthService : BaseDirectService, TamTechSDK.Common.Services.Identity.IAuthService
    {

        private IResetPasswordByEmailSendingService _resetService;
        private IUserAccountService _AccountService;

        public DirectAuthService(IResetPasswordByEmailSendingService resetService, IUserAccountService AccountService)
        {
            _resetService = resetService;
            _AccountService = AccountService;
        }

        public async Task<IRequestProviderResult<bool>> GenerateResetPasswordByEmailSendig(string email)
        {

            var result = await _resetService.GeneratePasswordResetTokenByEmailAsync(email);
            return ReturnResult(result.Data, result.Success);
        }

        public async Task<IRequestProviderResult<bool>> ResetPassword(ResetPassword password)
        {
            ResetPasswordByEmailModel data = new ResetPasswordByEmailModel
            {
                ConfirmPassword = password.ConfirmPassword,
                NewPassword = password.NewPassword,
                Token = password.Token,
                UserId = password.UserId
            };

            var result = await _resetService.ResetPassword(data);
            return ReturnResult(result.Data, result.Success);

        }

        public async Task<IRequestProviderResult<bool>> ChangePassword(ChangePassword model)
        {
            ChangePasswordModel data = new ChangePasswordModel()
            {
                CurrentPassword = model.CurrentPassword,
                NewPassword = model.NewPassword
            };
            var result = await _AccountService.ChangePassword(data);
            return ReturnResult(result.Data, result.Success);

        }


    }
}
