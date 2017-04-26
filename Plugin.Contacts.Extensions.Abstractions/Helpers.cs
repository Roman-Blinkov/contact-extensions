using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Contacts.Extensions.Abstractions
{
    public static class Helpers
    {
        public static bool IsBadFormat(this string argument)
        {
            return string.IsNullOrEmpty(argument) || string.IsNullOrWhiteSpace(argument);
        }
    }
}
