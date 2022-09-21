using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebDev.API.Models;
using WebDev.DAL;

namespace WebDev.API.Controllers
{
    [Route("APIv1/[controller]/[action]")]
    [ApiController]
    public class BugTrackerController : ControllerBase
    {

        DAL.Repo.WebDevRepository repository;

        public BugTrackerController()
        {
            repository = new DAL.Repo.WebDevRepository();
        }

        [HttpGet]
        public IActionResult GetAllBugs()
        {
            try
            {
                return Ok(repository.GetAllBugs());
            }
            catch (System.Exception)
            {
                
                throw new Exception("Error WILL ROBERTSON ERROR");
            }
        }

        [HttpPost]
        public int PostNewBug(Bug bug)
        {
            int result;
            try
            {
                result = repository.PostNewBug(bug.BugName, bug.BugDescription, bug.GitUrl, bug.UserId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = -99;
            }
            return result;
        }

        [HttpPut]
        public int EditBug(Bug bug)
        {
            int results;
            try
            {
                results = repository.EditBug(bug.BugId, bug.UserId, (bug.BugName ?? null), (bug.BugDescription ?? null), (bug.GitUrl ?? null));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                results = -99;
            }
            return results;
        }
    }
}
