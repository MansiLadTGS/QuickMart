using Microsoft.EntityFrameworkCore;

namespace QuickMart.API
{
    public partial class QuickMartDBContext : DbContext
    {
        public QuickMartDBContext(DbContextOptions<QuickMartDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}
