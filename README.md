# Web Developer Portfolio App

Remastering my old web developer portfolio with C#/Angular/SQL Server.

Using this I've been able to create quite a few stored procedures to create, edit, and delete items within the database. Will be creating some Table Value Functions to return info to the front.

Repository is almost to start constructing the Controller. Going try to leverage the internal Database function in Entity Framework Core to help block who can create post in the app.

07/09/2022 Started working on the API. 

## SQL Stored Procedures:

usp_RegisterUser(@Username(50), @Password(300), @EmailId(300))

usp_PostNewProject(@ProjectName(150), @Description(400), @GitUrl(MAX), @UserId(3,0))

usp_EditProject(@ProjectId(4,0), @ProjectName(150, nullable), @Description(400, nullable), @GitUrl(MAX, nullable), @UserId(3,0))

usp_DeleteProject(@ProjectId(4,0), @UserId(3,0))

usp_PostNewBug(@BugName(150), @BugDescription(300), @GitUrl(MAX), @UserId(3,0))

usp_EditBug(@BugId(6,0), @BugName(150, nullable), @BugDecscription(300, nullable), @GitUrl(MAX, nullable), @UserId(3,0))

## Repository Functions

RegisterUser(username, password, emailId)

PostNewProject(projectName, description, gitUrl, userId)

EditProject(projectId, userId, projectName(nullable), description(nullable), gitUrl(nullable))

DeleteProject(projectId, userId)

PostNewBug(bugName, bugDescription, gitUrl, userId)

EditBug(bugId, userId, bugName(nullable), bugDescription(nullable), gitUrl(nullable))

## API Routes

/APIv1/User/RegisterUser taking a User Object with a UserName, Password, Email.

/APIv1/Project/PostNewProject taking a Project Object with ProjectName, Description, GitUrl, UserId.

/APIv1/Project/EditProject taking a Project Object with ProjectId, UserId, ProjectName, Description, GitUrl.

/APIv1/Project/DeleteProject taking a projectId and userId varibles.

/APIv1/BugTracker/PostNewBug taking a Bug Object with a BugName, BugDescription, GitUrl, UserId.
