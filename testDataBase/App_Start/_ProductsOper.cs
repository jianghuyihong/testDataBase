﻿using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace testDataBase.App_Start
{
    public class _ProductsOper
    {
        public _ProductsOper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        //插入商品
        public static void Insert(_ProductsInfo product)
        {

            string sql = "insert into product(productname,unitprice,categoryid) values(@productname,@unitprice,@categoryid)";

            OleDbConnection con = new DBConnection().Con;
            OleDbCommand com = new OleDbCommand();
            com = con.CreateCommand();
            com.CommandText = sql;
            //配参
            com.Parameters.Add(new OleDbParameter("@productname", product.Productname));
            com.Parameters.Add(new OleDbParameter("@unitprice", product.Unitprice));
            com.Parameters.Add(new OleDbParameter("@categoryid", product.Categoryid));
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        //查所有产品
        public static IList<_ProductsInfo> GetProductByCateid(int cateid)
        {
            string sql = "select ID,productname,unitprice,categoryid from product where categoryid=@cateid";
            IList<_ProductsInfo> products = new List<_ProductsInfo>();

            OleDbConnection con = new DBConnection().Con;
            OleDbCommand com = new OleDbCommand();
            com = con.CreateCommand();


            com.Parameters.Add(new OleDbParameter("@cateid", cateid));
            com.CommandText = sql;

            con.Open();

            OleDbDataReader oddr = com.ExecuteReader();
            while (oddr.Read())
            {
                _ProductsInfo product = new _ProductsInfo(oddr.GetInt32(0), oddr.GetString(1), oddr.GetString(2), oddr.GetInt32(3));
                products.Add(product);
            }
            con.Close();

            return products;
        }
        //根据productid删除
        public static void Delete(int productid)
        {
            string sql = "delete from 产品 where 产品ID=@productid";

            OleDbConnection con = new DBConnection().Con;
            OleDbCommand com = new OleDbCommand();

            com = con.CreateCommand();
            //配参
            com.Parameters.Add(new OleDbParameter("@productid", productid));

            com.CommandText = sql;
            con.Open();

            com.ExecuteNonQuery();
            con.Close();

        }

        ////根据productid更新数据
        public static void Update(_ProductsInfo prod)
        {

            string sql = "update product set productname=@productname,unitprice=@unitprice,categoryid=@categoryid "
                + " where ID=@productid";

            OleDbConnection con = new DBConnection().Con;
            OleDbCommand com = new OleDbCommand();

            com = con.CreateCommand();
            com.CommandText = sql;
            //配参
            com.Parameters.Add(new OleDbParameter("@productname", prod.Productname));
            com.Parameters.Add(new OleDbParameter("@unitprice", prod.Unitprice));
            com.Parameters.Add(new OleDbParameter("@categoryid", prod.Categoryid));
            com.Parameters.Add(new OleDbParameter("@productid", prod.Productid));
            con.Open();

            com.ExecuteNonQuery();
            con.Close();
        }

      
    }
}