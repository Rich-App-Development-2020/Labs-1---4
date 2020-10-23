using System.Web;
using System.Web.Mvc;

namespace RAD3012021Week4.MVCClub
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
