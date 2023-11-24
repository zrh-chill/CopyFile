using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fromIn
{
    public static class ObjectExtension
    {
        public static int ToInt(this object obj, int defaultValue = 0)
        {
            if (obj == null || obj.ToString() == "")
                return defaultValue;

            string str = obj.ToString().Trim();
            bool isPercent = str.EndsWith("%");
            if (isPercent)
                str = str.Substring(0, str.Length - 1);

            int result = defaultValue;
            int.TryParse(str, out result);

            if (isPercent)
                result = (int)(result / 100.0);

            return result;
        }
    }
}
