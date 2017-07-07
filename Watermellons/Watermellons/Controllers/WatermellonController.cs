using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Watermellons.EntityFramework;
using Watermellons.Services;

namespace Watermellons.Controllers
{
    public class WatermellonController : Controller
    {
        private ICompetitionEntryService _competitionEntryService;
        private IEmailService _emailService;
        private IMessageFormatter _messageFormatter;

        public WatermellonController(ICompetitionEntryService competitionEntryService, IEmailService emailService, IMessageFormatter messageFormatter)
        {
            _competitionEntryService = competitionEntryService;
            _emailService = emailService;
            _messageFormatter = messageFormatter;
        }

        public ActionResult Thankyou()
        {
            return View();
        }

        public ActionResult CompetitionEntry()
        {
            return View("CompetitionEntry");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CompetitionEntry([Bind(Include = "CompetitionEntryId,FullName,Email,Gender,FavouriteWatermellonPlace,TermsAndConditionsAccepted")] CompetitionEntry competitionEntry)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string errorMessage = "";
                    if(_competitionEntryService.InsertCompetitionEntry(competitionEntry, out errorMessage))
                    {
                        var messageBody = _messageFormatter.FormatMessage(competitionEntry);
                        _emailService.EmailMessage(competitionEntry.Email, "You have been entered", messageBody);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, errorMessage);
                        return View(competitionEntry);
                    }
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occured trying to create your entry");
                    return View("CompetitionEntry", competitionEntry);
                }
                return RedirectToAction("Thankyou");
            }

            return View("CompetitionEntry", competitionEntry);
        }

        [HttpPost]
        public JsonResult IsAlreadyEntered(string email)
        {
            if (_competitionEntryService.EntryAlreadyExists(email) == true) 
            {
                return Json(new { Result = true, Message = "Email already entered" });
            }
            else
            {
                return Json(new { Result = false, Message = "Email unknown" });
            }
        }
    }
}
