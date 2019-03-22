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
        ////插入商品
        //public Products(string productname, string unitprice, string categoryid)
        //{
        //    this.productname = productname;
        //    this.unitprice = unitprice;
        //    this.categoryid = categoryid;
        //}
        //
        /// <summary>
        /// 查看全部
        /// </summary>
        /// <param name="productid">产品id</param>
        /// <param name="productname">产品名称</param>
        /// <param name="unitprice">产品单价</param>
        /// <param name="categoryid">分类id</param>
        /// <param name="createtime">创建时间</param>
        /// <param name="modifytime">修改时间</param>
        public Products(int productid, string productname, string unitprice, string categoryid, string createtime, string modifytime)
        {
            this.productid = productid;
            this.productname = productname;
            this.unitprice = unitprice;
            this.categoryid = categoryid;
            this.createtime = createtime;
            this.modifytime = modifytime;
        }
        //public Products(int productid, string productname, string unitprice)
        //{
        //    this.productid = productid;
        //    this.productname = productname;
        //    this.unitprice = unitprice;
        //    //this.createtime = createtime;
        //    //this.modifytime = modifytime;
        //}
        /// <summary>
        /// 产品ID
        /// </summary>
        private int productid;
        public int productId
        {
            get { return productid; }
            set { productid = value; }
        }
        /// <summary>
        /// 产品名
        /// </summary>
        private string productname;
        public string productName
        {
            get { return productname; }
            set { productname = value; }
        }
        /// <summary>
        /// 产品单价
        /// </summary>
        private string unitprice;
        public string unitPrice
        {
            get { return unitprice; }
            set { unitprice = value; }
        }
        /// <summary>
        /// 分类ID
        /// </summary>
        private string categoryid;
        public string categoryId
        {
            get { return categoryid; }
            set { categoryid = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        private string createtime;
        public string createTime
        {
            get { return createtime; }
            set { createtime = value; }
        }
        /// <summary>
        /// 编辑时间
        /// </summary>
        private string modifytime;
        public string modifyTime
        {
            get { return modifytime; }
            set { modifytime = value; }
        }
    }
}