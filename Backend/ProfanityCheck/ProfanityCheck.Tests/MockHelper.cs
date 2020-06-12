using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace ProfanityCheck.Tests
{
    public static class MockHelper
    {
        public static Mock<DbSet<T>> MockDbSet<T>(IEnumerable<T> data) where T : class, new()
        {
            var queryableData = data.AsQueryable();
            var dbSetMock = new Mock<DbSet<T>>();
            dbSetMock.As<IQueryable<T>>().Setup(x => x.Provider).Returns(queryableData.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(queryableData.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.Expression).Returns(queryableData.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(() => queryableData.GetEnumerator());

            return dbSetMock;
        }
    }
}
