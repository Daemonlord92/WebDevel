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

    }
}
