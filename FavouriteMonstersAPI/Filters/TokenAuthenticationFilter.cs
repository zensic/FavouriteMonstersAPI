using FavouriteMonstersAPI.TokenAuthentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FavouriteMonstersAPI.Filters
{
  public class TokenAuthenticationFilter : Attribute, IAuthorizationFilter
  {
    public void OnAuthorization(AuthorizationFilterContext context)
    {
      // Grab token manager from context
      var tokenManager = (ITokenManager)context.HttpContext.RequestServices.GetService(typeof(ITokenManager));

      var result = true;

      // Check whether the header has authorization key
      if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
        result = false;

      string token = string.Empty;
      if (result)
      {
        // Obtain the value from the authorization key
        token = context.HttpContext.Request.Headers.First(x => x.Key == "Authorization").Value;
        // Verify the token
        if (tokenManager.VerifyToken(token))
          result = false;
      }

      if (!result)
      {
        context.ModelState.AddModelError("Unauthorized", "You are not auythorized.");
        context.Result = new UnauthorizedObjectResult(context.ModelState);
      }
    }
  }
}
