using MVC_Homework.Models;
using MVC_Homework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Homework.Controllers
{
    public class 客戶基本資訊Controller : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();
        
        // GET: 客戶基本資訊
        public ActionResult Index()
        {
            List<客戶基本資訊DetailViewModel> DetailViewModel = new List<客戶基本資訊DetailViewModel>();

            var 客戶資料 = db.客戶資料.Where(o => o.是否已刪除 != true).ToList();

            foreach (var obj in 客戶資料)
            {
                客戶基本資訊DetailViewModel tmpViewModel = new 客戶基本資訊DetailViewModel();

                //聯絡人數量
                var 聯絡人數量 = db.客戶聯絡人.Count(o => o.客戶Id == obj.Id && o.是否已刪除 != true);

                //銀行帳戶數量
                var 銀行帳戶數量 = db.客戶銀行資訊.Count(o => o.客戶Id == obj.Id && o.是否已刪除 != true);

                tmpViewModel.客戶名稱 = obj.客戶名稱;
                tmpViewModel.聯絡人數量 = 聯絡人數量;
                tmpViewModel.銀行帳戶數量 = 銀行帳戶數量;

                DetailViewModel.Add(tmpViewModel);
            }

            return View(DetailViewModel);
        }

        public ActionResult Detail()
        {
            return View();
        }
    }
}