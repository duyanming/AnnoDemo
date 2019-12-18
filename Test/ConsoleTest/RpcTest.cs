using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Anno.Rpc.Client;

namespace ConsoleTest
{
    public class RpcTest
    {
        public void Handle() {
            DefaultConfigManager.SetDefaultConfiguration("RpcTest", "127.0.0.1", 6660, false);

            To:
            Console.Write("请输入调用次数：");
            long.TryParse(Console.ReadLine(), out long num);
            //List<Task> ts = new List<Task>();
            Dictionary<string, string> input = new Dictionary<string, string>();

            input.Add("channel", "Anno.Plugs.CacheRateLimit");
            input.Add("router", "Cache");
            input.Add("method", "Cache");

            //input.Add("router", "Limit");
            //input.Add("method", "Limit");

            Console.WriteLine("输入附加消息msg:");
            input.Add("msg", "Limit ClientMsg" + Console.ReadLine());
            Stopwatch sw = Stopwatch.StartNew();
            Parallel.For(0, num, i =>
            {

                var x = Connector.BrokerDns(input);
                //Console.WriteLine(x);
                if (x.IndexOf("true") <= 0)
                {
                    Console.WriteLine(x);
                }


            });
            long ElapsedMilliseconds = sw.ElapsedMilliseconds;
            if (ElapsedMilliseconds == 0)
            {
                ElapsedMilliseconds = 1;
            }
            Console.WriteLine($"运行时间：{sw.ElapsedMilliseconds}/ms,TPS:{(num) * 1000 / ElapsedMilliseconds}");
            sw.Stop();
            goto To;
        }
    }
}
