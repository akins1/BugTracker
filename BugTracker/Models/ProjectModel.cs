using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class ProjectModel
    {
        [Key]
        public int ProjectId { get; set; }

        public string Title { get; set; } = "Project Title";

        public string Description { get; set; } = "No Description";

        public DateTime CreatedOn { get; set; } = DateTime.Now;

    }


    public class ProjectManagedByJunction
    {
        [Key]
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int UserId { get; set; }
    }

    public class ProjectDevelopersJunction
    {
        [Key]
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int UserId { get; set; }
    }

    
    public class ProjectComment
    {
        [Key]
        public int CommentId { get; set; }

        public int ProjectId { get; set; } // should match the projectId it belongs to

        public string Description { get; set; } = "No Description";

        public string Author { get; set; } = "No Author";

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        // public bool isValid { get; set; }
    }

    public class ProjectHistory
    {
        [Key]
        public int HistoryId { get; set; }

        public int ProjectId { get; set; } // should match the projectId it belongs to

        public string Description { get; set; } = "No Description";

        public string Author { get; set; } = "No Author"; //User

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
