using System;
using System.Collections.Generic;
using System.Text;
using Anno.EngineData;

namespace Anno.Plugs.SerialRuleService
{
    public class SeriaRuleBootstrap : IPlugsConfigurationBootstrap
    {
        public void ConfigurationBootstrap()
        {
            #region 增加全局过滤器
            //EngineData.Routing.Routing.AddFilter(new Filters.GlobalActionFilter());
            //EngineData.Routing.Routing.AddFilter(new Filters.GlobalExceptionFilter());
            //EngineData.Routing.Routing.AddFilter(new Filters.Authorization(){Msg = "Global"});
            #endregion
            //序列号生成配置
        }

        public void PreConfigurationBootstrap()
        {
            //throw new NotImplementedException();
        }
    }
}
