using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Persistant
{
    public class OIGDbContextFactory : DesignTimeDbContextFactoryBase<OIGDbContext>
    {
        protected override OIGDbContext CreateNewInstance(DbContextOptions<OIGDbContext> options)
        {
            return new OIGDbContext(options);
        }
    }
}
