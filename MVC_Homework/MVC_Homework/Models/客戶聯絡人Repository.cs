using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC_Homework.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
        public IQueryable<客戶聯絡人> All()
        {
            return base.All().Where(o => o.是否已刪除 != true);
        }

        public IQueryable<客戶聯絡人> Find(string Keyword)
        {
            var 客戶聯絡人 = this.All();

            if (!string.IsNullOrEmpty(Keyword))
            {
                客戶聯絡人 = 客戶聯絡人.Where(o => o.姓名 == Keyword);
            }

            return 客戶聯絡人;
        }

        public IQueryable<客戶聯絡人> Find(string Keyword,string 職稱群組)
        {
            var 客戶聯絡人 = this.All();

            if (!string.IsNullOrEmpty(Keyword))
            {
                客戶聯絡人 = 客戶聯絡人.Where(o => o.姓名 == Keyword);
            }

            if (!string.IsNullOrEmpty(Keyword))
            {
                客戶聯絡人 = 客戶聯絡人.Where(o => o.職稱 == 職稱群組);
            }

            return 客戶聯絡人;
        }

        public 客戶聯絡人 Find(int id)
        {
            return this.All().FirstOrDefault(o => o.Id == id);
        }

        public Dictionary<string, List<客戶聯絡人>> Get職稱群組()
        {
            var 客戶聯絡人 = this.All();

            var res = 客戶聯絡人.GroupBy(o => o.職稱).ToDictionary(o => o.Key, o => o.ToList());

            return res;
        }

        public override void Delete(客戶聯絡人 entity)
        {
            entity.是否已刪除 = true;
        }
    }

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}