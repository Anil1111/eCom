using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCom.Web.Helpers
{
    public static class eComURLHelper
    {
        public static string Categories(this UrlHelper helper, int? pageNo, int? items)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Categories", new
            {
                pageNo = pageNo,
                items = items
            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
    }
}