
namespace GringottsDatabase.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property)]
     class TagAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string strigifiedValue = value as string;
            if (!strigifiedValue.StartsWith("#"))
            {
                return false;
            }
            if (strigifiedValue.Length > 20)
            {
                return false;
            }
            if (strigifiedValue.Contains(" ") || strigifiedValue.Contains("   "))
            {
                return false;
            }



            return true;
            // return base.IsValid(value);
        }
    }
}
