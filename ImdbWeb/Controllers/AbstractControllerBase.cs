using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
    public abstract class AbstractControllerBase : Controller
    {
        private MovieDAL.ImdbContext database;

        protected MovieDAL.ImdbContext db
        {
            get
            {
                if (database == null)
                    database = new MovieDAL.ImdbContext();
                return database;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && database != null) database.Dispose();
            base.Dispose(disposing);
        }
    }
}
