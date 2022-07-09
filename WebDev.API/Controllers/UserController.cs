using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebDev.API.Models;
using WebDev.DAL;

namespace WebDev.API.Controllers
{
    [Route("apiv1/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DAL.Repo.WebDevRepository repository;

        public UserController()
        {
            repository = new DAL.Repo.WebDevRepository();
        }

        [HttpPost]
        public int RegisterUser( User user )
        {
            int result;
            try
            {
                result = repository.RegisterUser(user.UserName, user.Password, user.Email);
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
