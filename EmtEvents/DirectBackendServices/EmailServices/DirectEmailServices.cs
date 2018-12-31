using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTechBackendSDK.Common.Services.ServiceBus;
using TamTechBackendSDK.Common.Services.ServiceBus.Models;

using TamTechSDK.Common.Services.Email.Models;
using TamTechSDK.Web.Services.Configurations.AppSetting;

namespace EmtEvents.DirectBackendServices.EmailServices
{
    public class DirectEmailServices : TamTechSDK.Common.Services.Email.IEmailSenderService
    {
        private readonly TamTechBackendSDK.EmailService.Services.IEmailSender _emailSender;

        private readonly IWebApplicationSettingsService _appSettingsService;

        public DirectEmailServices(
            TamTechBackendSDK.EmailService.Services.IEmailSender emailSender,
            IWebApplicationSettingsService appSettingsService
            )
        {
            _appSettingsService = appSettingsService;
            _emailSender = emailSender;
        }


        public async Task<bool> SendAsync(EmailModel model,
                                    string userId = "",
                                    string clientId = "",
                                    List<string> userRoles = null)
        {


            var email = new TamTechBackendSDK.EmailService.Models.EmailModel
            {
                ClientId = clientId,
                UserId = userId,
                UserRoles = userRoles,
                From = _appSettingsService.GetEmailSettings().From,
                Html = model.HtmlMessage,
                ReasonOfSend = model.ReasonOfSend,
                Subject = model.Subject,
                Text = model.Message,
                Recipients = new List<string> { model.Email }
            };

            return await _emailSender.SendEmail(email); ;
        }
    }
}
