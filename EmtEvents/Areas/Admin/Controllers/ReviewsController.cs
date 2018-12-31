using TamTechSDK.Common.Services.ContentService;
using TamTechSDK.Common.Services.ContentService.Reviews;
using TamTechSDK.Web.Controllers.Admin;

namespace EmtEvents.Areas.Admin.Controllers
{
    public class ReviewsController : ReviewsBaseController
    {
        public ReviewsController(IContentServices contentServices, IReviewsServices reviewsServices)
            : base(contentServices, reviewsServices)
        {
        }
    }
}