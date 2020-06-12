using System.Collections.Generic;
using FluentAssertions;
using ProfanityCheck.ApplicationServices;
using ProfanityCheck.ApplicationServices.Interfaces;
using ProfanityCheck.Core.Entities;
using Xunit;

namespace ProfanityCheck.Tests.ApplicationServices
{
    public class ProfanityServiceTests
    {
        private readonly IProfanityService profanityService;

        public ProfanityServiceTests()
        {
            var applicationDbContextMock = new DbContextMock();
            applicationDbContextMock.Mock.Setup(x => x.BannedWords).Returns(MockHelper.MockDbSet(new List<BannedWord> { new BannedWord { Id = 1, Word = "Shit" } }).Object);
            applicationDbContextMock.Mock.Setup(x => x.BannedPhrases).Returns(MockHelper.MockDbSet(new List<BannedPhrase> { new BannedPhrase { Id = 1, Phrase = "Piece of shit" } }).Object);
            profanityService = new ProfanityService(applicationDbContextMock.Object);
        }

        [Fact]
        public void CheckFile_EmptyContent_ReturnsTrue()
        {
            profanityService.IsFileAllowed(string.Empty).Should().BeTrue();
        }

        [Fact]
        public void CheckFile_FoundBannedWord_ReturnsFalse()
        {
            profanityService.IsFileAllowed("Shit").Should().BeFalse();
            profanityService.IsFileAllowed("SHIT").Should().BeFalse();
            profanityService.IsFileAllowed("ShIt").Should().BeFalse();
            profanityService.IsFileAllowed("sHiT").Should().BeFalse();
        }

        [Fact]
        public void CheckFile_FoundBannedPhrase_ReturnsFalse()
        {
            profanityService.IsFileAllowed("Piece of shit").Should().BeFalse();
            profanityService.IsFileAllowed("Piece OF shit").Should().BeFalse();
            profanityService.IsFileAllowed("PiEce of shit").Should().BeFalse();
            profanityService.IsFileAllowed("PIeCe of shit").Should().BeFalse();
        }
    }
}
