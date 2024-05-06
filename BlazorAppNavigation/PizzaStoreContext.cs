using Microsoft.EntityFrameworkCore;

namespace BlazorAppNavigation;

public class PizzaStoreContext : DbContext
{
  public PizzaStoreContext(DbContextOptions options) : base(options)
  {
  }

  public DbSet<PizzaSpecial> Specials { get; set; }
}
