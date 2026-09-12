using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectR_Web.Server.Entities
{
    [Table("Media")]
    public class Media
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string MediaType { get; set; }
        public required string Path { get; set; }
        public required int IssueId { get; set; }
        public required Issue Issue { get; set; }
    }
}
