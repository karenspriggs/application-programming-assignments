using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CPUBattleApp.Items;

namespace CPUBattleApp.Decorators
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class InventoryLengthAttribute : ValidationAttribute
    {
        // Max length for the inventory
        public int MaxLength { get; set; }

        public override bool IsValid(object value)
        {
            if (value == null || value.GetType() != typeof(List<IItem>) || ((List<IItem>)value).Count() > MaxLength)
            {
                return false;

            }
            return true;
        }
    }   
}
