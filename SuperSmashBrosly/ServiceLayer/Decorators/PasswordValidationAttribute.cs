using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ServiceLayer.Decorators
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PasswordValidationAttribute : ValidationAttribute
    {
        public int MinLength { get; set; }

        //Referenced from: https://stackoverflow.com/questions/34715501/validating-password-using-regex-c-sharp
        public override bool IsValid(object value)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");

            if (value == null || ((string)value).Length < MinLength || !hasNumber.IsMatch((string)value) || !hasUpperChar.IsMatch((string)value))
            {
                return false;
            }
            return true;
        }
    }
}
