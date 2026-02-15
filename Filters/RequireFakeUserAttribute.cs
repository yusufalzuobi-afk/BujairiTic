using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class RequireFakeUserAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var fakeUser = context.HttpContext.Session.GetString("FAKE_USER");

        if (string.IsNullOrEmpty(fakeUser))
        {
            var returnUrl = context.HttpContext.Request.Path;
            context.Result = new RedirectToActionResult(
                "Login",
                "Account",
                new { returnUrl }
            );
        }
    }
}
