using System;
using System.Collections.Generic;
using System.Text;

namespace Anno.Plugs.PmService.Model
{
    public class PmCondition
    {
        public string CompareOperator { get; set; } = "contain";
        public string FuncItemCode { get; set; }
        public string ItemType { get; set; } = "AnsiString";
        public string LogicOperator { get; set; } = "and";

        public string SearchValue { get; set; }
    }

    public class ExpressionAnalysis
    {
        /// <summary>
        /// var groups = Request<Group>("where");
        /// </summary>
        /// <param name="groups"></param>
        /// <returns></returns>
        public static string GetCondition(EngineData.Group groups,string table= "V_POXY_ITEM_ALL")
        {
           List<PmCondition> conditions=new List<PmCondition>();
            if (groups != null && groups.rules.Count > 0)
            {
                foreach (var rule in groups.rules)
                {
                    conditions.Add(new PmCondition()
                    {
                        CompareOperator=GetOp(rule),
                        ItemType = GetItemType(rule),
                        SearchValue = rule.value,
                        LogicOperator= "and",
                        FuncItemCode=$"{table}.{rule.field.ToUpper()}"
                    });
                }
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(conditions);
        }

       static string GetItemType(EngineData.Rule rule)
        {
            string itemType;
            if (rule.type == "number" || rule.type == "int" || rule.type == "float")
            {
                itemType = "Decimal";
            }
            else if (rule.type == "date")
            {
                itemType = "DateTime";
            }
            else
            {
                itemType = "AnsiString";
            }

            return itemType;
        }

        private static string GetOp(EngineData.Rule rule)
        {
            switch (rule.op)
            {
                case "equal":
                    return $"eq";
                case "notequal":
                    return $"uneq";
                case "startwith":
                    return $"lcontain";
                case "endwith":
                    return $"rcontain";
                case "like":
                    return $"contain";
                case "greater":
                    return $"gt";
                case "greaterorequal":
                    return $"gteq";
                case "less":
                    return $"les";
                case "lessorequal":
                    return $"leseq";
                case "in":
                    return $"eq";
                case "notin":
                    return $"uneq";
                default:
                    return "eq";
            }
        }
    }
}
