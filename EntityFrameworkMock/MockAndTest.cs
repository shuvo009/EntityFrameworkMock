using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using JustMockTest;
using Moq;
using Xunit;

namespace EntityFrameworkMock
{
    public class MockAndTest
    {
        private readonly BaseRepository<EmployeeSkill> _baseRepository;
        public MockAndTest()
        {
            var dummyData = GetEmployeeSkills();
            var mockSet = new Mock<DbSet<EmployeeSkill>>();

            mockSet.As<IDbAsyncEnumerable<EmployeeSkill>>()
                .Setup(x => x.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<EmployeeSkill>(dummyData.GetEnumerator()));

            mockSet.As<IQueryable<EmployeeSkill>>()
                .Setup(x => x.Provider)
                .Returns(new TestDbAsyncQueryProvider<EmployeeSkill>(dummyData.Provider));

            mockSet.As<IQueryable<EmployeeSkill>>().Setup(m => m.Expression).Returns(dummyData.Expression);
            mockSet.As<IQueryable<EmployeeSkill>>().Setup(m => m.ElementType).Returns(dummyData.ElementType);
            mockSet.As<IQueryable<EmployeeSkill>>().Setup(m => m.GetEnumerator()).Returns(dummyData.GetEnumerator());

            var mockContext = new Mock<TimeSketchContext>();
            mockContext.As<IDbContext>().Setup(c => c.Set<EmployeeSkill>()).Returns(mockSet.Object);

            _baseRepository  = new BaseRepository<EmployeeSkill>(mockContext.Object);
        }
        
        [Fact]
        public async Task DbTest()
        {
            var data = await _baseRepository.FindAsync(1);
            Assert.NotEqual(null, data);
        }

        private EmployeeSkill GetEmployeeSkill()
        {
            return new EmployeeSkill
            {
                SkillDescription = "SkillDescription",
                SkillName = "SkillName",
                Id = 1
            };
        }

        private IQueryable<EmployeeSkill> GetEmployeeSkills()
        {
            return new List<EmployeeSkill>
            {
                GetEmployeeSkill(),
                GetEmployeeSkill(),
                GetEmployeeSkill(),
            }.AsQueryable();
        }
    }
}
