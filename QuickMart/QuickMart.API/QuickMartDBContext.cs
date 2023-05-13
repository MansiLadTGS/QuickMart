﻿using Microsoft.EntityFrameworkCore;

namespace QuickMart.Infrastructure
{
    public partial class QuickMartDBContext : DbContext
    {
        public QuickMartDBContext(DbContextOptions<QuickMartDBContext> dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}
