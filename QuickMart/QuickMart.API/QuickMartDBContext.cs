using Microsoft.EntityFrameworkCore;

namespace QuickMart.API
{
    public partial class QuickMartDBContext : DbContext
    {
        public QuickMartDBContext(DbContextOptions<QuickMartDBContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
