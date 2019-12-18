using System;
using System.Collections.Generic;
using System.Text;
using Anno.EngineData;
using Anno.RateLimit;

namespace Anno.Plugs.CacheRateLimitService
{
    public class LimitModule : BaseModule
    {
        [EngineData.Limit.RateLimit(LimitingType.TokenBucket,1,5,5)]
        public ActionResult Limit(string msg)
        {
            Console.WriteLine(msg);
            return new ActionResult(true, null, null, msg);
        }
    }
}
