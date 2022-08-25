# BugTracker

An issue tracking web application with the ability to manage projects and tickets.
On the front-end, users are able to authenticate into the app, and create "Projects" and log "Tickets".
This project uses the MVC architectural pattern and relies on an MS SQL Entity Framwork Database.

Demo
![Bug Tracker Demo](BugTrackerDemo.gif)

### Description

- Authenticate into the program with Auth0 using an email/password or using Google sign in.
- View all the projects created
- Create, delete, edit, and view "Projects"
- View all the tickets cooresponding to a specific project
- Create, delete, edit, and view "Tickets" within projects

### Technologies Used

- ASP.NET Core MVC
- Auth0
- MS SQL Server
- LINQ
- Entity Framework

### Motivations

I wanted to learn C# and get into .NET ecosystem because it's something that isn't covered at my school.
I have more experience with React, I was interested in seeing how it differs from it. I spent a lot of
time experimenting with different technologies like Blazor Server until I ultimately decided on building
a bug/issue tracker. A bug tracker is the right project for me as someone who wants to learn more about
the development process as well as .NET.

### Hurdles

One of the difficulties I faced during this project so far, is the tranfer of data between the Views and
Controllers. This was especially true when using HTML forms and ASP helper tags to capture ticket and
project data for creation or editing. The solution was simpler than I thought it would be only requiring
me to use the @model keyword.  
To make the code for my Views less cluttered, I used Partial Views for the project/ticket forms. I faced
similar difficulty trying to pass data into these parial views from the current view because it had to be
done within the .cshtml file for the view opposed to from within the controller method. The solution was
propogating the ViewData into the partial view.

### Successes

Once I set up the project and ticket creation functionality. I was able to create a project for this
Bug Tracker app to manage and keep track of my progress while I finish it.  
Following the creation of the database, I spent a lot of time thinking about how I wanted to structure
it (how many tables I would have and what data they needed to contain). I had to especially think
about how I would "assign" multiple users to a single project because a relational database (MS SQL)
can't store lists of information in a table cell. I later learned that the solution I came up with is
what is called a junction table.  
These are just few of the many successes throughout this project. The most important, though, would be
everything I learned about ASP.NET, databases, routing, and the MVC model.

### To Dos

- Implement user assignments to Projects/Tickets
- Implement authorization with different roles (Developer, Project Manager, Admin)
- Signin/signup
- Role management
- Archive completed tickets
- Implement ticket comments and history information

### Resources

ASP.NET Documentation
Stack Overflow
Bootstrap Template: https://startbootstrap.com/theme/sb-admin-2
