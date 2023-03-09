using System.Web;
using System.Web.Mvc;

namespace _2080600068_TranDuyAnh_BigSchool
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
