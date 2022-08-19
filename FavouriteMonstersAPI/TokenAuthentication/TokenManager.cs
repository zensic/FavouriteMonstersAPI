using FavouriteMonstersAPI.Data;

namespace FavouriteMonstersAPI.TokenAuthentication
{
  public class TokenManager : ITokenManager
  {
    private readonly MonstersDbContext _context;

    public TokenManager(MonstersDbContext context)
    {
      _context = context;
    }

    // Takes in username and password
    // Checks database if username exists + matching password
    public bool Authenticate(string userName, string password)
    {
      // In this case login is already handled in MVC app connecting directly to database
      // As a temporary measure, this always allows the user to generate a new token
      if (userName != null && password != null)
        return true;

      return false;
    }

    // Generates a new token to be stored in db
    public async Task<Token> NewToken()
    {
      var token = new Token()
      {
        Value = Guid.NewGuid().ToString(),
        ExpiryDate = DateTime.Now.AddMinutes(15),
      };

      await _context.Tokens.AddAsync(token);
      await _context.SaveChangesAsync();

      return token;
    }

    // Check if token exists, return true if exists
    public bool VerifyToken(string token)
    {
      // Check if token exists and has not expired
      //if (_context.Tokens.Any(x => x.Value == token && x.ExpiryDate > DateTime.Now))
      //{
      //  return true;
      //}

      if (_context.Tokens.Any(x => x.Value == token))
      {
        return true;
      }

      return false;
    }
  }
}
