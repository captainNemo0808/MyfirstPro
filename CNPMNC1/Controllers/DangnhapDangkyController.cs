using CNPMNC1.Models;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FireSharp.Config;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Data.Entity;
using Firebase.Auth;
using System.Net;
using System.Net.Mail;


namespace CNPMNC1.Controllers
{
    public class DangnhapDangkyController : Controller
    {
        IFirebaseConfig config = new FireSharp.Config.FirebaseConfig
        {
            AuthSecret = "uhhaykO6PxwhS9VIaTTPYIPWWGnyBnXuINuzRmPO",
            BasePath = "https://congnghephanmennangcao-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        // GET: DangnhapDangky
        [HttpGet]
        public ActionResult Dangky()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangky(TaiKhoan taikhoan)
        {
            try
            {
                taikhoan.thanhvien = "chưa là thành viên";
                AddStudentToFirebase(taikhoan);
                return RedirectToAction("Dangnhap");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View();
        }
        public ActionResult Dangxuat()
        {
            Session.Clear();
            return RedirectToAction("Index2","SanPham");
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(TaiKhoan taiKhoan)
        {
            if ("admin@gmail.com" == taiKhoan.email && "admin123456" == taiKhoan.pass)
            {
                Session["PasswordUser"] = taiKhoan.pass;
                Session["Email"] = "admin@gmail.com";
                return RedirectToAction("Index", "SanPham");
            }
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("TaiKhoan/");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<TaiKhoan>();
            foreach (var item in data)
            {
                list.Add(JsonConvert.DeserializeObject<TaiKhoan>(((JProperty)item).Value.ToString()));
            }
            foreach (var items in list)
            {
                if (items.email == taiKhoan.email && items.pass == taiKhoan.pass)
                {
                    Session["ID"] = items.id;
                    return RedirectToAction("Index2", "SanPham");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("TaiKhoan/" + id);
            TaiKhoan data = JsonConvert.DeserializeObject<TaiKhoan>(response.Body);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(TaiKhoan taikhoan)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Set("TaiKhoan/" + taikhoan.id, taikhoan);
            TaiKhoan data = JsonConvert.DeserializeObject<TaiKhoan>(response.Body);
            return RedirectToAction("Index2","SanPham");
        }
        public ActionResult Index()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("TaiKhoan/");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<TaiKhoan>();
            foreach (var item in data)
            {
                list.Add(JsonConvert.DeserializeObject<TaiKhoan>(((JProperty)item).Value.ToString()));
            }
            return View(list);
        }
        public ActionResult Index2(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("TaiKhoan/" + id);
            TaiKhoan data = JsonConvert.DeserializeObject<TaiKhoan>(response.Body);
            return View(data);
        }
        [HttpGet]
        public ActionResult Edit2(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("TaiKhoan/" + id);
            TaiKhoan data = JsonConvert.DeserializeObject<TaiKhoan>(response.Body);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit2(TaiKhoan taikhoan)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Set("TaiKhoan/" + taikhoan.id, taikhoan);
            TaiKhoan data = JsonConvert.DeserializeObject<TaiKhoan>(response.Body);
            return RedirectToAction("Index", "SanPham");
        }
        private void AddStudentToFirebase(TaiKhoan taikhoan)
        {
            client = new FireSharp.FirebaseClient(config);
            var data = taikhoan;
            PushResponse response = client.Push("TaiKhoan/", data);
            data.id = response.Result.name;
            SetResponse setResponse = client.Set("TaiKhoan/" + data.id, data);
        }
    }
}