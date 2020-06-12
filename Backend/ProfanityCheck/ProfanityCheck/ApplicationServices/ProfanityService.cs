using System.Linq;
using ProfanityCheck.ApplicationServices.Interfaces;
using ProfanityCheck.Data.Interfaces;

namespace ProfanityCheck.ApplicationServices
{
    public class ProfanityService : IProfanityService
    {
        private readonly IApplicationDbContext dbContext;

        public ProfanityService(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool IsFileAllowed(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return true;
            }

            if (dbContext.BannedWords.ToList().Any(bannedWord => content.ToUpper().Contains(bannedWord.Word.ToUpper())))
            {
                return false;
            }

            if (dbContext.BannedPhrases.ToList().Any(bannedPhrase => content.ToUpper().Contains(bannedPhrase.Phrase.ToUpper())))
            {
                return false;
            }

            return true;
        }
    }
}
