using FinBytesTaxesAPI.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FinBytesTaxesAPI.Attributes
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RequireRoleHeaderAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string? _expectedValue;

        public RequireRoleHeaderAttribute(string? expectedValue = null)
        {
            _expectedValue = expectedValue;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(Const.RoleHeaderName, out var actualValue) ||
                string.IsNullOrWhiteSpace(actualValue))
            {
                context.Result = new ContentResult
                {
                    StatusCode = 403,
                    Content = $"Access denied: missing or empty {Const.RoleHeaderName} header."
                };
                return;
            }

            if (_expectedValue != null &&
                !string.Equals(actualValue, _expectedValue, StringComparison.OrdinalIgnoreCase))
            {
                context.Result = new ContentResult
                {
                    StatusCode = 403,
                    Content = $"Access denied: {Const.RoleHeaderName} must be '{_expectedValue}'."
                };
            }
        }
    }

}
