using Auth0.ManagementApi.Models;
using BugTracker.Data;
using BugTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Controllers
{
    
    public class ProjectController : Controller
    {
        private readonly BugTrackerDbContext _db;
        public ProjectController(BugTrackerDbContext db)
        {
            _db = db;
            //string projectRoute
        }


        [Authorize]
        //[HttpGet("projects")]
        public IActionResult Projects()
        {
            ViewBag.Projects = _db.Projects.ToList();
            //ViewBag.ProjectViewRoute1 = "/projects/";
            //ViewBag.ProjectViewRoute2 = "/view";

            // TODO
            // query all the project managers
            // ViewData["managers"] = "managers";

            // query all the developers
            // ViewData["developers"] = "developers";

            return View();
        }


        
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProject(ProjectModel pmodel)
        {
            _db.Projects.Add(pmodel);
            _db.SaveChanges();
            //TODO
            //input validation for _CreateProjectForm: https://docs.microsoft.com/en-us/aspnet/web-pages/overview/ui-layouts-and-themes/validating-user-input-in-aspnet-web-pages-sites

            return RedirectToAction("ProjectView", new { projectId = pmodel.ProjectId });
        }

        [Authorize]
        //[HttpGet("projects/{projectId}/view")]
        public IActionResult ProjectView(int projectId)
        {

            ProjectModel projectData =      _db.Projects.Find(projectId);
            List<TicketModel> ticketsData = _db.Tickets.Where(t => t.ProjectId == projectId).ToList();

            ViewBag.ProjectData = projectData;
            ViewBag.TicketsData = ticketsData;
            ViewData["projectId"] = projectId;
            //ViewBag.TicketViewRoute1 = "/projects/";
            //ViewBag.TicketViewRoute2 = "/tickets/";

            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditProject(ProjectModel project)
        {
            //TODO
            //Edit junctions/users

            ProjectModel newProject = _db.Projects.SingleOrDefault(p => p.ProjectId == project.ProjectId);

            if (newProject != null)
            {
                newProject.Title = project.Title;
                newProject.Description = project.Description;


                _db.SaveChanges();
            }

            return RedirectToAction("ProjectView", new { projectId = project.ProjectId });

        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTicket(TicketModel tmodel)
        {
            _db.Tickets.Add(tmodel);
            _db.SaveChanges();
            //TODO
            //input validation for _CreateTicketForm: https://docs.microsoft.com/en-us/aspnet/web-pages/overview/ui-layouts-and-themes/validating-user-input-in-aspnet-web-pages-sites

            return RedirectToAction("ProjectView", new { projectId=tmodel.ProjectId });
        }

        [Authorize]
        //[HttpGet("/projects/{projectId}/tickets/{ticketId}")]
        public IActionResult TicketView(int ticketId, int projectId)
        {
            ProjectModel projectData =        _db.Projects.Single(p => p.ProjectId == projectId);

            TicketModel ticketData =          _db.Tickets.Single(t => t.TicketId == ticketId);
            List<TicketHistory> historyList = _db.TicketHistory.Where(history => history.TicketId == ticketData.TicketId)
                                                               .ToList();
            List<TicketComment> commentList = _db.TicketComment.Where(comment => comment.TicketId == ticketData.TicketId)
                                                               .ToList();
            List<int> contributorsId =        _db.TicketAssignedToJunction.Where(entry => entry.TicketId == ticketData.TicketId)
                                                                          .Select(entry => entry.UserId)
                                                                          .ToList();
            List<UserModel> contributors = new List<UserModel>();
            foreach (int userId in contributorsId)
            {
                contributors.Add(_db.Users.Single(user => user.UserId == userId));
            }

            ViewBag.ProjectData = projectData;
            ViewBag.TicketData = ticketData;
            ViewBag.HistoryList = historyList;
            ViewBag.CommentList = commentList;
            ViewBag.Contributors = contributors;
            ViewData["projectId"] = projectId;
            ViewData["ticketId"] = ticketId;
            //ViewBag.DBContext = _db;

            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditTicket(TicketModel ticket)
        {

            TicketModel newTicket = _db.Tickets.SingleOrDefault(t => t.TicketId == ticket.TicketId);

            if (newTicket != null)
            {
                newTicket.Title = ticket.Title;
                newTicket.Description = ticket.Description;
                newTicket.TicketType = ticket.TicketType;
                newTicket.Priority = ticket.Priority;
                newTicket.Title = ticket.Title;

                _db.SaveChanges();
            }

            return RedirectToAction("TicketView", new { ticketId = ticket.TicketId, projectId = ticket.ProjectId });

        }

        [HttpPost, ActionName("DeleteTicket")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTicket(int projectId, int ticketId)
        {
            //TODO
            //comments, history, junctions to be implemented

            TicketModel ticket =                        _db.Tickets.Find(ticketId);
            // List<TicketComment> comments =              _db.TicketComment.Where(c => c.TicketId == ticketId).ToList();
            // List<TicketHistory> history =               _db.TicketHistory.Where(h => h.TicketId == ticketId).ToList();
            // List<TicketAssignedToJunction> assignedTo = _db.TicketAssignedToJunction.Where(a => a.TicketId == ticketId).ToList();
            

            _db.Tickets.Remove(ticket);
            // foreach (TicketComment c in comments)              _db.TicketComment.Remove(c);
            // foreach (TicketHistory h in history)               _db.TicketHistory.Remove(h);
            // foreach (TicketAssignedToJunction a in assignedTo) _db.TicketAssignedToJunction.Remove(a);

            _db.SaveChanges();

            return RedirectToAction("ProjectView", "Project", new { projectId = projectId });
        }

        [HttpPost, ActionName("DeleteProject")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProject(int projectId)
        {
            //TODO
            //comments, history, junctions to be implemented

            ProjectModel project = _db.Projects.Find(projectId);
            List<TicketModel> tickets = _db.Tickets.Where(t => t.ProjectId == projectId).ToList();
            // List<TicketComment> comments =              _db.TicketComment.Where(c => c.TicketId == ticketId).ToList();
            // List<TicketHistory> history =               _db.TicketHistory.Where(h => h.TicketId == ticketId).ToList();
            // List<TicketAssignedToJunction> assignedTo = _db.TicketAssignedToJunction.Where(a => a.TicketId == ticketId).ToList();

            _db.Projects.Remove(project);
            foreach (TicketModel t in tickets)                 _db.Tickets.Remove(t);
            // foreach (TicketComment c in comments)              _db.TicketComment.Remove(c);
            // foreach (TicketHistory h in history)               _db.TicketHistory.Remove(h);
            // foreach (TicketAssignedToJunction a in assignedTo) _db.TicketAssignedToJunction.Remove(a);

            _db.SaveChanges();

            return RedirectToAction("Projects", "Project", new { projectId = projectId});
        }
    }
}
