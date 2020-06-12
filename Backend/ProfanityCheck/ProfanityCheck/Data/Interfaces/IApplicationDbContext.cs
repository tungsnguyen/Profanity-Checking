using Microsoft.EntityFrameworkCore;
using ProfanityCheck.Core.Entities;

namespace ProfanityCheck.Data.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<BannedWord> BannedWords { get; }
        DbSet<BannedPhrase> BannedPhrases { get; }
    }
}
