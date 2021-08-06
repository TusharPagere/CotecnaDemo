using Demo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Application.Common.Interfaces
{
    public interface IOIGDbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Demo.Entities.ServiceRequest> ServiceRequest { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
