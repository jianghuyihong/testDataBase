using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testDataBase.Models
{
    public class Products
    {
        
        public Products()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        //插入商品
        public Products(string productname, string unitprice, int categoryid)
        {
            this.productname = productname;
            this.unitprice = unitprice;
            this.categoryid = categoryid;
        }
        //查看全部
        //插入商品
        public Products(int productid, string productname, string unitprice, int categoryid)
        {
            this.productid = productid;
            this.productname = productname;
            this.unitprice = unitprice;
            this.categoryid = categoryid;
        }
        //封装
        private int productid;
        public int productId
        {
            get { return productid; }
            set { productid = value; }
        }
        private string productname;
        public string productName
        {
            get { return productname; }
            set { productname = value; }
        }
        private string unitprice;
        public string unitPrice
        {
            get { return unitprice; }
            set { unitprice = value; }
        }
        private int categoryid;
        public int categoryId
        {
            get { return categoryid; }
            set { categoryid = value; }
        }
    }
}