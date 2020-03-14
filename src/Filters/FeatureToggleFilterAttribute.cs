
using ConfigCat.Client;
using FeatureToggle.Toggles.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FeatureToggle.Filters
{
    public class FeatureToggleFilterAttribute : ActionFilterAttribute
    {
         protected readonly string _toggle;

        public FeatureToggleFilterAttribute(string toggle)
        {
            _toggle = toggle;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            IFeatureToggleClient _featureToggleClient = context.HttpContext.RequestServices.GetService(typeof(IFeatureToggleClient)) as IFeatureToggleClient;

            if (_featureToggleClient != null) 
            {
                if (!_featureToggleClient.IsValid(_toggle))
                    context.Result = new NotFoundResult();
            }
        }
    }
}