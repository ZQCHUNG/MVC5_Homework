using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC_Homework.Models
{   
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{

        public IQueryable<客戶銀行資訊> All()
        {
            return base.All().Where(o => o.是否已刪除 != true);
        }

        public IQueryable<客戶銀行資訊> Find(string Keyword)
        {
            var 客戶銀行資訊 = this.All();

            if (!string.IsNullOrEmpty(Keyword))
            {
                客戶銀行資訊 = 客戶銀行資訊.Where(o => o.銀行名稱 == Keyword);
            }

            return 客戶銀行資訊;
        }

        public 客戶銀行資訊 Find(int id)
        {
            return this.All().FirstOrDefault(o => o.Id == id);
        }
    }

	public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}