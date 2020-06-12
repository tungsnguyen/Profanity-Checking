using Moq;
using ProfanityCheck.Data.Interfaces;

namespace ProfanityCheck.Tests
{
    public class DbContextMock
    {
        public Mock<IApplicationDbContext> Mock { get; }

        public DbContextMock(MockBehavior mockBehavior = MockBehavior.Loose)
        {
            Mock = new Mock<IApplicationDbContext>(mockBehavior);
        }

        public IApplicationDbContext Object => Mock.Object;
    }
}
