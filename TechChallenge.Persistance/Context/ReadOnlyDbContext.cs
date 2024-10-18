using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Persistance.Context
{
    public class ReadOnlyDbContext : BaseDbContext
    {
        public ReadOnlyDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}
