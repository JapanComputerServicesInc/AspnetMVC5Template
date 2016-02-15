using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Template.Models
{
    public class CustomRequiredAttribute : RequiredAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "";
        }
    }
}