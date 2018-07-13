using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC_Homework.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public IQueryable<客戶資料> All()
        {
            return base.All().Where(o => o.是否已刪除 != true);
        }

        public IQueryable<客戶資料> Find(string Keyword)
        {
            var 客戶資料 = this.All();

            if (!string.IsNullOrEmpty(Keyword))
            {
                客戶資料 = 客戶資料.Where(o => o.客戶名稱 == Keyword);
            }

            return 客戶資料;
        }

        public 客戶資料 Find(int id)
        {
            return this.All().FirstOrDefault(o => o.Id == id);
        }

        public IQueryable<客戶資料> Find(IQueryable<客戶資料> 客戶資料Items, string 客戶分類)
        {
            if (!string.IsNullOrEmpty(客戶分類))
            {
                switch (客戶分類)
                {
                    case "天龍人":
                        客戶資料Items = 客戶資料Items.Where(o => o.地址.Contains("台北"));
                        break;
                    case "南部人":
                        客戶資料Items = 客戶資料Items.Where(o => !o.地址.Contains("台北"));
                        break;
                }
            }

            return 客戶資料Items;
        }
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}