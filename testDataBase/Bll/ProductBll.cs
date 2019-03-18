using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using testDataBase.App_Start;
using testDataBase.Models;

namespace testDataBase.Bll
{
    public class ProductBll
    {
        /// <summary>
        /// 新增产品
        /// </summary>
        /// <param name="productname"></param>
        /// <param name="unitprice"></param>
        /// <param name="ID"></param>
        /// <param name="categoryid"></param>
        /// <returns></returns>
        public bool insert(Products products)
        {
            
            string sql = "insert into product(productname,unitprice,categoryid,createtime) values(@productname,@unitprice,@categoryid,@createtime)";
            bool _bool = false;
            try
            {
                OleDbConnection con = new DBConnection().Con;
                OleDbCommand com = new OleDbCommand();
                com = con.CreateCommand();
                com.CommandText = sql;
                //配参
                com.Parameters.Add(new OleDbParameter("@productname", products.productName));
                com.Parameters.Add(new OleDbParameter("@unitprice", products.unitPrice));
                com.Parameters.Add(new OleDbParameter("@categoryid", products.categoryId));
                com.Parameters.Add(new OleDbParameter("@createtime", products.createTime));
                con.Open();
                _bool = com.ExecuteNonQuery()>0;
                con.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return _bool;
        }
    }
}