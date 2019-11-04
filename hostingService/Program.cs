using System;

namespace hostingService
{
    using Anno.Rpc.Server;
    using Anno.Loader;
    using  Autofac;
    using Anno.EngineData;
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
            });
        }
    }
}
