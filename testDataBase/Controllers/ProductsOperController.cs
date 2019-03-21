using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;
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
            string sql = "select ID,productname,unitprice,categoryid,createtime,modifytime from product where categoryid=@cateid";
            IList<Products> products = new List<Products>();

            OleDbConnection con = new DBConnection().Con;
            OleDbCommand com = new OleDbCommand();
            com = con.CreateCommand();


            com.Parameters.Add(new OleDbParameter("@cateid", cateid));
            com.CommandText = sql;

            con.Open();

            OleDbDataReader oddr = com.ExecuteReader();
            while (oddr.Read())
            {
                Products product = new Products(oddr.GetInt32(0), oddr.GetString(1), oddr.GetString(2), oddr.GetString(3), oddr.GetString(4), oddr.GetString(5));
                products.Add(product);
            }
            con.Close();
            JavaScriptSerializer servializer = new JavaScriptSerializer();
            string strJson = servializer.Serialize(products);
            //return Content(strJson);
            var json = new { Success = true, Data = products };//true 布尔型 好想不行，直接变成字符串。
            return Json(json, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult insert(Products products)
        {

            bool _bool = bll.insert(products);
            string msg = _bool ? "添加成功" : "添加失败";

            return Json(new { Success=_bool,msg=msg},JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// 修改记录
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult modify(Products products)
        {

            bool _bool = bll.insert(products);
            string msg = _bool ? "修改成功" : "修改失败";

            return Json(new { Success = _bool, msg = msg }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Delete(int productid)
        {
            string sql = "delete from product where ID=@productid";

            OleDbConnection con = new DBConnection().Con;
            OleDbCommand com = new OleDbCommand();

            com = con.CreateCommand();
            //配参
            com.Parameters.Add(new OleDbParameter("@productid", productid));

            com.CommandText = sql;
            con.Open();

            com.ExecuteNonQuery();
            con.Close();

            return Json(new { Success = true, msg = "删除成功" }, JsonRequestBehavior.AllowGet);
        }




        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Upload(FormCollection form)
        {
            bool _bool = false;  //是否上传
            if (Request.Files.Count == 0)
            {
                //Request.Files.Count 文件数为0上传不成功
                return View();
            }
            var file = Request.Files[0];
            if (file.ContentLength == 0)
            {
                //文件大小大（以字节为单位）为0时，做一些操作
                _bool = false;
            }
            else
            {
                //文件大小不为0
                file = Request.Files[0];
                //保存成自己的文件全路径,newfile就是你上传后保存的文件,
                //服务器上的UpLoadFile文件夹必须有读写权限
                string target = Server.MapPath("/") + ("/UploadFiles/");//取得目标文件夹的路径
                //title = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + file.FileName;
                string filename = file.FileName;//取得文件名字
                string path = target + filename;//获取存储的目标地址
                file.SaveAs(path);
                _bool = true;
            }
            string msg = _bool ? "上传成功" : "添加失败,请最少上传一个文件!";

            return Json(new { Success = _bool, msg = msg }, JsonRequestBehavior.AllowGet);
        }
    }
}