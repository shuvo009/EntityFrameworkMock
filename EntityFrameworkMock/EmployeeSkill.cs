using System.ComponentModel.DataAnnotations;
using EntityFrameworkMock;

namespace JustMockTest
{
    public class EmployeeSkill : IEntity
    {
        [MaxLength(100)]
        [Required(ErrorMessage = "Skill is Required ")]
        public string SkillName { get; set; }

        [MaxLength(400)]
        public string SkillDescription { get; set; }
        [Key]
        public long Id { get; set; }
        public bool IsDelete { get; set; }
    }
}