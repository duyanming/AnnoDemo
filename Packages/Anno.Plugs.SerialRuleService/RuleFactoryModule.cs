using Anno.EngineData;
using Anno.SerialRule;
using System;
using Anno.Plugs.SerialRuleService.Filters;

namespace Anno.Plugs.SerialRuleService
{
    //[ModuleActionFilter]
    //[ModuleExceptionFilter]
    //[Authorization(Msg = "Module")]
    public class RuleFactoryModule : BaseModule
    {
        public RuleFactoryModule()
        {

        }
        /// <summary>
        /// 创建SDA单号码 S:SDA-}{D:yyyyMMdd}{S:-}{N:{S:SDA-}{D:yyyyMMdd}{S:-}/0000000}
        /// </summary>
        /// <returns></returns>
        //[ActionActionFilter]
        //[ActionExceptionFilter]
        //[Authorization(Msg = "Action")]
        //[AnnoCacheDefault]
        public ActionResult CreateSdaNum()
        {
            string rule = "{S:SDA-}{D:yyyyMMdd}{S:-}{N:{S:SDA-}{D:yyyyMMdd}{S:-}/0000000}";
            var sDaNum = SRFactory.Default.Create(rule);
            return new ActionResult(true, sDaNum);
        }
        //[AnnoCacheDefault]
        public ActionResult CreateSdaNum1()
        {
            string rule = "{S:SDA-}{D:yyyyMMdd}{S:-}{N:{S:SDA-}{D:yyyyMMdd}{S:-}/0000000}";
            var sDaNum = SRFactory.Default.Create(rule);
            return new ActionResult(true, sDaNum);
        }
    }
}
