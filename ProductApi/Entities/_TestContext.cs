using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Contexts
{
    public class _TestContext : DbContext
    {
        // constructor to setup the db context
        public _TestContext(DbContextOptions<_TestContext> options) : base(options)
        { }
        // corresponds to table in db
        public DbSet<Product> Products => Set<Product>();
    }
}
