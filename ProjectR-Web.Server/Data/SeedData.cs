using Microsoft.EntityFrameworkCore;
using ProjectR_Web.Server.DTOs;
using System.Security.Cryptography;
using System.Text.Json;

namespace ProjectR_Web.Server.Data
{
    public class SeedData
    {
        public static async Task SeedDatabase(DatabaseContext context)
        {
            await context.Database.MigrateAsync();

            if (await context.Projects.AnyAsync())
            {
                return; // Database has been seeded
            }

            string testDataRaw = await File.ReadAllTextAsync("Data/seed.json");

            JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };

            var testData = JsonSerializer.Deserialize<List<SeedProjectDataDto>>(testDataRaw, options);

            foreach (var project in testData!)
            {
                var newProject = new Entities.Project
                {
                    Name = project.Name,
                    CreatedAt = DateTime.Now.AddDays(project.CreatedAt),
                };

                context.Projects.Add(newProject);

                foreach (var issue in project.Issues)
                {
                    var newIssue = new Entities.Issue
                    {
                        Name = issue.Name,
                        Description = issue.Description,
                        Severity = issue.Severity,
                        Status = issue.Status,
                        LastUpdated = DateTime.Now.AddDays(issue.LastUpdated),
                        CreatedAt = DateTime.Now.AddDays(issue.CreatedAt),
                        Media = [],
                        ProjectId = newProject.Id,
                        Project = newProject
                    };

                    context.Issues.Add(newIssue);

                    foreach (var change in issue.Changes)
                    {
                        var changeHashBytes = SHA1.HashData(System.Text.Encoding.UTF8.GetBytes(change.ChangeHash));
                        var changeHashString = BitConverter.ToString(changeHashBytes).Replace("-", "").ToLowerInvariant();
                        var newChange = new Entities.Change
                        {
                            ChangeHash = changeHashString,
                            Name = change.Name,
                            Description = change.Description,
                            CreatedAt = DateTime.Now.AddDays(change.CreatedAt),
                            IssueId = newIssue.Id,
                            Issue = newIssue
                        };
                        context.Changes.Add(newChange);
                    }

                    foreach (var media in issue.Media)
                    {
                        var newMedia = new Entities.Media
                        {
                            Title = media.Title,
                            Description = media.Description,
                            Path = media.Path,
                            MediaType = media.MediaType,
                            IssueId = newIssue.Id,
                            Issue = newIssue
                        };
                        context.Media.Add(newMedia);
                    }
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
