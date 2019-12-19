using Anno.EngineData;
using System;
using System.Linq;
using Anno.Model;
using SqlSugar;

namespace Anno.Plugs.TraceService
{
    using Anno.Log;
    using Anno.QueryServices.Platform;
    using Anno.Repository;
    using System.Collections.Generic;

    public class TraceModule : BaseModule
    {
        private static readonly EngineData.SysInfo.UseSysInfoWatch Usi = new EngineData.SysInfo.UseSysInfoWatch();
        private readonly SqlSugar.SqlSugarClient _db;
        public TraceModule()
        {
            _db = Resolve<IBaseQueryRepository>().Context;
        }
        /// <summary>
        /// 批量接收追踪信息
        /// </summary>
        /// <returns></returns>
        public ActionResult TraceBatch()
        {
            List<sys_trace> traces = Request<List<sys_trace>>("traces");
            traces.ForEach(t => { t.ID = IdWorker.NextId(); });
            _db.Insertable<sys_trace>(traces).With(SqlWith.NoLock).ExecuteCommandAsync();
            return new ActionResult(true, null, null, null);
        }
        /// <summary>
        /// 获取调用链列表信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTrace()
        {
            PageParameter pageParameter = new PageParameter
            {
                Page = RequestInt32("page") ?? 1,
                Pagesize = RequestInt32("pagesize") ?? 20,
                SortName = RequestString("sortname")?? "Timespan",
                SortOrder = RequestString("sortorder") ?? "desc",
                Where = Filter()
            };
            pageParameter.SortName?.Replace(Table, ".");
            pageParameter.SortOrder?.Replace(Table, ".");
            var totalNumber = 0;
            if (string.IsNullOrWhiteSpace(pageParameter.SortName))
            {
                pageParameter.SortName = "Timespan";
            }
            if (string.IsNullOrWhiteSpace(pageParameter.SortOrder))
            {
                pageParameter.SortOrder = "desc";
            }
            var dt = _db.Queryable<sys_trace>().Where(t=>t.PreTraceId==null||t.PreTraceId=="")
                .Where(pageParameter.Where)
                .OrderBy($"{pageParameter.SortName} {pageParameter.SortOrder}")
                .ToPageList(pageParameter.Page, pageParameter.Pagesize, ref totalNumber);
            var output = new Dictionary<string, object> { { "#Total", totalNumber }, { "#Rows", dt } };
            return new ActionResult(true, dt, output);
        }
        /// <summary>
        /// 根据GlobalTraceId 查看单个调用链明细
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTraceByGlobalTraceId()
        {
            string traceId = RequestString("GId");
            var ts = _db.Ado.SqlQuery<sys_trace>($"select * from sys_trace where GlobalTraceId='{traceId}';").ToList();
            //ts?.ForEach(t => { t.AppName = $"{t.AppName}({t.Ip})-{t.Askchannel}Service.{t.Askrouter}Module.{t.Askmethod}"; });
            var output = new Dictionary<string, object> { { "#Total", ts.Count }, { "#Rows", ts } };
            return new ActionResult(true, null, output);
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
