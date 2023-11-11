using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class Extensions
    {
        public static string GetDirectoryPath(this string text)
        {
            return Path.GetDirectoryName(text)!;
        }
    }
}
