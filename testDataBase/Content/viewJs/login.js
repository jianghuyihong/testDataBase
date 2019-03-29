"use strict";
//全局变量
let loginGlobal = {
    inputNameRex: /^[A-Za-z0-9]+$/ //用户名正则(英文及数字)
    , inputPasswordRex: /^[A-Za-z0-9]{6}$/  //密码正则(6位英文及数字)
    , inputName: `` //用户名值
    , inputPassword: `` //用户密码值
    , inputNameIndex: 0 //用户名框弹窗索引
    , inputPasswordIndex: 0  //密码框弹窗索引
}
$(function () {
    console.log("login")

    //校验用户名合法性
    $("#userName").keyup(function () {
        loginGlobal.inputName = $("#userName").val();   //获取用户名的值
        if (loginGlobal.inputPasswordRex.test(loginGlobal.inputPassword) && loginGlobal.inputNameRex.test(loginGlobal.inputName)) {
            $("#confirmBtn").removeClass("layui-btn-disabled");  //激活确认按钮
            layer.close(loginGlobal.inputNameIndex);  //关闭用户名框错误提示
        } else {
            if (!loginGlobal.inputNameRex.test(loginGlobal.inputName)) {
                if ($(`#layui-layer${loginGlobal.inputNameIndex}`).length == 0) {//如果用户名框错误提示层不存在
                    console.log(loginGlobal.inputNameRex.test(loginGlobal.inputName))
                    layer.open({
                        type: 4
                        , content: ['用户名由字母或者数字构成', '#userName'] //数组第二项即吸附元素选择器或者DOM
                        , shade: 0
                        , tips: [2, 'red']
                        , closeBtn: 0
                        , success: function (layero, index) {
                            loginGlobal.inputNameIndex = index;
                        }
                    });
                }
            } else {
                layer.close(loginGlobal.inputNameIndex);  //关闭用户名框错误提示
            }
            $("#confirmBtn").addClass("layui-btn-disabled");  //禁用确认按钮
        }
    })

    //校验密码合法性
    $("#userPassword").keyup(function () {
        loginGlobal.inputPassword = $("#userPassword").val();   //获取用户名的值
        if (loginGlobal.inputPasswordRex.test(loginGlobal.inputPassword) && loginGlobal.inputNameRex.test(loginGlobal.inputName)) {
            $("#confirmBtn").removeClass("layui-btn-disabled");  //激活确认按钮
            layer.close(loginGlobal.inputPasswordIndex);  //关闭密码框错误提示
        } else {
            if (!loginGlobal.inputPasswordRex.test(loginGlobal.inputPassword)) {
                if ($(`#layui-layer${loginGlobal.inputPasswordIndex}`).length == 0) {  //如果密码框错误提示层不存在
                    layer.open({
                        type: 4
                        , content: ['密码由字母或者数字构成(6位)', '#userPassword'] //数组第二项即吸附元素选择器或者DOM
                        , shade: 0
                        , tips: [2, 'red']
                        , closeBtn: 0
                        , success: function (layero, index) {
                            loginGlobal.inputPasswordIndex = index;
                        }
                    });
                }
            } else {
                layer.close(loginGlobal.inputPasswordIndex);  //关闭用户名框错误提示
            }
            $("#confirmBtn").addClass("layui-btn-disabled");  //禁用确认按钮
        }
    })
})

//登录
let confirm = (obj) => {
    if ($.trim($(obj).attr("class")) == "") {
        console.log("确认");
        $.ajax({
            type: 'get'
            , url: `/ProductsOper/login`
            , cache: false
            , data: { userName: loginGlobal.inputName, passWord: loginGlobal.inputPassword }
            //, dataType: 'json'
            , success: function (r) {
                console.log(r);
                console.log(r.Msg);
                console.log(r.Msg.ID);
                if (!r.Success) {
                    layer.open({
                        type: 1
                        , content: ['用户名或者密码不对，请重新输入！']
                    });
                }
            }
        })
    }
}

//重置
let cancel = () => {
    console.log("重置")
    $("input").val(``);  //清空文本框输入的内容
}


