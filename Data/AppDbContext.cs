using Microsoft.EntityFrameworkCore;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}