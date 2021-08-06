using Demo.Application.Common.Interfaces;
using Demo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Persistant
{
    public class OIGDbContext : DbContext, IOIGDbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public OIGDbContext(DbContextOptions<OIGDbContext> options) : base(options)
        {
        }

        public OIGDbContext(DbContextOptions<OIGDbContext> options, ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
           
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<ServiceRequest> ServiceRequest { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        //entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.CreatedDate = DateTime.Now;  //_dateTime.Now;
                        entry.Entity.ModifiedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        // entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.ModifiedDate = DateTime.Now; // _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OIGDbContext).Assembly);

        }
    }
}
