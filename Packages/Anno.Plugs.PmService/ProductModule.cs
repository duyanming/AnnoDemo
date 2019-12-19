using System;
using System.Collections.Generic;
using System.Text;
using Anno.EngineData;
using Anno.Plugs.PmService.Model;

namespace Anno.Plugs.PmService
{
    public class ProductModule:BaseModule
    {
        private readonly string _defaultTestUrl = "http://test.biswit.com";
        private readonly string _defaultLiveUrl = "http://buy.supermarto.net";
        private readonly string _defaultCode = "300495";
        private string _model = "test";
        public ProductModule()
        {

        }

        /// <summary>
        /// 获取产品价目表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPriceList()
        {
            var http = new Common.HttpHelper();
            var code = RequestString("code") ?? "300495";
            _model = RequestString("model") ?? "test";

            var page = RequestInt32("page") ?? 1;
            var pagesize = RequestInt32("pagesize") ?? 20;

            StringBuilder dataBuild=new StringBuilder(@"{
            'serviceName': 'PriceList',
            'methodName': 'GetPriceList',
            'funcId': '4051b98e439c47a6a24723c0e6feb83a',
            'conditon': {
                'CondtionGroup1': ");
            dataBuild.Append(Model.ExpressionAnalysis.GetCondition(Request<Group>("where")));
            dataBuild.Append(@",
                'CondtionGroup2': [],
                'DockedCondtionGroup': [],
                'LogicOperator': 'and',
                'OrderItems': ''
            },
            'pageParameter': {");

            dataBuild.AppendFormat(" 'PageSize': {0},", pagesize);
            dataBuild.AppendFormat(" 'PageIndex': {0},", page);
            dataBuild.Append("   } }");
            string url = _defaultTestUrl;
            if (_model == "live")
            {
                url = _defaultLiveUrl;
            }
            var rltTask = http.HttpPostAsync($"{url}/ermwebapi/data/invoke?code={code?? _defaultCode}", dataBuild.ToString());
            StringBuilder groupBuild = new StringBuilder(@"{
            'serviceName': 'Data',
            'methodName': 'QueryListGroupCount',
            'funcId': '4051b98e439c47a6a24723c0e6feb83a',
            'enumFieldCode': 'V_POXY_ITEM_ALL.ISPUBLISHEDALIAS',
            'conditon': {
                'CondtionGroup1':  ");
            groupBuild.Append(Model.ExpressionAnalysis.GetCondition(Request<Group>("where")));
            groupBuild.Append(@",
                'CondtionGroup2': [],
                'DockedCondtionGroup': [{
                    'FuncItemCode': 'V_POXY_ITEM_ALL.ISPUBLISHEDALIAS',
                    'ItemType': 'Int16',
                    'SearchValue': '0',
                    'CompareOperator': 'eq',
                    'LogicOperator': 'and'
                }, {
                    'FuncItemCode': 'V_POXY_ITEM_ALL.ISPUBLISHEDALIAS',
                    'ItemType': 'Int16',
                    'SearchValue': '1',
                    'CompareOperator': 'eq',
                    'LogicOperator': 'and'
                }, {
                    'FuncItemCode': 'V_POXY_ITEM_ALL.ISPUBLISHEDALIAS',
                    'ItemType': 'Int16',
                    'SearchValue': '2',
                    'CompareOperator': 'eq',
                    'LogicOperator': 'and'
                }, {
                    'FuncItemCode': 'V_POXY_ITEM_ALL.ISPUBLISHEDALIAS',
                    'ItemType': 'Int16',
                    'SearchValue': 'all',
                    'CompareOperator': 'eq',
                    'LogicOperator': 'and'
                }, {
                    'FuncItemCode': 'V_POXY_ITEM_ALL.ISPUBLISHEDALIAS',
                    'ItemType': 'Int16',
                    'SearchValue': '-1',
                    'CompareOperator': 'eq',
                    'LogicOperator': 'and'
                }],
                'LogicOperator': 'and',
                'OrderItems': ''
            }
        }");
            var rltGroupTask = http.HttpPostAsync($"{ url}/ermwebapi/data/engineServiceInvoke?code={code ?? _defaultCode}", groupBuild.ToString());

            var rltObj = Newtonsoft.Json.JsonConvert.DeserializeObject<PmActionResult>(rltTask.Result.ReadToEnd());
            var totalObj  = Newtonsoft.Json.JsonConvert.DeserializeObject<PmActionResult>(rltGroupTask.Result.ReadToEnd());
            object total = totalObj.parameter["allCount"];
            var output = new Dictionary<string, object> { { "#Total", total }, { "#Rows", rltObj.data } };
            return new ActionResult(rltObj.success, null, output, rltObj.message);
        }

        public ActionResult QueryListData()
        {

            var http = new Common.HttpHelper();
            var code = RequestString("code") ?? "300495";
            _model = RequestString("model") ?? "test";

            var page = RequestInt32("page") ?? 1;
            var pagesize = RequestInt32("pagesize") ?? 20;
            var funcId = RequestString("funcId") ?? "4f388cd914da4c91a910be6061736770";

            StringBuilder dataBuild = new StringBuilder(@"{
            'serviceName': 'Data',
            'methodName': 'QueryListData',");

            dataBuild.Append($"'funcId': '{funcId}',");

            dataBuild.Append(@" 'conditon': {
                'CondtionGroup1': ");
            dataBuild.Append(Model.ExpressionAnalysis.GetCondition(Request<Group>("where"),"SAL_ORDER"));
            dataBuild.Append(@",
                'CondtionGroup2': [],
                'DockedCondtionGroup': [],
                'LogicOperator': 'and',
                'OrderItems': ''
            },
            'pageParameter': {");

            dataBuild.AppendFormat(" 'PageSize': {0},", pagesize);
            dataBuild.AppendFormat(" 'PageIndex': {0},", page);
            dataBuild.Append("   } }");

            string url = _defaultTestUrl;
            if (_model == "live")
            {
                url = _defaultLiveUrl;
            }
            var rltTask = http.HttpPostAsync($"{url}/ermwebapi/data/engineServiceInvoke?code={code ?? _defaultCode}", dataBuild.ToString());
            var rltObj = Newtonsoft.Json.JsonConvert.DeserializeObject<PmActionResult>(rltTask.Result.ReadToEnd());
            object total = rltObj.parameter["TotalRecordCount"];
            var output = new Dictionary<string, object> { { "#Total", total }, { "#Rows", rltObj.data } };
            return new ActionResult(rltObj.success,null, output,rltObj.message);
        }

        public ActionResult OpenOneData()
        {
            var http = new Common.HttpHelper();
            var code = RequestString("code") ?? "300495";
            _model = RequestString("model") ?? "test";
            var funcId = RequestString("funcId") ?? "4f388cd914da4c91a910be6061736770";
            var recordId = RequestString("recordId") ?? "-1";
            StringBuilder dataBuild = new StringBuilder("{");
            dataBuild.Append($"'serviceName': 'Data',");
            dataBuild.Append($"'methodName': 'OpenOneData',");
            dataBuild.Append($"'funcId': '{funcId}',");
            dataBuild.Append($"'recordId': '{recordId}'");
            dataBuild.Append("}");
            string url = _defaultTestUrl;
            if (_model == "live")
            {
                url = _defaultLiveUrl;
            }
            var rltTask = http.HttpPostAsync($"{url}/ermwebapi/data/engineServiceInvoke?code={code ?? _defaultCode}", dataBuild.ToString());
            var rltObj = Newtonsoft.Json.JsonConvert.DeserializeObject<PmActionResult>(rltTask.Result.ReadToEnd());
            return new ActionResult(rltObj.success,rltObj.data,rltObj.parameter, rltObj.success?null:rltObj.message);
        }
    }
}
