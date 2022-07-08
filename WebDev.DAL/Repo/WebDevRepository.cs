using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    }
}
