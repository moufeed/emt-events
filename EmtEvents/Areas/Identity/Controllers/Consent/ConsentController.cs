using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace TamTech.IdentityServer
{

    /*
     * This controller is not needed in simple one server login. 
     * However, we will keep it as part of the template in case we needed it
     * and just to maintain more generic EmtEvents Template
     */


    /*[Authorize]
    public class ConsentController : IdentityServer4.Quickstart.UI.ConsentController
    {
        
        public ConsentController(
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IResourceStore resourceStore,
            ILogger<ConsentController> logger)
            :base(interaction,clientStore,resourceStore,logger)
        {
        }

        
    }*/
}