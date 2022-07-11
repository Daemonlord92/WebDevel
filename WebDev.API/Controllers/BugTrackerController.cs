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

        [HttpPost]
        public int PostNewBug(Bug bug)
        {
            int result;
            try
            {
                result = repository.PostNewBug(bug.BugName, bug.BugDescription, bug.GitUrl, bug.UserId);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = -99;
            }
            return result;
        }
    }
}
