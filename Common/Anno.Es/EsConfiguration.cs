using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anno.Es
{
    public static class EsConfiguration
    {
        /// <summary>
        /// ElasticSearch 链接
        /// </summary>
        public static List<Uri> Uris { get; private set; } = new List<Uri>();

        public static void ConfigurationConnStr(string connStr)
        {
            if (string.IsNullOrWhiteSpace(connStr))
            {
                throw new ArgumentNullException(nameof(connStr), "请设置一个有效的链接字符串。例如[http://192.168.10.4:9200/,http://192.168.10.5:9200/]");
            }

            foreach (var uri in connStr.Split(','))
            {
                if (!string.IsNullOrWhiteSpace(uri))
                {
                    Uris.Add(new Uri(uri));
                }
            }

            if (Uris.Count <= 0)
            {
                throw new ArgumentNullException(nameof(connStr), "请设置一个有效的链接字符串。例如[http://192.168.10.4:9200/,http://192.168.10.5:9200/]");
            }
        }
    }
}
