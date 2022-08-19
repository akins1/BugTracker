using BugTracker.Models;

namespace BugTracker.Controllers
{
    public class ProjectDataController
    {
        public void CreateProject()
        {
            // string: projectTitle
            // string: description
            // List<string> or string -> string.split(): managers
            // List<string> or string -> string.split(): developers
            // create a project with a unique id and store in database
            // route user to project page
            Console.WriteLine("Project {PROJECT_TITLE} Created");
            
        }

        public List<ProjectModel> GetAllProjects(UserModel user)
        {
            // from user from ProjectManagedByJunction select projectId
            // from user from ProjectDeveloperJunction select projectId
            // for each projectId, from Projects select project with projectId then add to list
            // return list
            return new List<ProjectModel>();
        }

        public List<ProjectModel> GetAllProjects(string userEmail)
        {
            // get userid based on userEmail
            // from user from ProjectManagedByJunction select projectId
            // from user from ProjectDeveloperJunction select projectId
            // for each projectId, from Projects select project with projectId then add to list
            // return list
            return new List<ProjectModel>();
        }

        public ProjectModel GetProjectById(int projectId)
        {
            return new ProjectModel();
        }

        public string GetProjectName(int projectId)
        {
            return "";
        }

        public string GetProjectDescription(int projectId)
        {
            return "";
        }

        public DateTime GetProjectCreatedOn(int projectId)
        {
            return DateTime.Now;
        }

        public List<string> GetProjectComments(int projectId)
        {
            return new List<string>();
        }

        public List<string> GetProjectHistory(int projectId)
        {
            return new List<string>();
        }

        public List<UserModel> GetProjectManagedBy(int projectId)
        {
            return new List<UserModel>();
        }

        public List<UserModel> GetProjectDevelopers(int projectId)
        {
            return new List<UserModel>();
        }
    }

    public class TicketDataController
    {
        public List<TicketModel> GetAllTickets(int projectId)
        {
            return new List<TicketModel>();
        }

        public List<TicketHistory> GetTicketHistory(int ticketId)
        {
            return new List<TicketHistory>();
        }

    }

    public class UserDataController
    {

    }
}
