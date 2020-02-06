
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
            IConfigCatClient _configCatClient = context.HttpContext.RequestServices.GetService(typeof(IConfigCatClient)) as IConfigCatClient;

            if (_configCatClient != null) 
            {
                _configCatClient.ForceRefresh();

                if (!_configCatClient.GetValue(_toggle, false))
                    context.Result = new NotFoundResult();
            }
        }
    }
}