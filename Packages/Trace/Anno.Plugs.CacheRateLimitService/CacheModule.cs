using System;
using System.Collections.Generic;
using System.Text;
using Anno.EngineData;
using Anno.EngineData.Cache;


namespace Anno.Plugs.CacheRateLimitService
{
    public class CacheModule : BaseModule
    {
        [CacheLRU(5,6,true)]
        public ActionResult Cache(string msg)
        {
            Console.WriteLine(msg);
            return new ActionResult(true, null,null,msg);
        }
    }
}
