using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using ProMVCCh1.Models;

namespace ProMVCCh1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index()
        {
            DataTable dt = getDT();
            getAE(dt);
            //ViewBag.Greeting = dt.Rows[0]["name"].ToString();
            ViewBag.Greeting = dt;
            return View();
        }

        DataTable getDT()
        {
            string cnStr = "user id=user00; password=Pa$$w0rd; data source=ncryzxvg04.database.windows.net; initial catalog=jmhtestANcq7Btzo";
            using (SqlConnection cn = new SqlConnection(cnStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from family", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
        }

        void getAE(DataTable dt)
        {
            var  f = dt.AsEnumerable().Select(family => new {ID=family.Field<int>("Id"),Name=family.Field<string>("Name") });
            //List<Family> ff = f.Cast<Family>().ToList();
        }
    }
}