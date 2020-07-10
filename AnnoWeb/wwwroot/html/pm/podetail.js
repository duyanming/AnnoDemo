/// <reference path="../../js/jquery.min.js" />
/// <reference path="../../js/scripts/base.js" />
$(function () {
    Build();
});
var grid = null;
var ds = null;
function Build() {
    var args = new Object();
    args = bif.GetUrlParms();

    var input = bif.getInput();
    input.channel = "Anno.Plugs.Pm";
    input.router = "Product";
    input.method = "OpenOneData";
    input.model = args["model"];
    input.code = args["code"];
    input.funcId = args["funcId"];
    input.recordId = args["recordId"];

    bif.process(input, function (data) {
        if (data.status) {
            ds = data;
            InitForm();
            BuildGrid();
        } else {
            $.ligerDialog.error(data.msg);
        }
    });

}
var groupicon = "../../js/lib/ligerUI/skins/icons/communication.gif";
var form;
function InitForm() {
    form = $("#form").ligerForm({
        fields: [
            { type: 'text', label: '单证号码', name: 'SNUM', group: "基本信息", groupicon: groupicon },
            { type: 'text', label: '制单人', name: 'EID_USRNAME', newline: false },
            { type: 'text', label: '来源订单号', name: 'CMSNUM', newline: false },
            { type: 'text', label: '推送日期', name: 'CONFIRMDT', newline: true },
            { type: 'text', label: '流水号', name: 'BSNUM', newline: false },
            { type: 'text', label: '制单日期', name: 'EDT', newline: false },
            { type: 'text', label: '单证状态', name: 'STATE_ENUM', newline: true },
            { type: 'text', label: '开票状态', name: 'INVOICE_ENUM', newline: false },
            { type: 'text', label: 'SAP状态', name: 'SAPSTATE_ENUM', newline: false },
            { type: 'text', label: '备注', name: 'MM', newline: true },
            { type: 'text', label: '供应方单位', name: 'V_N', group: "供应方信息", groupicon: groupicon },
            { type: 'text', label: '供应方联系人', name: 'SCONTACT', newline: false },
            { type: 'text', label: '供应方电话', name: 'CM_STEL', newline: false },
            { type: 'text', label: '供应方邮箱', name: 'SEMAIL', newline: true },
            { type: 'text', label: '提货/发货日期', name: 'DELIVERYDATE', newline: false },
            { type: 'text', label: '起运省', name: 'PROVINCE1_N', newline: false },
            { type: 'text', label: '起运市', name: 'CITY1_N', newline: true },
            { type: 'text', label: '起运区', name: 'AREA1_N', newline: false },
            { type: 'text', label: '详细提货地址', name: 'DELIVERYADDRESS_N', newline: false },
            { type: 'text', label: '厂家销售单号', name: 'ORDERSNUM', newline: true },
            { type: 'text', label: '提货单号', name: 'OUTSNUM', newline: false },
            { type: 'text', label: '提货备注', name: 'DELIVERYMM', newline: false },
            { type: 'text', label: '采购方单位', name: 'SV_N', group: "采购方信息", groupicon: groupicon },
            { type: 'text', label: '采购方联系人', name: 'PCONTACT', newline: false },
            { type: 'text', label: '采购方电话', name: 'STEL', newline: false },

            { type: 'text', label: '代办方单位', name: 'VD_USRNAME', group: "代办方信息", groupicon: groupicon },
            { type: 'text', label: '代办方联系人', name: 'DCONTACT', newline: false },
            { type: 'text', label: '代办方电话', name: 'DTEL', newline: false },

            { type: 'text', label: '收货联系人', name: 'RCONTACT', group: "物流信息", groupicon: groupicon },
            { type: 'text', label: '收货手机', name: 'RTEL', newline: false },
            { type: 'text', label: '收货地址', name: 'RECADDR', newline: false },

            { type: 'text', label: '金额合计', name: 'PURTOTALAMT', group: "财务信息", groupicon: groupicon },
            { type: 'text', label: '应付平台费用', name: 'YFAMT', newline: false },
            { type: 'text', label: '实付金额', name: 'PURTOTALSFAMT', newline: false }
        ], buttons: [
            {
                text: '返回', width: 60, click: function () {
                    window.history.go(-1);
                }
            }
        ]
        , readonly: true
    });
    form.setData(ds.outputData.CurrentData.SAL_ORDER[0]);
}
function BuildGrid() {
    var griddata = { Rows: ds.outputData.CurrentData.SAL_ORDERPACKAGEDETAILTEMP };
    $('#grid').ligerGrid({
        columns: [
            { display: '物品名称', width: 225, name: 'I_N', text: "text" },
            { display: '物品编码', width: 225, name: 'I_C', textField: "name" },
            { display: '厂家编码', width: 225, name: 'I_NC', text: "text" },
            { display: '规格', width: 225, name: 'STANDARD', text: "text" },
            { display: '辅助属性组名称', width: 225, name: 'P_N', text: "text" },
            { display: '数量', width: 225, name: 'QUANTITY', text: "float" },
            { display: '单位', width: 225, name: 'U_N', text: "text" },
            { display: '采购金额', width: 225, name: 'PURAMT', text: "float" },
            { display: '已发货数量', width: 225, name: 'OUTQTY', text: "float" }

        ],
        data: griddata,
        usePager: false,
        rownumbers: true,
        enabledEdit: false,
        width: '99.7%',
        heightDiff: -4
    });

}