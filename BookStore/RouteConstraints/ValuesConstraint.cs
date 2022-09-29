namespace BookStore.RouteConstraints
{
    public class ValuesConstraint : IRouteConstraint
    {
        private readonly string[] validOptions;

        public ValuesConstraint(string options) // construtor recebe uma lista de opções validas
        {
            validOptions = options.Split('|');
        }

        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            object value;

            if (values.TryGetValue(routeKey, out value) && value != null)
            {
                return validOptions.Contains(value.ToString(), StringComparer.OrdinalIgnoreCase);
            }
            return false;
        }
    }
}
