using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForm1.Helper
{
    public class RootApi
    {
        public static string BaseAddress = "http://localhost";

        public static string ItemsUrl = BaseAddress + "/apidemo1/api/{0}/{1}";
        public static string ItemsUrl2 = BaseAddress + "/apidemo1/api/{0}/{1}/{2}";

    }
}