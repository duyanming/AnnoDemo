/// <reference path="../../js/jquery.min.js" />
/// <reference path="../../js/scripts/base.js" />
$(function() {
    BuildGrid();
});
var grid = null;
function BuildGrid() {
    var args = new Object();
    args = bif.GetUrlParms();

    var input = bif.getInput();
    input.channel = "Anno.Plugs.Pm";
    input.router = "Product";
    input.method = "GetPriceList";
    input.model = args["model"];
    input.code = args["code"];
    grid = $('#grid').ligerGrid({
        columns: [
            {
                display: '查看', name: '详细', width: 60, render: function (rowdata, rowindex, value) {
                    var url = "detail.html?ID=";
                    return '<a href="' + url + rowdata.TraceId + '">详细</a>';
                }, frozen: true
            },
            { display: '厂家编码', width: 100, name: 'NC', type: "text", frozen: true },
            { display: '产品编码', width: 200, name: 'C', type: "text", frozen: true },
            { display: '产品名称', width: 100, name: 'N', type: "text", frozen: true},
            { display: '供应商', width: 100, name: 'V_N', type: "text"},
            { display: '来源', width: 100, name: 'PA_ENUM', type: "text"},
            { display: '品牌', width: 100, name: 'BRAND_N', type: "text" },

            { display: '厂家采购价', width: 100, name: 'SALPRC', type: "float" },
            { display: '最终销售价', width: 100, name: 'FPRICE', type: "text" },
            { display: '计价单位', width: 100, name: 'U_N', type: "text" },


            { display: '规格型号', width: 200, name: 'MODELTYPE', type: "text" },
            { display: '上架状态', width: 200, name: 'ISPUBLISHEDALIAS_ENUM', type: "text" },
            { display: '提交日期', width: 200, name: 'RELEASEDATE', type: "date" }
        ],
        url: bif.ajaxpara.src,
        dataAction: 'server', //服务器排序
        pageSize: 20,
        parms: input,
        alternatingRow: true,
        usePager: true,
        rownumbers: true,
        enabledEdit: false,
        height: '100%',
        width: '99.7%',
        heightDiff: -4,
        autoFilter: true
    });
}