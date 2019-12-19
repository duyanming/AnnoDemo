using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anno.EngineData;
using Anno.Plugs.ReportService.Dto;

namespace Anno.Plugs.ReportService
{
    using Infrastructure;
    public class ReportModule: BaseModule
    {
        public ReportModule()
        {
        }

        public ActionResult GetServiceReport()
        {
            StringBuilder queryStr=new StringBuilder();
            DateTime startDate = (RequestDateTime("startDate")??DateTime.Today.AddDays(-6)).Date;
            DateTime endDate = (RequestDateTime("endDate") ?? DateTime.Now.AddDays(1));
            if (startDate > endDate)
            {
                return new ActionResult(false,null,null, "统计开始日期不能小于结束日期");
            }
            queryStr.AppendFormat(@"SELECT AppName ,count(1) as Count FROM(
                select AppName ,id FROM sys_trace WHERE Timespan>=@startDate and Timespan<=@endDate
                UNION ALL
                select AppNameTarget as AppName,id FROM sys_trace  WHERE Timespan>=@startDate and Timespan<=@endDate
                ) a GROUP BY AppName;");
            var reportData = DbInstance.Db.Ado.SqlQuery<TraceDto>(queryStr.ToString(), new { startDate, endDate }).ToList();   
            return new ActionResult(true,new { xAxis = reportData.Select(t=>t.AppName).ToList(),values=reportData.Select(t=>t.count).ToList()});
        }
    }
}
