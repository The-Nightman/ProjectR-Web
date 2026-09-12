using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectR_Web.Server.Entities
{
    [Table("Changes")]
    public class Change
    {
        [Key]
        public int Id { get; set; }
        public required string ChangeHash { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required DateTime CreatedAt { get; set; } = DateTime.Now;
        public required int IssueId { get; set; }
        public required Issue Issue { get; set; }
    }
}
