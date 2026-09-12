namespace ProjectR_Web.Server.DTOs
{
    public class SeedProjectDataDto
    {
        public string Name { get; set; }
        public int CreatedAt { get; set; }
        public List<IssueDTO> Issues { get; set; } = [];
    }

    public class IssueDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Severity { get; set; }
        public string Status { get; set; }
        public int LastUpdated { get; set; }
        public int CreatedAt { get; set; }
        public List<ChangeDTO> Changes { get; set; } = [];
        public List<MediaDTO> Media { get; set; } = [];
        public int ProjectId { get; set; }
    }

    public class MediaDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string MediaType { get; set; }
        public string Path { get; set; }
        public int IssueId { get; set; }
    }

    public class ChangeDTO
    {
        public string ChangeHash { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatedAt { get; set; }
        public int IssueId { get; set; }
    }
}
