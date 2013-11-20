using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raymond.Croe.Helper
{
    public class ExceptionHelper
    {
        public static  bool NullIf(object nullable, string message)
        {
            if (null == nullable)
            {
                if(string.IsNullOrEmpty(message))
                {
                    message = "对象不能为空！";
                }
                throw new Exception(message);
            }
            return true;
        }

        public static bool NullIf(object obj)
        {
            return NullIf(obj,"");
        }

    }
}
