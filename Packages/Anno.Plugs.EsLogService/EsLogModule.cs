using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anno.EngineData;
using Anno.Es;
using Anno.Plugs.EsLogService.Model;
using Nest;

namespace Anno.Plugs.EsLogService
{
    public class EsLogModule : BaseModule
    {
        public ActionResult TraceBatch()
        {
            List<sys_trace> traces = Request<List<sys_trace>>("traces");
            traces.ForEach(t => { t.ID = IdWorker.NextId(); });
            var bulkRequest = new BulkRequest("traces") { Operations = new List<IBulkOperation>() };
            var idxops = traces.Select(o => new BulkIndexOperation<sys_trace>(o) { Id = o.ID }).Cast<IBulkOperation>().ToList();
            bulkRequest.Operations = idxops;
            var rlt = EsInstance.EsClient.BulkAsync(bulkRequest).Result;
            return new ActionResult(rlt.IsValid, null, null, null);
        }
    }
}
