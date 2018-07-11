using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MVC_Homework.Models.InputValidations
{
    public class 手機Attribute : DataTypeAttribute
    {
        string pattern = @"\d{4}-\d{6}";

        public 手機Attribute() : base(DataType.Text)
        {
            ErrorMessage = "請輸入正確的手機號碼";
        }

        public override bool IsValid(object value)
        {
            string phoneNumber = (string)value; 

            return isIdentificationId(phoneNumber);
        }

        public bool isIdentificationId(string phoneNumber)
        {
            var res = false;

            if (phoneNumber.Length == 11)
            {
                RegexOptions opt = new RegexOptions();
                opt = RegexOptions.IgnoreCase | RegexOptions.Multiline;
                Regex reg;

                reg = new Regex(pattern, opt);

                res = reg.IsMatch(phoneNumber, 0);

            }

            return res;
        }
    }
}