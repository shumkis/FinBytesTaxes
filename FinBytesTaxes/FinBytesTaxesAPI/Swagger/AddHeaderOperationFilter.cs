using FinBytesTaxesAPI.Constants;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FinBytesTaxesAPI.Swagger
{
    public class AddHeaderOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= [];

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = Const.RoleHeaderName,
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new Microsoft.OpenApi.Any.OpenApiString("user")
                },
            });
        }
    }
}
