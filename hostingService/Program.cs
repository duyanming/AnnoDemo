using System;

namespace hostingService
{
    using Anno.Rpc.Server;
    using Anno.Loader;
    using Autofac;
    using Anno.EngineData;
    using System.Collections.Generic;
    using Anno.Rpc.Storage;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "AnnoTraceContainer";
            Bootstrap.StartUp(args, () =>
            {
                Anno.Const.SettingService.TraceOnOff = false;
                var cb = IocLoader.GetAutoFacContainerBuilder();
                cb.RegisterType(typeof(RpcConnectorImpl)).As(typeof(IRpcConnector)).SingleInstance();
            }, () =>
            { //startUp  CallBack
                List<AnnoData> routings = new List<AnnoData>();
                foreach (var item in Anno.EngineData.Routing.Routing.Router)
                {
                    if (item.Value.RoutMethod.Name == "get_ActionResult")
                    {
                        continue;
                    }
                    var parameters = item.Value.RoutMethod.GetParameters().ToList().Select(it => new ParametersValue { Name = it.Name, Position = it.Position, ParameterType = it.ParameterType.FullName }).ToList();
                    routings.Add(new AnnoData()
                    {
                        App = Anno.Const.SettingService.AppName,
                        Id = $"{Anno.Const.SettingService.AppName}:{item.Key}",
                        Value = Newtonsoft.Json.JsonConvert.SerializeObject(new DataValue { Name = item.Value.RoutMethod.Name, Parameters = parameters })
                    });
                }
                Dictionary<string, string> input = new Dictionary<string, string>();
                input.Add(CONST.Opt, CONST.DeleteByApp);
                input.Add(CONST.App, Anno.Const.SettingService.AppName);
                var del = Newtonsoft.Json.JsonConvert.DeserializeObject<AnnoDataResult>(StorageEngine.Invoke(input));
                if (del.Status == false)
                {
                    Anno.Log.Log.Error(del);
                }
                input.Clear();
                input.Add(CONST.Opt, CONST.UpsertBatch);
                input.Add(CONST.Data, Newtonsoft.Json.JsonConvert.SerializeObject(routings));
                var rlt = Newtonsoft.Json.JsonConvert.DeserializeObject<AnnoDataResult>(StorageEngine.Invoke(input));
                if (rlt.Status == false)
                {
                    Anno.Log.Log.Error(rlt);
                }
            });
        }
    }
}
