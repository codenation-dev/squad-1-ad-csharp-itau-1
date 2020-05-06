using ItaLog.Data.Context;
using ItaLog.Data.Repositories;
using ItaLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ItaLog.Test
{
    public class LogRepositoryTest
    {
        [Fact]
        public void GetAllMethod_ShouldWork()
        {
            Mock<ItaLogContext> _context = ArrangeContext();

            //Act
            LogRepository LogRepotest = new LogRepository(_context.Object);
            var logs = LogRepotest.GetAll();

            //Assert
            Assert.Equal(3, logs.Count());
        }

        [Fact]
        public void GetByIdMethod_ShouldWork()
        {
            Mock<ItaLogContext> _context = ArrangeContext();

            //Act
            LogRepository LogRepotest = new LogRepository(_context.Object);
            var logById = LogRepotest.FindById(4);

            //Assert           
            Assert.Equal(4, logById.Id);
        }

        [Fact]
        public void ArchiveMethod_ShouldWork()
        {
            Mock<ItaLogContext> _context = ArrangeContext();
            //Act
            LogRepository LogRepotest = new LogRepository(_context.Object);
            LogRepotest.Archive(1);
            Log log = _context.Object.Logs.Where(id => id.Id == 1).FirstOrDefault();

            //Assert
            Assert.True(log.Archived);
        }

        [Fact]
        public void AddMethod_ShouldWork()
        {
            Mock<DbSet<Log>> mockSet = ArrangeMockSet();
            Mock<ItaLogContext> mockContext = new Mock<ItaLogContext>();
            mockContext.Setup(m => m.Logs).Returns(mockSet.Object);

            //Act
            LogRepository LogRepotest = new LogRepository(mockContext.Object);
            Log logToAdd = new Log { Id = 3, Title = "111 Revalidation Failed", Origin = "240.20.41.59", Archived = false, LevelId = 2, EnvironmentId = 1, ApiUserId = 6 };
            LogRepotest.Add(logToAdd);

            //Assert            
            mockSet.Verify(m => m.Add(It.IsAny<Log>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Fact]
        public void UpdateMethod_ShouldWork()
        {
            Mock<ItaLogContext> _context = ArrangeContext();

            //Act
            LogRepository LogRepotest = new LogRepository(_context.Object);

            var logToAddUpdated = new Log { Id = 1, Title = "UPDATE -- 599 Network connect timeout error", Origin = "216.3.128.12", Archived = false, LevelId = 3, EnvironmentId = 1, ApiUserId = 3 };
            LogRepotest.Update(logToAddUpdated);

            //Assert          
            Assert.Equal("UPDATE -- 599 Network connect timeout error", logToAddUpdated.Title);
        }

        [Fact]
        public void RemoveMethod_ShouldWork()
        {
            Mock<DbSet<Log>> mockSet = ArrangeMockSet();
            Mock<ItaLogContext> mockContext = new Mock<ItaLogContext>();
            mockContext.Setup(m => m.Logs).Returns(mockSet.Object);

            //Act
            LogRepository LogRepotest = new LogRepository(mockContext.Object);
            LogRepotest.Remove(1);

            //Assert           
            mockSet.Verify(m => m.Remove(It.IsAny<Log>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        private Mock<DbSet<Log>> ArrangeMockSet()
        {
            IQueryable<Log> data = new List<Log>
             {
            new Log { Id = 1, Title = "599 Network connect timeout error", Origin = "216.3.128.12", Archived = false, LevelId = 3, EnvironmentId = 1, ApiUserId = 3 },
            new Log { Id = 2, Title = "413 Request Entity Too Large", Origin = "158.113.248.85", Archived = false, LevelId = 3, EnvironmentId = 2, ApiUserId = 1 },
            new Log { Id = 3, Title = "512 Disconnected Operation", Origin = "227.39.42.158", Archived = false, LevelId = 1, EnvironmentId = 2, ApiUserId = 4 },

            }.AsQueryable();

            Mock<DbSet<Log>> mockSet = new Mock<DbSet<Log>>();
            mockSet.As<IQueryable<Log>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Log>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Log>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Log>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return mockSet;
        }

        private Mock<ItaLogContext> ArrangeContext()
        {
            Mock<ItaLogContext> mockContext = new Mock<ItaLogContext>();
            mockContext.Setup(m => m.Logs).Returns(ArrangeMockSet().Object);
            return mockContext;
        }

    }
}
