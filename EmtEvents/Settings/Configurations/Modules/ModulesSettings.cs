using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTechSDK.Web.Enums;

namespace EmtEvents.Settings.Configurations.Modules
{
    public class ModulesSettings
    {
        public ICollection<ModulesTypesEnum> GetAvailableModules()
        {
            return new List<ModulesTypesEnum>
            {
                ModulesTypesEnum.Gallery,
                ModulesTypesEnum.Menu,
                ModulesTypesEnum.Page,
                ModulesTypesEnum.Post,
                ModulesTypesEnum.Product,
                ModulesTypesEnum.Section,
                ModulesTypesEnum.Service,
                ModulesTypesEnum.Slider,
               // ModulesTypesEnum.testimonials,
            };
        }


    }
}
