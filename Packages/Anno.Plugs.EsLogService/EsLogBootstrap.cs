using Anno.EngineData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Anno.Const;

namespace Anno.Plugs.EsLogService
{
    public class EsLogBootstrap: IPlugsConfigurationBootstrap
    {
        public  static Dictionary<string,string> AppSet=new Dictionary<string, string>();
        public void ConfigurationBootstrap()
        {
            LoadConfuration();
            //搜索引擎配置
            Es.EsConfiguration.ConfigurationConnStr(AppSet["EsConnStr"]);
        }

        public void PreConfigurationBootstrap()
        {
            //throw new NotImplementedException();
        }

        private void LoadConfuration()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Packages", "Anno.Plugs.EsLog","Plug.config");
            string currentPath = Path.Combine(Directory.GetCurrentDirectory(), "Plug.config");
            if (File.Exists(currentPath))
            {
                path = currentPath;
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            var nodes = doc.SelectNodes("//appSettings/add");
            if(nodes!=null)
            foreach (XmlNode node in nodes)
            {
                string key = node.Attributes["key"].Value;
                string value= node.Attributes["value"].Value;
                if (!AppSet.ContainsKey(key)&&!string.IsNullOrWhiteSpace(key))
                {
                    AppSet.Add(key,value);
                }
            }

        }
    }
}
