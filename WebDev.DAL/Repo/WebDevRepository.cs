using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDev.DAL.Models;

namespace WebDev.DAL.Repo
{
    public class WebDevRepository
    {
        WebDevPortDBCoreContext context;

        public WebDevRepository()
        {
            context = new WebDevPortDBCoreContext();
        }

        public int RegisterUser(string username, string password, string emailId)
        {
            int result;
            SqlParameter prmUsername = new SqlParameter("@Username", username);
            SqlParameter prmPassword = new SqlParameter("@Password", password);
            SqlParameter prmEmailId = new SqlParameter("@EmailId", emailId);

            try
            {
                result = context.Database.ExecuteSqlRaw("EXEC usp_RegisterUser @Username, @Password, @EmailId", new[] { prmUsername, prmPassword, prmEmailId });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = -99;
            }
            return result;
        }

        public int PostNewProject(string projectName, string description, string gitUrl, int userId)
        {
            int result;
            SqlParameter prmProjectName = new SqlParameter("@ProjectName", projectName);
            SqlParameter prmProjectDescription = new SqlParameter("@Description", description);
            SqlParameter prmGitUrl = new SqlParameter("@GitUrl", gitUrl);
            SqlParameter prmUserId = new SqlParameter("@UserId", userId);
            try
            {
                result = context.Database.ExecuteSqlRaw("EXEC dbo.usp_PostNewProject @ProjectName, @Description, @GitUrl, @UserId", new[] { prmProjectName, prmProjectDescription, prmGitUrl, prmUserId });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = -99;
            }
            return (int)result;
        }

        public List<Project> GetAllProjects()
        {
            List<Project> result = new List<Project>();

            try 
	        {	        
		        result = context.Projects.ToList();
	        }
	        catch (Exception)
	        {

		        result = null;
	        }
            return result;
        }

        public int EditProject(int projectId, int userId, string projectName = null, string description = null, string gitUrl = null)
        {
            int result;
            SqlParameter prmProjectId = new SqlParameter("@ProjectId", projectId);
            SqlParameter prmProjectName = new SqlParameter("@ProjectName", projectName ?? SqlString.Null);
            SqlParameter prmProjectDescription = new SqlParameter("@Description", description ?? SqlString.Null);
            SqlParameter prmGitUrl = new SqlParameter("@GitUrl", gitUrl ?? SqlString.Null);
            SqlParameter prmUserId = new SqlParameter("@UserId", userId);

            try
            {
                result = context.Database.ExecuteSqlRaw("EXEC dbo.usp_EditProject @ProjectId, @ProjectName, @Description, @GitUrl, @UserId", new[] { prmProjectId, prmProjectName, prmProjectDescription, prmGitUrl, prmUserId });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = -99;
            }
            return result;
        }

        public int DeleteProject(int projectId, int userId)
        {
            int result;
            SqlParameter prmProjectId = new SqlParameter("@ProjectId", projectId);
            SqlParameter prmUserId = new SqlParameter("@UserId", userId);

            try
            {
                result = context.Database.ExecuteSqlRaw("EXEC dbo.usp_DeleteProject @ProjectId, @UserId", new[] { prmProjectId, prmUserId });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = -99;
            }
            return result;
        }

        public int PostNewBug(string bugName, string bugDescription, string gitUrl, int userId)
        {
            SqlParameter prmBugName = new SqlParameter("@BugName", bugName);
            SqlParameter prmBugDescription = new SqlParameter("@BugDescription", bugDescription);
            SqlParameter prmGitUrl = new SqlParameter("@GitUrl", gitUrl);
            SqlParameter prmUserId = new SqlParameter("@UserId", userId);
            int result;

            try 
	        {	        
		        result = context.Database.ExecuteSqlRaw("EXEC usp_PostNewBug @BugName, @BugDescription, @GitUrl, @UserId", new[]
                {
                    prmBugName, prmBugDescription, prmGitUrl, prmUserId
                });
	        }
	        catch (Exception ex)
	        {
                Console.WriteLine(ex.Message);
		        result = -99;
	        }
            return (int)result;
        }

        public int EditBug(int bugId, int userId, string bugName = null, string bugDescription = null, string gitUrl = null)
        {
            SqlParameter prmBugId = new SqlParameter("@BugId", bugId);
            SqlParameter prmUserId = new SqlParameter("@UserId", userId);
            SqlParameter prmBugName = new SqlParameter("@BugName", bugName ?? SqlString.Null);
            SqlParameter prmBugDescription = new SqlParameter("@BugDescription", bugDescription ?? SqlString.Null);
            SqlParameter prmGitUrl = new SqlParameter("@GitUrl", gitUrl ?? SqlString.Null);
            int result;
            try
            {
                result = context.Database.ExecuteSqlRaw("EXEC usp_EditBug @BugId, @BugName, @BugDescription, @GitUrl, @UserId", new[]
                {
                    prmBugId, prmBugName, prmBugDescription, prmGitUrl, prmUserId
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = -99;
            }

            return result;
        }
    }
}
