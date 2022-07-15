using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebDev.API.Models;
using WebDev.DAL;

namespace WebDev.API.Controllers
{
    [Route("APIv1/[controller]/[action]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        DAL.Repo.WebDevRepository repository;

        public ProjectController()
        {
            repository = new DAL.Repo.WebDevRepository();
        }

        [HttpPost]
        public int PostNewProject(Project project)
        {
            int result;
            try
            {
                result = repository.PostNewProject(project.ProjectName, project.Description, project.GitUrl, project.UserId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = -99;
            }
            return result;
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            List<DAL.Models.Project> result;
            try 
	        {	        
		        result = repository.GetAllProjects().ToList();
	        }
	        catch (Exception)
	        {

		        result = null;
	        }
            return new JsonResult(result);
        }

        [HttpPut]
        public int EditProject(Project project)
        {
            int result;
            try
            {
                result = repository.EditProject(project.ProjectId, project.UserId, (project.ProjectName ?? null), (project.Description ?? null), (project.GitUrl ?? null));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = -99;
            }
            return result;
        }

        [HttpDelete]
        public int DeleteProject(int projectId, int userId)
        {
            return repository.DeleteProject(projectId, userId);
        }
    }
}
