using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace testDataBase.App_Start
{
    public class ProductsOper
    {
        public ProductsOper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        //插入商品
        public static void Insert(ProductsInfo product)
        {
            string sql = "insert into 产品(产品名称,单价,类别ID) values(@productname,@unitprice,@categoryid)";

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
        public static IList<ProductsInfo> GetProductByCateid(int cateid)
        {
            string sql = "select 产品ID,产品名称,单价,类别ID from 产品 where 类别ID=@cateid";
            IList<ProductsInfo> products = new List<ProductsInfo>();

            OleDbConnection con = new DBConnection().Con;
            OleDbCommand com = new OleDbCommand();
            com = con.CreateCommand();


            com.Parameters.Add(new OleDbParameter("@cateid", cateid));
            com.CommandText = sql;

            con.Open();

            OleDbDataReader oddr = com.ExecuteReader();
            while (oddr.Read())
            {
                ProductsInfo product = new ProductsInfo(oddr.GetInt32(0), oddr.GetString(1), oddr.GetDecimal(2), oddr.GetInt32(3));
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
        public static void Update(ProductsInfo prod)
        {

            string sql = "update 产品 set 产品名称=@productname,单价=@unitprice,类别ID=@categoryid "
                + " where 产品ID=@productid";

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