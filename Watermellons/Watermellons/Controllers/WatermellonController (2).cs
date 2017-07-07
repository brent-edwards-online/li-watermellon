namespace Watermellons.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Watermellons.Repository;
    using Watermellons.Services;

    public class WatermellonController : Controller
    {
        ICompetitionEntryService _competitionEntryService;
        public WatermellonController(ICompetitionEntryService competitionEntryService)
        {
            _competitionEntryService = competitionEntryService;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}