/// <reference path="../../js/jquery-3.1.0.min.js" />
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
    input.method = "QueryListData";
    input.model = args["model"];
    input.code = args["code"];
    input.funcId = args["funcId"];
    grid = $('#grid').ligerGrid({
        columns: [
            {
                display: '查看', name: '详细', width: 60, render: function (rowdata, rowindex, value) {
                    var url = "podetail.html?recordId=";
                    return '<a href="' + url + rowdata.ID + '&model=' + input.model + '&code=' + input.code + '&funcId=' + input.funcId+ '">详细</a>';
                }, frozen: true
            },
            { display: '单证号码', width: 200, name: 'SNUM', type: "text", frozen: true },
            { display: '来源订单号', width: 200, name: 'CMSNUM', type: "text", frozen: true },
            { display: '流水号', width: 100, name: 'BSNUM', type: "text", frozen: true },
            { display: '制单日期', width: 200, name: 'EDT', type: "date" },
            { display: '单证状态', width: 100, name: 'STATE_ENUM', type: "text"},
            { display: '供应方单位', width: 100, name: 'V_N', type: "text"},
            { display: '采购方单位', width: 100, name: 'GV_N', type: "text" },

            { display: '起运省', width: 100, name: 'PROVINCE1_N', type: "text" },
            { display: '起运市', width: 100, name: 'CITY1_N', type: "text" },
            { display: '起运区', width: 100, name: 'AREA1_N', type: "text" },

            { display: '送货方式', width: 100, name: 'STYPE_ENUM', type: "text" },
            { display: '金额合计', width: 100, name: 'PURTOTALAMT', type: "float" },
            { display: '应付平台费用', width: 100, name: 'YFAMT', type: "float" },
            { display: '实付金额', width: 200, name: 'PURTOTALSFAMT', type: "float" }
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