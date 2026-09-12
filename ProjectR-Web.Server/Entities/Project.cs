using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectR_Web.Server.Entities
{
    [Table("Projects")]
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required DateTime CreatedAt { get; set; }
        public List<Issue> Issues { get; set; } = [];
    }
}
