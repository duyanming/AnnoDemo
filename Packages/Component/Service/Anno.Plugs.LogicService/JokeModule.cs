using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Anno.EngineData;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Anno.Plugs.LogicService
{
    public class JokeModule : BaseModule
    {
        public JokeModule()
        {
        }

        public ActionResult BeautyPic()
        {
            var page = RequestInt32("page") ?? 0;
            var pageSize = RequestInt32("page_size") ?? 30;
            var http = new Common.HttpHelper();
            string url = $"http://fuli1024.com/weibofun/weibo_list.php" +
                         $"?apiver=20100&category=weibo_girls&page={page}&page_size={pageSize}&max_timestamp=-1&latest_viewed_ts=1511493300" +
                         $"&platform=aphone&sysver=7.1.1&appver=1.7.3&buildver=1.7.3&app_ver=10703&udid=a_db25e2245dae6e40&channel=xiaomi&wf_uid=67023561";
            var json = http.HttpGetAsync(url+"t="+DateTime.Now.Millisecond);
            return new ActionResult(true, JsonConvert.DeserializeObject<JObject>(json.Result.ReadToEnd()));
        }

        public ActionResult Test()
        {
            var i = new Random().Next(1, 80);
           System.Threading.Tasks.Task.Delay(i).Wait();//等待1秒
            return new ActionResult(true, i+ " :Test");
        }
        public ActionResult Test0()
        {
            return new ActionResult(true);
        }
        public ActionResult Test1(string id)
        {
            return new ActionResult(true,id+ " From Server Test1.");
        }
        public ActionResult Test2(TestDto dto)
        {
            var vrlt = dto.IsValid();
            if (!vrlt.IsVaild)
            {
                return new ActionResult(false, vrlt.ErrorMembers);
            }
            return new ActionResult(true, "OK  Test2");
        }
        public ActionResult TestFb([FromBody]TestDto dto)
        {
            var vrlt = dto.IsValid();
            if (!vrlt.IsVaild)
            {
                return new ActionResult(false, vrlt.ErrorMembers);
            }
            return new ActionResult(true, "TestFb");
        }
    }

    public class TestDto
    {
        [Required(ErrorMessage = "名称字段【Name】必须输入")]
        public string Name { get; set; }
        [Range(0,150,ErrorMessage ="年龄有效范围0-150")]
        public int Age { get; set; }

        public DateTime Birthday { get; set; }
    }
}
