using EchartsWeb.SQL数据处理;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace EchartsWeb.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            //using (tab_ESD_MonitorDBEntities1 ent = new tab_ESD_MonitorDBEntities1())
            //{
            //    var list = (from de in ent.Devices
            //                    //join du in ent.Duties on users.DutiesID equals du.ID
            //                    //join dep in ent.DePartment on users.DepartmentID equals dep.ID
            //                select new
            //                {
            //                    de.D_ID,
            //                    de.D_Creadte_Time,
            //                    de.D_Line,
            //                    de.D_Monitor,
            //                    de.D_Name,
            //                    de.D_Adress,
            //                    de.D_Yieds,
            //                    de.D_Bednum,
            //                    de.D_Power_Time,
            //                    de.D_Power,
            //                    de.D_Computer_Name,
            //                    de.D_IP_adress,
            //                    de.D_MAC_adress,

            //                }).ToList();


            //    int total = list.Count();
            //    var newlist = list.Skip((page - 1) * rows).Take(rows).ToList();

            //    return Json(new { total = list.Count, rows = newlist });

            return View();
        }

        //[HttpPost]
        public ActionResult Indexs() {


            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=10.114.113.2,1433;Initial Catalog=tab_ESD_MonitorDB;Persist Security Info=True;User ID=sa;Password=";
            conn.Open();
            string sqlstr = "select MAX( D_Yieds) as D_Yieds ,D_Name ,MAx(D_Bednum) as D_Bednum from Device group by D_Name";
            SqlCommand com = new SqlCommand(sqlstr, conn);
            SqlDataAdapter da = new SqlDataAdapter(com);
            //SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Device> list = new List<Device>();

            //foreach (DataRow row in dt.Rows)
            //{
            //    Device dc = new Device();
            //    dc.D_ID = Convert.ToInt32(row["D_ID"].ToString());
            //    dc.D_Adress = row["D_Adress"].ToString();
            //    dc.D_Name = row["D_Name"].ToString();
            //    dc.D_Monitor = row["D_Monitor"].ToString();
            //    dc.D_Line = row["D_Line"].ToString();
            //    dc.D_Yieds = Convert.ToInt32(row["D_Yieds"].ToString());
            //    dc.D_Bednum = Convert.ToDouble(row["D_Bednum"].ToString());
            //    dc.D_Power_Time = Convert.ToDouble(row["D_Power_Time"].ToString());
            //    dc.D_Power = Convert.ToDouble(row["D_Power"].ToString());
            //    dc.D_IP_adress = row["D_IP_adress"].ToString();
            //    dc.D_Creadte_Time = row["D_Creadte_Time"].ToString();
            //    dc.D_Computer_Name = row["D_Computer_Name"].ToString();
            //    dc.D_MAC_adress = row["D_Computer_Name"].ToString();
            //    list.Add(dc);
            //}
            foreach (DataRow row in dt.Rows)
            {
                Device dc = new Device();
                dc.D_Name = row["D_Name"].ToString();
                dc.D_Yieds = Convert.ToInt32(row["D_Yieds"].ToString());
                dc.D_Bednum = Convert.ToInt32(row["D_Bednum"].ToString());
                list.Add(dc);
            }


            int total = list.Count();
            //var newlist = list.Skip((page - 1) * rows).Take(rows).ToList();

            return Json(new { total = list.Count, rows = list });



        }




        




        public ActionResult CarterEarth()
        {

            return View();


        }
        public ActionResult Earth()
        {

            return View();


        }

        public class Device
        {
            public int D_ID;
            public string D_Creadte_Time;
            public string D_Line;
            public string D_Monitor;
            public string D_Name;
            public string D_Adress;
            public int D_Yieds;
            public double D_Bednum;
            public double D_Power_Time;
            public double D_Power;
            public string D_Computer_Name;
            public string D_IP_adress;
            public string D_MAC_adress;




        }

        public ActionResult TableShow() {




            return View();

        }

        public ActionResult serial() {
            SerialPort sp = new SerialPort();
            string [] port = SerialPort.GetPortNames();
            sp.PortName = port[0];
            sp.BaudRate = 9600;
            sp.StopBits = StopBits.One;
            sp.Handshake = Handshake.None;
            sp.DataBits = 8;
            sp.ReadTimeout = 100;
            sp.WriteTimeout = 100;
            byte[] buff= { 1,2} ;
            
            sp.Write(buff,8,buff.Length);
            byte[] buffRead= { };
            sp.Read(buffRead,8,buffRead.Length);

            return View();

        }



        public ActionResult Fix() {

            return View();


        }

        public ActionResult bar() {


           return View();
        }

        public ActionResult tiaoxingandzhexian() {


            return View();

        }


        public ActionResult barfenpage()
        {


            return View();

        }


        public ActionResult CPU() {

            return View();

        }
        public ActionResult bootstarp() {
            return View();
        }

        List<Device> list = new List<Device>();

        public ActionResult bootstarp1( int limit,int page,string name) {
            string sqlstr = " select* from Device where 1 = 1";
            if (name!=string.Empty && name!=null)
            {
                sqlstr +=string.Format( "and  D_Name ='{0}'",name);
            }

            DataTable dt = new DataTable();
            dt = SQLClass.GetTable(sqlstr);
            foreach (DataRow row in dt.Rows)
            {
                Device dc = new Device();
                dc.D_ID = Convert.ToInt32(row["D_ID"].ToString());
                dc.D_Adress = row["D_Adress"].ToString();
                dc.D_Name = row["D_Name"].ToString();
                dc.D_Monitor = row["D_Monitor"].ToString();
                dc.D_Line = row["D_Line"].ToString();
                dc.D_Yieds = Convert.ToInt32(row["D_Yieds"].ToString());
                dc.D_Bednum = Convert.ToDouble(row["D_Bednum"].ToString());
                dc.D_Power_Time = Convert.ToDouble(row["D_Power_Time"].ToString());
                dc.D_Power = Convert.ToDouble(row["D_Power"].ToString());
                dc.D_IP_adress = row["D_IP_adress"].ToString();
                dc.D_Creadte_Time = row["D_Creadte_Time"].ToString();
                dc.D_Computer_Name = row["D_Computer_Name"].ToString();
                dc.D_MAC_adress = row["D_MAC_adress"].ToString();

                list.Add(dc);
            }
           var newlist = list.Skip((page - 1) * limit).Take(limit).ToList();

            return Json(new { total =list.Count, rows = newlist });
         
        }
        /// <summary>
        /// 导出
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Export()
        {
            var lstModel = list;
            var dic = new Dictionary<string, string>();
            dic["VIN"] = "VIN码";
            dic["FILL_TIME"] = "加注时间";
            dic["FILL_NUM"] = "加入量";
            dic["FILL_PRESS"] = "加注压力";
            dic["FILL_LONG"] = "加注时长";
            dic["VACUUM"] = "真空度";
            dic["RESULT"] = "OK/NG";
            dic["FAULT"] = "故障代码";
            dic["DEVICE_NO"] = "设备编号";
            dic["FILL_TYPE"] = "加注类型";

            var file_name = "加注机";
            var file_path = "";//export_bll.Export(lstModel, dic, ref file_name);
            //输出到浏览器
            try
            {
                var stream = new FileStream(file_path, FileMode.Open);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StreamContent(stream);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = file_name
                };

                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
        }




        public ActionResult Gauge() {

            return View();


        }

    }
}