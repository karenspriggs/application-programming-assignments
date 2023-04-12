using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CPUBattleApp.Decorators
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class UniformColorAttribute : ValidationAttribute
    {
        // All the valid colors for this attribute, should be all lowercase
        // This is a string and not a list because you cannot use a list of strings as an attribute type
        public string UniformColors { get; set; }

        public override bool IsValid(object value)
        {
            if (value == null || !UniformColors.Contains(((string)value).ToLower()))
            {
                return false;

            }
            return true;
        }
    }
}
