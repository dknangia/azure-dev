using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Chapter02;

public class ProblemDetailsResultExecutor: IActionResultExecutor<ObjectResult>
{
    public Task ExecuteAsync(ActionContext context, ObjectResult result)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(result);

        var executor = Results.Json(result.Value, null, "application/problem+json", result.StatusCode);

        return executor.ExecuteAsync(context.HttpContext);
    }
}