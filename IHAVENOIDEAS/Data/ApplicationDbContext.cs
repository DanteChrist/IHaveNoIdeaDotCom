using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IHAVENOIDEAS.Data;

namespace IHAVENOIDEAS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<IHAVENOIDEAS.Data.ArtIdea>? ArtIdea { get; set; }
    }
}