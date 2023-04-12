using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CPUBattleApp.Decorators
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class GemNameAttribute : ValidationAttribute
    {
        // All the valid gem types for this attribute, should be all lowercase
        public string GemTypes { get; set; }

        public override bool IsValid(object value)
        {
            if (value == null || !GemTypes.Contains(((string)value).ToLower()))
            {
                return false;

            }
            return true;
        }
    }
}
