using Microsoft.EntityFrameworkCore;
using ProfanityCheck.Core.Entities;
using ProfanityCheck.Data.Interfaces;

namespace ProfanityCheck.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<BannedWord> BannedWords { get; set; }
        public DbSet<BannedPhrase> BannedPhrases { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}
