var jsonNameList;

$(function () {
    $.ajax({
        url: "/api/Goods/GetAllNameList",
        type: "get",
        dataType: "json",
        success: function (data) {
            var oJson = JSON.parse(data);
            jsonNameList = oJson;
            $('#GoodsName').combobox('loadData', jsonNameList);
            $('#GoodsBarcode').combobox('loadData', jsonNameList);
            $('#GoodsCode').combobox('loadData', jsonNameList);
            $('#GoodsPinyin').combobox('loadData', jsonNameList);
        },
        error: function (msg) {
            alert("很抱歉，未能添加相关信息，请稍候重试。或与技术人员联系。" + msg.statusText);
        }
    });
});

function SalesRecDel(rowid) {
    $.ajax({
        url: "/api/SalesRec/DeleteSalesRec?SalesID=" + rowid,
        type: "Delete",
        dataType: "json",
        success: function (data) {
            var oJson = JSON.parse(data);
            if (oJson == 1) {
                $.messager.alert('提示', '信息已经成功删除');
                $('#dgList').datagrid('reload');
            }
            else {
                $.messager.alert('提示', '很抱歉，未能删除相关信息，请稍候重试。或与技术人员联系。');
            }
        },
        error: function (msg) {
            alert("很抱歉，未能删除相关信息，请稍候重试。或与技术人员联系。" + msg.statusText);
        }
    });
}

//console.debug(jsonNameList);