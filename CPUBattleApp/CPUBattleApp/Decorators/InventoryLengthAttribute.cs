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
        // Length for the inventory (want player to choose 2 items, no more and no less)
        public int Length { get; set; }

        public override bool IsValid(object value)
        {
            if (value == null || value.GetType() != typeof(List<IItem>) || ((List<IItem>)value).Count() != Length)
            {
                return false;

            }
            return true;
        }
    }   
}
