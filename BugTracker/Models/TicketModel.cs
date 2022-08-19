using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class TicketModel
    {
        [Key]
        public int TicketId { get; set; }

        public int ProjectId { get; set; }

        public string Title { get; set; } = "No Title";

        public string Description { get; set; } = "No Description";

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime? ClosedOn { get; set; }

        public string Author { get; set; } = "No Author"; //User

        public TicketType TicketType { get; set; }

        public TicketPriority Priority { get; set; }


    }

    public class TicketAssignedToJunction
    {
        [Key]
        public int Id { get; set; }

        public int TicketId { get; set; }

        public int UserId { get; set; }
    }

    public class TicketComment
    {
        [Key]
        public int CommentId { get; set; }

        public int TicketId { get; set; } // should match the TicketId it belongs to

        public string Description { get; set; } = "No Description";

        public string Author { get; set; } = "No Author";

        public DateTime CreatedOn { get; set; } = DateTime.Now;

    }

    public class TicketHistory
    {
        [Key]
        public int HistoryId { get; set; }

        public int TicketId { get; set; } // should match the TicketId it belongs to

        public string Description { get; set; } = "No Description";

        public string Author { get; set; } = "No Author";

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }

    public enum TicketType
    {
        Bug, Feature, Epic, Documentation, Other
    }

    public enum TicketPriority
    {
        Low, Medium, High, Critical
    }

    
}
