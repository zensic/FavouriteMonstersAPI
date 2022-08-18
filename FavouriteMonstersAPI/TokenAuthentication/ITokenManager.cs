namespace FavouriteMonstersAPI.TokenAuthentication
{
  public interface ITokenManager
  {
    bool Authenticate(string userName, string password);
    Task<Token> NewToken();
    bool VerifyToken(string token);
  }
}