using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProfanityCheck.Core.Entities;

namespace ProfanityCheck.Data.SeedData
{
    public static class ApplicationBuilderSeedDataExtensions
    {
        public static void MigrateDatabase(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.Migrate();
        }

        public static void SeedData(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (!dbContext.BannedWords.Any())
            {
                dbContext.BannedWords.AddRange(new List<BannedWord>
                {
                    new BannedWord { Word = "Shit" },
                    new BannedWord { Word = "Damn" }
                });

                dbContext.SaveChanges();
            }

            if (!dbContext.BannedPhrases.Any())
            {
                dbContext.BannedPhrases.AddRange(new List<BannedPhrase>
                {
                    new BannedPhrase { Phrase = "Fuck off" },
                    new BannedPhrase { Phrase = "Piece of shit" }
                });

                dbContext.SaveChanges();
            }
        }
    }
}
