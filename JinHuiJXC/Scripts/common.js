
function addTab(title, url) {
    if ($('#divMain').tabs('exists', title)) {
        $('#divMain').tabs('select', title);
    } else {
        var content = '<iframe scrolling="auto" frameborder="0"  src="' + url + '" class="iframe"></iframe>';
        $('#divMain').tabs('add', {
            title: title,
            content: content,
            closable: true
        });
    }
}

function getNowDate() {
    var date = new Date();
    var seperator1 = "-";
    var month = date.getMonth() + 1;
    var strDate = date.getDate();
    if (month >= 1 && month <= 9) {
        month = "0" + month;
    }
    if (strDate >= 0 && strDate <= 9) {
        strDate = "0" + strDate;
    }
    var currentdate = date.getFullYear() + seperator1 + month + seperator1 + strDate;
    return currentdate;
}

function getNowTime() {
    var date = new Date();
    var seperator1 = "-";
    var seperator2 = ":";
    var month = date.getMonth() + 1;
    var strDate = date.getDate();
    if (month >= 1 && month <= 9) {
        month = "0" + month;
    }
    if (strDate >= 0 && strDate <= 9) {
        strDate = "0" + strDate;
    }
    var currentdate = date.getFullYear() + seperator1 + month + seperator1 + strDate
        + " " + date.getHours() + seperator2 + date.getMinutes()
        + seperator2 + date.getSeconds();
    return currentdate;
}

function getNumberOnTime() {
    var d = new Date();
    var year = d.getFullYear().toString();
    var mon = d.getMonth() + 1;
    if (mon <= 9) {
        mon = "0" + mon;
    }
    var day = d.getDate();
    if (day <= 9) {
        day = "0" + day;
    }
    var hour = d.getHours().toString();
    var min = d.getMinutes().toString();
    if (min <= 9) {
        min = "0" + min;
    }
    var sec = d.getSeconds();
    if (sec <= 9) {
        sec = "0" + sec;
    }
    var mil = d.getTime().toString();
    var a = year.substr(2) + mon + day + hour + min + sec;
    return a;
}

//获取QueryString的数组

function getQueryString() {
    var params = document.location.search, reg = /(?:^\?|&)(.*?)=(.*?)(?=&|$)/g, temp, args = {};
    while ((temp = reg.exec(params)) != null) args[temp[1]] = decodeURIComponent(temp[2]);
    return args;
}

function setPinYin() {
    $('#Name').textbox({
        onChange: function (value) {
            var name = value;
            var pinyin = pinyinUtil.getFirstLetter(name);
            $("#Pinyin").textbox('setValue', pinyin);
        }
    });
}