"use strict";
//全局变量
let indexGlobal = {}

$(function () {

    //上传图片
    $("#btnImportOK").click(function () {

        var formData = new FormData($("#uploadForm")[0]);
        console.log(formData)
        $.ajax({
            type: "POST",
            data: formData,
            url: "/ProductsOper/Upload",
            contentType: false,
            processData: false,
        }).success(function (data) {
            console.log(data);
            if (data.status) {
                console.log(data.msg);

            } else {
                console.log(data.msg);

            }
        }).error(function (data) {
            console.log(data);

        });
    });
});

layui.use('carousel', function () {
    var carousel = layui.carousel;
    //建造实例
    carousel.render({
        elem: '#test1'
        , width: '100%' //设置容器宽度
        , height: '100%' //设置容器高度
        , arrow: 'always' //始终显示箭头
        //,anim: 'updown' //切换动画方式
    });
});


//新增授课计划信息
let insert = () => {
    let _json = { productName: $("#ProductName").val(), unitPrice: $("#Unitprice").val(), categoryId: $("#Categoryid").val(), productId: $("#Productid").val(), createTime: "2019-03-18" };
    $.ajax({
        type: 'post'
        , url: `/ProductsOper/insert`
        , cache: false
        , data: _json
        //, dataType: 'json'
        //, contentType: "application/json; charset=utf-8"
        , success: function (r) {
            console.log(r);
            search();  //重新查询
        }
    })
};


//编辑授课计划信息
let modify = () => {
    console.log("modify");
    $.ajax({
        type: 'post'
        , url: `/ProductsOper/modify`
        , cache: false
        , data: { productname: "修改类型", unitprice: "200", categoryId: "1", modifytime: "2019-03-22", productid: 3 }
        , dataType: 'json'
        , success: function (r) {
            console.log(r);
            search();  //重新查询
        }
    })
};

//删除授课计划信息
let Delete = (id) => {
    $.ajax({
        type: 'post'
        , url: `/ProductsOper/Delete`
        , cache: false
        , data: { productid: id }
        , dataType: 'json'
        , success: function (r) {
            console.log(r);
            search();  //重新查询
        }
    })
}


//查询授课计划信息
let search = () => {
    $.ajax({
        type: 'get'
        , url: `/ProductsOper/GetProductByCateid`
        , cache: false
        , data: { cateid: 1 }
        //, dataType: 'json'
        , success: function (r) {
            console.log(r);
            searchData(r.Data);  //加载表格数据
        }
    })
}



//获取授课计划信息数据
let searchData = (searchData) => {
    console.log(searchData)
    layui.use(['laypage', 'table', 'layer'], function () {
        var laypage = layui.laypage //分页
            , table = layui.table //表格
            , layer = layui.layer;//表格

        //执行一个 table 实例
        table.render({
            elem: '#demo'
            , height: 420
            , title: '用户表'
            , page: true //开启分页
            , toolbar: 'default' //开启工具栏，此处显示默认图标，可以自定义模板，详见文档
            , totalRow: true //开启合计行
            , data: searchData
            , cols: [[ //表头
                { type: 'checkbox', fixed: 'left' }
                , {
                    field: 'id', title: 'ID', width: 80, sort: true, totalRowText: '合计：', templet: function (d) {
                        return d.LAY_TABLE_INDEX + 1;
                    }
                }
                , { field: 'productName', title: '科目' }
                , { field: 'unitPrice', title: '单价', sort: true, totalRow: true }
                , { fixed: 'right', width: 165, align: 'center', toolbar: '#barDemo' }
            ]]
        });

        //监听头工具栏事件
        table.on('toolbar(test)', function (obj) {
            var checkStatus = table.checkStatus(obj.config.id)
                , data = checkStatus.data; //获取选中的数据
            switch (obj.event) {
                case 'add':
                    //layer.msg('添加');
                    layer.open({
                        type: 1
                        , title: "添加"
                        , offset: 'auto' //具体配置参考：http://www.layui.com/doc/modules/layer.html#offset
                        , content: '<div style="padding: 20px 100px;">asdasd</div>'
                        , btn: ['关闭', '确认']
                        , btnAlign: 'c' //按钮居中
                        , shade: 0.3 //不显示遮罩
                        , yes: function (index, layero) {
                            //按钮【按钮一】的回调
                            console.log('关闭')
                            console.log(index)
                            layer.close(index);
                            //layer.closeAll();
                        }
                        , btn2: function (index, layero) {
                            //按钮【按钮二】的回调
                            layer.close(index);
                            console.log('确认');
                            layer.open({
                                type: 1
                                , title: "提示"
                                , offset: 'auto' //具体配置参考：http://www.layui.com/doc/modules/layer.html#offset
                                , content: '<div style="padding: 20px 100px;">asdasd</div>'
                                , btn: ['关闭', '确认']
                                , btnAlign: 'c' //按钮居中
                                , shade: 0.3 //不显示遮罩
                                , yes: function (index, layero) {
                                    //按钮【按钮一】的回调
                                    console.log('关闭')
                                    console.log(index)
                                    layer.close(index);
                                    //layer.closeAll();
                                }
                                , btn2: function (index, layero) {
                                    //按钮【按钮二】的回调
                                    console.log('确认')
                                    return false //开启该代码可禁止点击该按钮关闭
                                }

                            });
                            return false //开启该代码可禁止点击该按钮关闭
                        }

                    });
                    break;
                case 'update':
                    if (data.length === 0) {
                        layer.msg('请选择一行');
                    } else if (data.length > 1) {
                        layer.msg('只能同时编辑一个');
                    } else {
                        console.log(checkStatus.data[0])
                        layer.alert('编辑 [id]：' + checkStatus.data[0].productId);
                    }
                    break;
                case 'delete':
                    if (data.length === 0) {
                        layer.msg('请选择一行');
                    } else {
                        layer.msg('删除');
                        Delete(checkStatus.data[0].categoryId);   //删除记录
                    }
                    break;
            };
        });

        //监听行工具事件
        table.on('tool(test)', function (obj) { //注：tool 是工具条事件名，test 是 table 原始容器的属性 lay-filter="对应的值"
            var data = obj.data //获得当前行数据
                , layEvent = obj.event; //获得 lay-event 对应的值
            if (layEvent === 'detail') {
                layer.msg('查看操作');
            } else if (layEvent === 'del') {
                layer.confirm('真的删除行么', function (index) {
                    obj.del(); //删除对应行（tr）的DOM结构
                    Delete(data.productId);   //删除记录
                    layer.close(index);
                    //向服务端发送删除指令
                });
            } else if (layEvent === 'edit') {
                layer.msg('编辑操作');
            }
        });

        //分页
        laypage.render({
            elem: 'pageDemo' //分页容器的id
            , count: 100 //总页数
            , skin: '#1E9FFF' //自定义选中色值
            //,skip: true //开启跳页
            , jump: function (obj, first) {
                if (!first) {
                    layer.msg('第' + obj.curr + '页', { offset: 'b' });
                }
            }
        });


    });
}