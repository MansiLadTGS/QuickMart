using Microsoft.EntityFrameworkCore;
using QuickMart.Core.Models;

namespace QuickMart.Infrastructure
{
    public partial class QuickMartDBContext : DbContext
    {
        public QuickMartDBContext(DbContextOptions<QuickMartDBContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<ProductMaster> Products { get; set; }
    }
}
