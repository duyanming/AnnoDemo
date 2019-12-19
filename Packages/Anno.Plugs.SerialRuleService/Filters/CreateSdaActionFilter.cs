using System;
using System.Collections.Generic;
using System.Text;
using Anno.EngineData;
using Anno.EngineData.Filters;
using Anno.EngineData.Routing;

namespace Anno.Plugs.SerialRuleService.Filters
{
    #region Global 过滤器

    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(Exception ex, BaseModule context)
        {
            base.OnException(ex, context);
            Console.WriteLine("OnException GlobalExceptionFilter");
        }
    }
    public class GlobalActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(BaseModule context)
        {
            base.OnActionExecuted(context);
            Console.WriteLine("OnActionExecuted GlobalActionFilter");
        }
        public override void OnActionExecuting(BaseModule context)
        {
            base.OnActionExecuting(context);
            Console.WriteLine("OnActionExecuting GlobalActionFilter");
        }
    }
    public class Authorization : AuthorizationFilterAttribute
    {
        public string Msg { get; set; }
        public override void OnAuthorization(BaseModule context)
        {
            context.Authorized = true;
            base.OnAuthorization(context);
            Console.WriteLine($"OnAuthorization {Msg}");
        }
    }

    public class GlobalAuthorizationFilter : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(BaseModule context)
        {

            base.OnAuthorization(context);
        }
    }
    #endregion

    #region Module 过滤器

    public class ModuleExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(Exception ex, BaseModule context)
        {
            base.OnException(ex, context);
            Console.WriteLine("OnException ModuleExceptionFilter");
        }
    }
    public class ModuleActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(BaseModule context)
        {
            base.OnActionExecuted(context);
            Console.WriteLine("OnActionExecuted ModuleActionFilter");
        }
        public override void OnActionExecuting(BaseModule context)
        {
            base.OnActionExecuting(context);
            Console.WriteLine("OnActionExecuting ModuleActionFilter");
        }
    }
    #endregion
    #region Action 过滤器

    public class ActionExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(Exception ex, BaseModule context)
        {
            base.OnException(ex, context);
            Console.WriteLine("OnException ActionExceptionFilter");
        }
    }
    public class ActionActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(BaseModule context)
        {
            base.OnActionExecuted(context);
            Console.WriteLine("OnActionExecuted ActionActionFilter");
        }
        public override void OnActionExecuting(BaseModule context)
        {
            base.OnActionExecuting(context);
            Console.WriteLine("OnActionExecuting ActionActionFilter");
        }
    }
    #endregion
    #region CacheMiddleware
    public class AnnoCacheDefault : EngineData.Cache.CacheMiddlewareAttribute
    {

        System.Collections.Concurrent.ConcurrentDictionary<int, ActionResult> cache = new System.Collections.Concurrent.ConcurrentDictionary<int, ActionResult>();
        public override void RemoveCache(int key)
        {
            cache.TryRemove(key, out ActionResult actionResult);
        }

        public override void SetCache(int key, ActionResult actionResult)
        {
            cache[key] = actionResult;
        }

        public override bool TryGetCache(int key, out ActionResult actionResult)
        {
            return cache.TryGetValue(key, out actionResult);
        }
    }
    #endregion
}
