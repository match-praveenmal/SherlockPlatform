using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherlockPlatform
{
    public static class Extensions
    {
        internal static int roundupbyten(this int i)
        {  
            return (int)(Math.Ceiling(i / 10.0d) * 10);  
        }

        internal static String saltedString(this String s)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(s);
            sb = sb.Insert(3, Convert.ToString(DateTimeOffset.UtcNow.Minute.roundupbyten()));
            sb = sb.Insert(6, Convert.ToString(DateTimeOffset.UtcNow.Minute.roundupbyten() - 10));
            return sb.ToString();
        }
    }

}
