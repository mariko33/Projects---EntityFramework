using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Photography.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class PhoneAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string phoneString = (string) value;
            string regExpressionString = @"(/\+\[0-9]{1,3}\/[0-9]{8,10}/)";
            Regex regex=new Regex(regExpressionString);
            if (!regex.IsMatch(phoneString))
            {
                return false;

            }

            return true;
        }
    }
}
