using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testDataBase.App_Start
{
    public class ProductsInfo
    {
        //字段
        int productid;
        string productname;
        string unitprice;
        int categoryid;


        public ProductsInfo()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        //插入商品
        public ProductsInfo(string productname, string unitprice, int categoryid)
        {
            this.productname = productname;
            this.unitprice = unitprice;
            this.categoryid = categoryid;
        }
        //查看全部
        //插入商品
        public ProductsInfo(int productid, string productname, string unitprice, int categoryid)
        {
            this.productid = productid;
            this.productname = productname;
            this.unitprice = unitprice;
            this.categoryid = categoryid;
        }
        //封装
        public int Productid
        {
            get { return productid; }
            set { productid = value; }
        }
        public string Productname
        {
            get { return productname; }
            set { productname = value; }
        }
        public string Unitprice
        {
            get { return unitprice; }
            set { unitprice = value; }
        }
        public int Categoryid
        {
            get { return categoryid; }
            set { categoryid = value; }
        }
    }
}