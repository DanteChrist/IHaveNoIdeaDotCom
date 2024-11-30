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
        public DbSet<IHAVENOIDEAS.Data.FashionIdea>? FashionIdea { get; set; }
        public DbSet<IHAVENOIDEAS.Data.PresentationIdea>? PresentationIdea { get; set; }
        public DbSet<IHAVENOIDEAS.Data.CodeIdea>? CodeIdea { get; set; }
        public DbSet<IHAVENOIDEAS.Data.SchoolIdea>? SchoolIdea { get; set; }
    }
}