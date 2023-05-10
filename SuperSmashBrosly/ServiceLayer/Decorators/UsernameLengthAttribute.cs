using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Decorators
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class UsernameLengthAttribute : ValidationAttribute
    {
        public int MaxLength { get; set; }
        public int MinLength { get; set; }

        public override bool IsValid(object value)
        {
            if (value == null || ((string)value).Length > MaxLength || ((string)value).Length < MinLength)
            {
                return false;

            }
            return true;
        }
    }
}
