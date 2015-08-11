using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImdbWeb.Utilities
{
    public static class Extensions
    {
        public static string Left(this string s, int length, string endPadding = "")
        {
            if(s.Length <= length-endPadding.Length)
            {
                return s.Substring(0, s.Length);
            }
            else
            {
                return s.Substring(0, length-endPadding.Length) + endPadding;
            }
        }
    }
}