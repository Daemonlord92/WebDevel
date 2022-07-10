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
    }
}
