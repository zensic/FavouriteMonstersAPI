using FavouriteMonstersAPI.TokenAuthentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FavouriteMonstersAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthenticateController : ControllerBase
  {
    private readonly ITokenManager tokenManager;

    public AuthenticateController(ITokenManager tokenManager)
    {
      this.tokenManager = tokenManager;
    }

    // Returns token if authentication is successful
    public IActionResult Authenticate(string user, string pwd)
    {
      if (tokenManager.Authenticate(user, pwd))
      {
        return Ok(new { Token = tokenManager.Authenticate(user, pwd) });
      }
      else
      {
        ModelState.AddModelError("Unauthorized", "You are not unauthorized.");
        return Unauthorized(ModelState);
      }
    }
  }
}
