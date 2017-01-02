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
    class DigitAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string digitString = (string) value;
            string regexDigitString=@"/[0-9]+\.[0-9]{1}/";
            Regex regex = new Regex(regexDigitString);

            if (!regex.IsMatch(digitString))
            {
                return false;

            }



            return true;
        }
    }
}
