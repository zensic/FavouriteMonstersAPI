using System.ComponentModel.DataAnnotations;

namespace FavouriteMonstersAPI.TokenAuthentication
{
  public class Token
  {
    [Key]
    public string Value { get; set; }
    public DateTime ExpiryDate { get; set; }
  }
}
