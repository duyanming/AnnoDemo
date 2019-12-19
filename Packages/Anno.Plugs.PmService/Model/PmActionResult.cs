using System;
using System.Collections.Generic;
using System.Text;

namespace Anno.Plugs.PmService.Model
{
    /// <summary>
    /// 品美返回结果
    /// </summary>
    public class PmActionResult
    {
        public bool success { get; set; }

        public object data { get; set; }

        public string message { get; set; }

        public Dictionary<string, dynamic> parameter { get; set; }
    }
}
