using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApiKalum.Utilities
{
    public class ActionFilter : IActionFilter
    {
        private readonly ILogger<ActionFilter> Logger;
        public ActionFilter(ILogger<ActionFilter> _Logger)
        {
            this.Logger = _Logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Logger.LogInformation("Este se ejecuta antes de la accion a realizar");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Logger.LogInformation("Esto se ejecuta despues de la acion realizada");
        }
    }
}