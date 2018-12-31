using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace TamTech.IdentityServer
{
    /*
     * This controller is not needed in simple one server login. 
     * However, we will keep it as part of the template in case we needed it
     * and just to maintain more generic EmtEvents Template
     */
    /*[Authorize]
    public class GrantsController : IdentityServer4.Quickstart.UI.GrantsController
    {
        public GrantsController(IIdentityServerInteractionService interaction,
            IClientStore clients,
            IResourceStore resources)
            : base(interaction, clients, resources)
        {
        }


    }*/
}