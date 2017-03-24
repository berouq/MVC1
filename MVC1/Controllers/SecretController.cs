using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC1.Controllers
{
    [Authorize]
    public class SecretController : Controller
    {
        public ContentResult Secret()
        {
            return Content("secret");
        }
        
        [AllowAnonymous]
        public ContentResult Overt()
        {
            return Content("not a secret");
        }

    }
}