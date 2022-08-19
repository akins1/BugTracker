using BugTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BugTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/home/dashboard"); //Redirect("dashboard");
            }
            return View();
        }

        [Authorize]
        //[HttpGet("dashboard")]
        public IActionResult Dashboard()
        {

            return View();
        }

        [Authorize]
        //[HttpGet("notifications")]
        public IActionResult Notifications()
        {
            // set as not implemented
            return View();
        }




        

        /*[Authorize]
        [HttpGet("projects/{project_name}")]
        public IActionResult ProjectView(string project_name)
        {
            return View();
        }*/

        [Authorize]
        //[HttpGet("projects/{project_name}/tickets")]
        public IActionResult ProjectTickets(string project_name)
        {
            return View();
        }

        [Authorize]
        //[HttpGet("projects/{project_name}/tickets/{ticket_id}")]
        public IActionResult TicketView(string project_name, string ticket_id)
        {
            return View();
        }

        [Authorize]
        //[HttpGet("manage/projects")]
        public IActionResult ManageProjects()
        {
            return View();
        }

        [Authorize]
        //[HttpGet("manage/projects/{project_name}")]
        public IActionResult ManageProjectView(string project_name)
        {
            return View();
        }

        [Authorize]
        //[HttpGet("manage/users")]
        public IActionResult ManageUsers()
        {
            return View();
        }

        [Authorize]
        //[HttpGet("account/profile")]
        public IActionResult Profile()
        {
            return View();
        }

        // figure out routing for project

        // url to view all projects:                                                /projects
        // url to view single project:                                              /project/{PROJECT_NAME}
        // ex. project called "Dev Test" should be                                  /projects/Dev_Test

        // url to view all tickets for a specific project:                          /projects/{PROJECT_NAME}/tickets
        // url to view a specific ticket from a specific project:                   /projects/{PROJECT_NAME}/tickets/{TICKET_ID}
        // ex. project called "Dev Test" with ticket id of 2232 should be           /projects/Dev_Test/tickets/2232


        // manage views: Manage Projects, Manage Users
        // Admins can view both, Project Managers can only view Manage Projects
        // url to manage all projects in user's scope:                              /manage/projects or /projects/manage ??? not sure which is better
        // url to manage a specific project:                                        /manage/projects/{PROJECT_NAME}

        // url to manage all users (admin only):                                    /manage/users
        // no need to have individual pages?
        // if we were to, we would display history, projects/tickets
        // worked on, name, email, delete user                                      /manage/users/{user_id} ? what is a good identifier for a user


        // Profile: available to all users
        // url to view profile                                                      /profile








        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}