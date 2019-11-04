using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace traceWeb
{
    public class TraceConfig
    {
        public Target Target { get; set; } = new Target();
        public Limit Limit { get; set; } = new Limit();
    }

    public class Target
    {
        public string AppName { get; set; }
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public bool TraceOnOff { get; set; }
    }

    public class Limit
    {
        public bool Enable { get; set; }
        public Taglimit[] TagLimits { get; set; }
        public Iplimit IpLimit { get; set; }
        public string[] White { get; set; }
        public string[] Black { get; set; }
    }

    public class Taglimit : Iplimit
    {
        private string _channel = "*";
        private string _router = "*";
        public string channel
        {
            get { return _channel; }
            set
            {
                if (value == string.Empty || value == null)
                {
                    _channel = "*";
                }
                else
                {
                    _channel = value;
                }
            }
        }
        public string router
        {
            get { return _router; }
            set
            {
                if (value == string.Empty || value == null)
                {
                    _router = "*";
                }
                else
                {
                    _router = value;
                }
            }
        }
    }

    public class Iplimit
    {
        /// <summary>
        /// 时间片段
        /// </summary>
        public uint timeSpan { get; set; }
        /// <summary>
        /// 单位 时间片段 内允许通过的请求个数
        /// </summary>
        public uint rps { get; set; }
        /// <summary>
        /// 令牌桶大小
        /// </summary>
        public uint limitSize { get; set; } = 200;
    }

}
