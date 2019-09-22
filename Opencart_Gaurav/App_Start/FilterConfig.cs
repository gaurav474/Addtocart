using System.Web;
using System.Web.Mvc;

namespace Opencart_Gaurav
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
