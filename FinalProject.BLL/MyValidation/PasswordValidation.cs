using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.MyValidation
{
    public class PasswordValidation:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string str = value.ToString();
            bool UpperFlage = false;
            bool LowerFlage = false;
            bool SpecialFlage = false;
            bool NumberFlage = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsDigit(str[i]))
                {
                    NumberFlage = true;
                }
                else if (Char.IsLower(str[i]))
                {
                    LowerFlage = true;
                }
                else if (Char.IsUpper(str[i]))
                {
                    UpperFlage = true;
                }
                else SpecialFlage = true;
            }

            return LowerFlage && UpperFlage && NumberFlage && SpecialFlage;
        }
    }
}