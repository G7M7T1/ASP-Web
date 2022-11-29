using System.Text.RegularExpressions;

namespace Web4_Routing.CustomConstraints
{
    // sales-report/2023/jan
    public class MonthsCustomConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            // check value exists
            if (!values.ContainsKey(routeKey)) // month
            {
                return false; // not match
            }

            Regex regex = new Regex("^(apr|jul|oct|jan)$");

            string? monthValue = Convert.ToString(values[routeKey]);

            if (regex.IsMatch(monthValue))
            {
                return true;
            }

            return false;
        }
    }
}
