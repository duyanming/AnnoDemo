using System;
using System.Collections.Generic;
using System.Text;
using Anno.EngineData;

namespace Anno.Plugs.TraceService
{
    public class TraceModule : BaseModule
    {
        private static readonly EngineData.SysInfo.UseSysInfoWatch Usi = new EngineData.SysInfo.UseSysInfoWatch();
        public TraceModule()
        {
           
        }
        /// <summary>
        /// 批量接收追踪信息
        /// </summary>
        /// <returns></returns>
        public ActionResult TraceBatch()
        {
            return new ActionResult(true, "TraceService");
        }
        /// <summary>
        /// 服务资源信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetServerStatus()
        {
            return new ActionResult(true, Usi.GetServerStatus());
        }
        #region  Module 初始化
        public override bool Init(Dictionary<string, string> input)
        {
            base.Init(input);
            return true;
        }
        #endregion
    }
}
