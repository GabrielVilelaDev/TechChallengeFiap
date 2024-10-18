using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Persistance.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : BaseDbContext(options) { }
}
