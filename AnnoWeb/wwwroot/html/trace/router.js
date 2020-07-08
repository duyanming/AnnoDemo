/// <reference path="../../js/jquery-3.1.0.min.js" />
/// <reference path="../../js/base.js" />
var rlt = {};
$(function () {
    LoadData();
    window.$("#search").click(function () {
        LoadData();
    });
});

function LoadData() {
    var input = bif.getInput();
    input.channel = "Anno.Plugs.Trace";
    input.router = "Router";
    input.method = "GetRoutingInfo";
    input.appName = window.$("#appName").val();

    bif.process(input, function (data) {
        rlt.Rows = data.outputData;
        rlt.Total = data.outputData.length;
        BuildGrid(rlt);
    });
}
var grid = null;
function BuildGrid(data) {

    grid = window.$('#grid').ligerGrid({
        columns: [
            { display: '服务名称', width: 200, name: 'App', type: "text" },
            { display: '管道', width: 200, name: 'Channel', type: "text" },
            { display: '请路由', width: 200, name: 'Router', type: "text" },
            { display: '方法', width: 200, name: 'Method', type: "text" },
            { display: '描述', name: 'Desc', width: 300 }
        ],
        isScroll: false,
        frozen: false,
        showTitle: false,
        data: data,
        detail: { onShowDetail: showParameters,height:'auto'},
        alternatingRow: true,
        usePager: false,
        rownumbers: true,
        enabledEdit: false,
        height: '100%',
        width: '99.7%',
        heightDiff: -4,
        autoFilter: true
    });
}

function getParametersData(row) {
    var data = { Rows:[]};
    data.Rows = row.Value.Parameters;
    return data;
}

//显示参数信息
function showParameters(row, detailPanel, callback) {
    var subGrid = $("<div></div>");
    window.$(detailPanel).append(subGrid);
    window.$(subGrid).css('margin', 10).ligerGrid({
        columns:
            [
                { display: '参数名称', name: 'Name', type: 'text', width: 200 },
                { display: '位置顺序', name: 'Position', type: 'text', width: 50 },
                { display: '参数类型', name: 'ParameterType', width: 200 },
                { display: '描述', name: 'Desc', width: 300 }
            ],
        isScroll: false,
        showToggleColBtn: false,
        height: '400px',
        data: getParametersData(row),
        showTitle: false,
        onAfterShowData: callback,
        frozen: false,
        usePager: false
       
    });
}