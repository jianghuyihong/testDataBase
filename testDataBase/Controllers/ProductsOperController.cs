using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using testDataBase.App_Start;
using testDataBase.Bll;
using testDataBase.Models;

namespace testDataBase.Controllers
{
    public class ProductsOperController : Controller
    {
        // GET: ProductsOper
        //public ActionResult Index()
        //{
        //    return View();
        //}
        //查所有产品
        ProductBll bll = new ProductBll();
        public JsonResult GetProductByCateid(int cateid)
        {
            string sql = "select ID,productname,unitprice,categoryid from product where categoryid=@cateid";
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
                ProductsInfo product = new ProductsInfo(oddr.GetInt32(0), oddr.GetString(1), oddr.GetString(2), oddr.GetInt32(3));
                products.Add(product);
            }
            con.Close();
            JavaScriptSerializer servializer = new JavaScriptSerializer();
            string strJson = servializer.Serialize(products);
            //return Content(strJson);
            var json = new { Success = true, Data = products };//true 布尔型 好想不行，直接变成字符串。
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult insert(Products products)
        {

            bool _bool = bll.insert(products);
            string msg = _bool ? "添加成功" : "添加失败";

            return Json(new { Success=_bool,msg=msg},JsonRequestBehavior.AllowGet);
        }
    }
}